namespace PE_test.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HeatDeviceController : ControllerBase {
    private readonly ApplicationDbContext _context;
    public HeatDeviceController(ApplicationDbContext context) {
        _context = context;
    }

    [HttpGet]
    public async Task<List<HeatDevice>> GetStats() {
        //Kiekvienam sąrašo įrašui yra randamos reikšmės ir paleidžiama saugojimo funkcija
        foreach (var device in HeatDevice.heatDevices) {
            device.Power = await GetPowerStats(device.PowerCode);
            device.TFlow = await GetTempStats(device.TempCode);
            (device.P01, device.P02) = await GetPressureStats(device.P1Code, device.P2Code);
        }
        await SaveData(HeatDevice.heatDevices);
        return HeatDevice.heatDevices;
    }

    [HttpGet("power")]
    public async Task<decimal?> GetPowerStats(string powerCodeString) {
        //Tikrinami simboliai
        char[] chars = ['+', '-'];
        decimal? power;
        bool containsChar = chars.Any(c => powerCodeString.Contains(c));

        if (containsChar == false) {
            //Jei nėra jokio papildomo simbolio, yra gaunama galios reikšmė
            power = LastPowerQuery(powerCodeString);
            return power;

        } else {
            //Jei yra papildomas simbolis, yra randami visi atskiri kodai
            string[] strings = powerCodeString.Split(chars);
            decimal[] powerValues = new decimal[strings.Length];
            string finalString = powerCodeString;

            for (int i = 0; i < strings.Length; i++) {
                //Kiekvienam kodui yra gaunama galios reikšmė
                powerValues[i] = LastPowerQuery(strings[i]).GetValueOrDefault();
            }

            for (int i = 0; i < strings.Length; i++) {
                //Į originalią formulę yra įterpiamos galios reikšmės vieotje kodų
                finalString = finalString.Replace(strings[i], powerValues[i].ToString());
            }

            //Atliekama funkcija, kuri tekstą paverčia matematine formule ir apskaičiuoja bendrą galios reikšmę
            power = Convert.ToDecimal(new DataTable().Compute(finalString, null));
            return power;
        }
    }

    [HttpGet("power-query")]
    public decimal? LastPowerQuery(string powerCodeString) {
        //Vykdoma užklausa
        decimal? power;
        var query = from dcValue in _context.TblDcvalues
                    join heatMetersLast in _context.CmpHeatMetersValLasts on dcValue.DevCompId equals heatMetersLast.DevCompId
                    where dcValue.DcvalueId == int.Parse(powerCodeString)
                    select new {
                        heatMetersLast.Power,
                        dcValue.Caption,
                        dcValue.UnitId
                    };

        //Gaunamas rezultatas, kuris yra patikrinamas ir grąžinamas
        var result = query.FirstOrDefault();
        power = result.Power;
        if (!result.Caption.Contains("mw", StringComparison.CurrentCultureIgnoreCase) && (result.UnitId != 56)) {
            power /= 1000;
        }
        return power;
    }

    [HttpGet("tflow")]
    public async Task<decimal?> GetTempStats(int code) {
        //Temperatūros užklausa
        var query = from dcValue in _context.TblDcvalues
                    join heatMetersLast in _context.CmpHeatMetersValLasts on dcValue.DevCompId equals heatMetersLast.DevCompId
                    where dcValue.DcvalueId == code
                    select heatMetersLast.Tflow;

        //Grąžinamas rezultatas
        return query.FirstOrDefault();
    }

    [HttpGet("p")]
    public async Task<Tuple<float?, float?>> GetPressureStats(int p1Code, int p2Code) {
        //Slėgių užklausos
        var p1Query = from dcValue in _context.TblDcvalues
                    join pressureMetersLast in _context.CmpPressuresValLasts on dcValue.DevCompId equals pressureMetersLast.DevCompId
                    where dcValue.DcvalueId == p1Code
                    select pressureMetersLast.P00;

        var p2Query = from dcValue in _context.TblDcvalues
                      join pressureMetersLast in _context.CmpPressuresValLasts on dcValue.DevCompId equals pressureMetersLast.DevCompId
                      where dcValue.DcvalueId == p2Code
                      select pressureMetersLast.P01;

        //Išsaugomi rezultatai
        Tuple<float?, float?> results = new(p1Query.FirstOrDefault(), p2Query.FirstOrDefault());
        return results;
    }

    [HttpGet("save")]
    public async Task<ActionResult> SaveData(List<HeatDevice> devices) {
        //Sukuriamas Excel failas ir failo pavadinimas
        var memoryStream = new MemoryStream();
        string fileName = "devices.xlsx";
        using (var workbook = new XLWorkbook()) {
            //Sukuriamas darbo lapas
            var worksheet = workbook.Worksheets.Add("Pirmas");
            
            //Šilumos gamintojų tipai ir sujungiami reikiami langeliai
            worksheet.Cell(1, 1).Value = "AŠG";
            worksheet.Range("A1:D1").Merge();
            worksheet.Cell(1, 5).Value = "NŠG";
            worksheet.Range("E1:H1").Merge();
            worksheet.Cell(1, 9).Value = "AB Panevėžio energija konkurenciniai įrenginiai";
            worksheet.Range("I1:X1").Merge();
            worksheet.Cell(1, 25).Value = "AB Panevėžio energija piko/rezervo įrenginiai";
            worksheet.Range("Y1:AB2").Merge();

            //Katilinių pavadinimai ir sujungiami reikiami langeliai
            worksheet.Cell(2, 1).Value = "AB Panevėžio stiklas";
            worksheet.Range("A2:D2").Merge();
            worksheet.Range("B3:D3").Merge();
            worksheet.Cell(2, 5).Value = "UAB Biokuro energija";
            worksheet.Range("E2:H2").Merge();
            worksheet.Range("F3:H3").Merge();
            worksheet.Cell(2, 9).Value = "PRK-1 GK Nr.6 ir Nr.7 kogeneracinis blokas";
            worksheet.Range("I2:L2").Merge();
            worksheet.Range("J3:L3").Merge();
            worksheet.Cell(2, 13).Value = "PRK-1 VŠK Nr.8 ir Nr.9 blokas";
            worksheet.Range("M2:P2").Merge();
            worksheet.Range("N3:P3").Merge();
            worksheet.Cell(2, 17).Value = "PEI katilinė VŠK Nr.1";
            worksheet.Range("Q2:T2").Merge();
            worksheet.Range("R3:T3").Merge();
            worksheet.Cell(2, 21).Value = "PRK-1 VŠK Nr.5";
            worksheet.Range("U2:X2").Merge();
            worksheet.Range("V3:X3").Merge();
            worksheet.Range("Z3:AB3").Merge();

            //Įdedami duomenys ir kita pasikartojanti informacija
            //index - stulpelio numeris
            int index = 1;
            foreach (var device in devices) {
                //Galia Power
                if (device.Power == null)
                    worksheet.Cell(5, index).Value = "-";
                else
                    worksheet.Cell(5, index).Value = device.Power;
                worksheet.Cell(4, index).Value = "Mw";
                worksheet.Cell(3, index).Value = "Šilumos gamyba";
                index++;

                //Temperatūra TFlow
                if (device.TFlow == null)
                    worksheet.Cell(5, index).Value = "-";
                else
                    worksheet.Cell(5, index).Value = device.TFlow;
                worksheet.Cell(4, index).Value = "T1 (C)";
                worksheet.Cell(3, index).Value = "Termofikacinio vandens";
                index++;

                //Slėgis P01
                if (device.P01 == null)
                    worksheet.Cell(5, index).Value = "-";
                else
                    worksheet.Cell(5, index).Value = device.P01;
                worksheet.Cell(4, index).Value = "P1 (bar)";
                index++;

                //Slėgis P02
                if (device.P02 == null)
                    worksheet.Cell(5, index).Value = "-";
                else
                    worksheet.Cell(5, index).Value = device.P02;
                worksheet.Cell(4, index).Value = "P2 (bar)";
                index++;
            }
            //Pridedami lentelės stiliai: linijų plotis, teksto lygiavimas, numerių formatas, pastorintas šriftas ir automatiniai langelių pločiai
            var allCells = worksheet.RangeUsed().Style;
            allCells.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            allCells.Alignment.Vertical = XLAlignmentVerticalValues.Top;
            allCells.NumberFormat.Format = "0.0";
            worksheet.Range(1, 1, 5, index - 1).Style.Border.OutsideBorder = XLBorderStyleValues.Hair;
            worksheet.Range(1, 1, 5, index - 1).Style.Border.InsideBorder = XLBorderStyleValues.Hair;
            worksheet.Range(1, 1, 5, index - 1).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            worksheet.Range(1, 1, 2, index - 1).Style.Font.Bold = true;
            worksheet.Columns().AdjustToContents(9, 25.0);

            //Išsaugomas failas
            workbook.SaveAs(fileName);
        }
        memoryStream.Position = 0;
        return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
    }

    [HttpGet("day")]
    public async Task<List<HeatDevice>> GetDaysStats()
    {
        char[] chars = ['+', '-', '(', ')'];

        decimal? power;
        DateTime? time;

        foreach (var device in HeatDevice.heatDevices)
        {
            bool containsAnyChar = chars.Any(c => device.PowerCode.Contains(c));
            if (containsAnyChar == false)
            {
                var query = from dcValue in _context.TblDcvalues
                            join heatmeters in _context.CmpHeatMetersVals on dcValue.DevCompId equals heatmeters.DevCompId
                            where dcValue.DcvalueId == Int32.Parse(device.PowerCode) &&
                                heatmeters.RecordTime >= new DateTime(2024, 05, 01, 07, 00, 00) &&
                                heatmeters.RecordTime <= new DateTime(2024, 05, 01, 08, 00, 00)
                            select new
                            {
                                heatmeters.RecordTime,
                                heatmeters.Power,
                                dcValue.Caption,
                                dcValue.UnitId
                            };
                var result = query.FirstOrDefault();

                if (result == null)
                {
                    power = 0;
                    time = null;
                }
                else
                {
                    power = result.Power;
                    time = result.RecordTime;
                    if (!result.Caption.Contains("mw", StringComparison.CurrentCultureIgnoreCase) || (result.UnitId != 56))
                    {
                        power /= 1000;
                    }
                    power = Math.Round(power.Value, 1);
                }
                Console.WriteLine(device.Title + ", " + time + ", " + power);
            }
            else
            {
                string[] strings = device.PowerCode.Split(chars);
                int[] powerCodes = new int[strings.Length];
                decimal[] powerValues = new decimal[strings.Length];

                for (int i = 0; i < powerCodes.Length; i++)
                {
                    powerCodes[i] = int.Parse(strings[i]);
                }

                for (int i = 0; i < strings.Length; i++)
                {
                    var query = from dcValue in _context.TblDcvalues
                                join heatmeters in _context.CmpHeatMetersVals on dcValue.DevCompId equals heatmeters.DevCompId
                                where dcValue.DcvalueId == powerCodes[i] &&
                                    heatmeters.RecordTime >= new DateTime(2024, 05, 01, 07, 00, 00) &&
                                    heatmeters.RecordTime <= new DateTime(2024, 05, 01, 08, 00, 00)
                                select new
                                {
                                    heatmeters.RecordTime,
                                    heatmeters.Power,
                                    dcValue.Caption,
                                    dcValue.UnitId
                                };
                    var result = query.FirstOrDefault();
                    if (result == null)
                    {
                        power = 0;
                        time = null;
                    }
                    else
                    {
                        power = result.Power;
                        time = result.RecordTime;
                        if (!result.Caption.Contains("mw", StringComparison.CurrentCultureIgnoreCase) || (result.UnitId != 56))
                        {
                            power /= 1000;
                        }
                        power = Math.Round(power.Value, 1);
                    }
                    Console.WriteLine(device.Title + ", " + time + ", " + power);
                }

                string finalString = device.PowerCode;
                for (int i = 0; i < strings.Length; i++)
                {
                    finalString = finalString.Replace(strings[i].ToString(), powerValues[i].ToString());
                }

                var answer = new DataTable().Compute(finalString, null);
            }
        }
        return HeatDevice.heatDevices;
    }


}