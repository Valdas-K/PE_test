namespace PE_test.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HeatDeviceController : ControllerBase {
    private readonly ApplicationDbContext _context;
    public HeatDeviceController(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<HeatDevice> heatDevices = [
        new HeatDevice {ID = 1, Title = "AB Panevėžio stiklas", PowerCode = "94467", TempCode = 94462, P1Code = 94457, P2Code = 94458 },
        new HeatDevice {ID = 2, Title = "UAB Biokuro energija", PowerCode = "69509", TempCode = 69361, P1Code = 69488, P2Code = 69489 },
        new HeatDevice {ID = 3, Title = "PRK-1 GK Nr.6 ir Nr.7 kogeneracinis blokas", PowerCode = "41908-66239+49217+76713+76719-49209-49219", TempCode = 69361, P1Code = 69488, P2Code = 69489 },
        new HeatDevice {ID = 4, Title = "PRK-1 VŠK Nr.8 ir Nr.9 blokas", PowerCode = "66239+49217+76713+76719", TempCode = 41905, P1Code = 41901, P2Code = 41902 },
        new HeatDevice {ID = 5, Title = "PRK-1 VŠK Nr.5", PowerCode = "49209", TempCode = 41905, P1Code = 41901, P2Code = 41902 },
        new HeatDevice {ID = 6, Title = "PEI katilinė VŠK Nr.1", PowerCode = "89652", TempCode = 71719, P1Code = 71717, P2Code = 71718 },
        new HeatDevice {ID = 7, Title = "AB Panevėžio energija piko/rezervo įrenginiai", PowerCode = "89875-89652+49219", TempCode = 71719, P1Code = 71717, P2Code = 71718 },
    ];

    [HttpGet]
    public async Task<List<HeatDevice>> GetStats() {
        foreach (var device in heatDevices) {
            device.Power = await GetPowerStats(device.PowerCode);
            device.TFlow = await GetTempStats(device.TempCode);
            device.P01 = await GetP1Stats(device.P1Code);
            device.P02 = await GetP2Stats(device.P2Code);
        }
        await SaveData(heatDevices);
        return heatDevices;
    }

    [HttpGet("day")]
    public async Task<List<HeatDevice>> GetDaysStats()
    {
        char[] chars = ['+', '-', '(', ')'];

        decimal? power;
        DateTime? time;

        foreach (var device in heatDevices)
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
            } else {
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
        return heatDevices;
    }

    [HttpGet("power")]
    public async Task<decimal?> GetPowerStats(string codeString) {
        char[] chars = ['+', '-', '(', ')'];
        decimal? power;
        bool containsAnyChar = chars.Any(c => codeString.Contains(c));
        if (containsAnyChar == false) {
            int code = int.Parse(codeString);
            var query = from dcValue in _context.TblDcvalues
                    join heatMetersLast in _context.CmpHeatMetersValLasts on dcValue.DevCompId equals heatMetersLast.DevCompId
                    where dcValue.DcvalueId == code
                    select new {
                        heatMetersLast.Power,
                        dcValue.Caption,
                        dcValue.UnitId
                    };
            var result = query.FirstOrDefault();
            power = result.Power;
            if (power != null) {
                if (!result.Caption.Contains("mw", StringComparison.CurrentCultureIgnoreCase) || (result.UnitId != 56)) {
                    power /= 1000;
                }
                power = Math.Round(power.Value, 1);
            }
            return power;
        } else {
            string[] strings = codeString.Split(chars);
            int[] powerCodes = new int[strings.Length];
            decimal[] powerValues = new decimal[strings.Length];

            for (int i = 0; i < powerCodes.Length; i++) {
                powerCodes[i] = int.Parse(strings[i]);
            }

            for (int i = 0; i < strings.Length; i++) {
                var query = from dcValue in _context.TblDcvalues
                            join heatMetersLast in _context.CmpHeatMetersValLasts on dcValue.DevCompId equals heatMetersLast.DevCompId
                            where dcValue.DcvalueId == powerCodes[i]
                            select new {
                                heatMetersLast.Power,
                                dcValue.Caption,
                                dcValue.UnitId
                            };
                var result = query.FirstOrDefault();
                power = result.Power;
                if (power != null) {
                    if (!result.Caption.Contains("mw", StringComparison.CurrentCultureIgnoreCase) || (result.UnitId != 56)) {
                        power /= 1000;
                    }
                    power = Math.Round(power.Value, 1);
                    powerValues[i] = (decimal)power;
                } else {
                    powerValues[i] = 0;
                }
            }

            string finalString = codeString;
            for (int i = 0; i < strings.Length; i++) {
                finalString = finalString.Replace(strings[i].ToString(), powerValues[i].ToString());
            }

            var answer = new DataTable().Compute(finalString, null);
            decimal finalPower = Convert.ToDecimal(answer);
            return finalPower;
        }
    }

    [HttpGet("heat")]
    public async Task<decimal?> GetTempStats(int code) {
        var query = from dcValue in _context.TblDcvalues
                    join heatMetersLast in _context.CmpHeatMetersValLasts on dcValue.DevCompId equals heatMetersLast.DevCompId
                    where dcValue.DcvalueId == code
                    select heatMetersLast.Tflow;
        decimal? result = query.FirstOrDefault();
        if (result != null) {
            result = Math.Round(result.Value, 1);
        }
        return result;
    }

    [HttpGet("p1")]
    public async Task<float?> GetP1Stats(int code) {
        var query = from dcValue in _context.TblDcvalues
                    join pressureMetersLast in _context.CmpPressuresValLasts on dcValue.DevCompId equals pressureMetersLast.DevCompId
                    where dcValue.DcvalueId == code
                    select pressureMetersLast.P00;
        float? result = query.FirstOrDefault();
        if (result != null) {
            decimal decimalResult = Math.Round((decimal)result, 1);
            result = (float?)decimalResult;
        }
        return result;
    }

    [HttpGet("p2")]
    public async Task<float?> GetP2Stats(int code) {
        var query = from dcValue in _context.TblDcvalues
                    join pressureMetersLast in _context.CmpPressuresValLasts on dcValue.DevCompId equals pressureMetersLast.DevCompId
                    where dcValue.DcvalueId == code
                    select pressureMetersLast.P01;
        float? result = query.FirstOrDefault();
        if (result != null) {
            decimal decimalResult = Math.Round((decimal)result, 1);
            result = (float?)decimalResult;
        }
        return result;
    }

    [HttpGet("save")]
    public async Task<ActionResult> SaveData(List<HeatDevice> devices) {
        string fileName = "devices.xlsx";
        var memoryStream = new MemoryStream();
        using (var workbook = new XLWorkbook()) {
            var worksheet = workbook.Worksheets.Add("Pirmas");

            worksheet.Cell(1, 1).Value = "AŠG";
            worksheet.Range("A1:D1").Merge();
            worksheet.Cell(2, 1).Value = "AB Panevėžio stiklas";
            worksheet.Range("A2:D2").Merge();
            worksheet.Cell(3, 1).Value = "Šilumos gamyba";
            worksheet.Cell(3, 2).Value = "Termofikacinio vandens";
            worksheet.Range("B3:D3").Merge();

            worksheet.Cell(4, 1).Value = "Mw";
            worksheet.Cell(4, 2).Value = "T1 (C)";
            worksheet.Cell(4, 3).Value = "P1 (bar)";
            worksheet.Cell(4, 4).Value = "P2 (bar)";

            worksheet.Cell(1, 5).Value = "NŠG";
            worksheet.Range("E1:H1").Merge();
            worksheet.Cell(2, 5).Value = "UAB Biokuro energija";
            worksheet.Range("E2:H2").Merge();
            worksheet.Cell(3, 5).Value = "Šilumos gamyba";
            worksheet.Cell(3, 6).Value = "Termofikacinio vandens";
            worksheet.Range("F3:H3").Merge();

            worksheet.Cell(4, 5).Value = "Mw";
            worksheet.Cell(4, 6).Value = "T1 (C)";
            worksheet.Cell(4, 7).Value = "P1 (bar)";
            worksheet.Cell(4, 8).Value = "P2 (bar)";

            worksheet.Cell(1, 9).Value = "AB Panevėžio energija konkurenciniai įrenginiai";
            worksheet.Range("I1:X1").Merge();
            worksheet.Cell(2, 9).Value = "PRK-1 GK Nr.6 ir Nr.7 kogeneracinis blokas";
            worksheet.Range("I2:L2").Merge();
            worksheet.Cell(3, 9).Value = "Šilumos gamyba";
            worksheet.Cell(3, 10).Value = "Termofikacinio vandens";
            worksheet.Range("J3:L3").Merge();

            worksheet.Cell(4, 9).Value = "Mw";
            worksheet.Cell(4, 10).Value = "T1 (C)";
            worksheet.Cell(4, 11).Value = "P1 (bar)";
            worksheet.Cell(4, 12).Value = "P2 (bar)";

            worksheet.Cell(2, 13).Value = "PRK-1 VŠK Nr.8 ir Nr.9 blokas";
            worksheet.Range("M2:P2").Merge();
            worksheet.Cell(3, 13).Value = "Šilumos gamyba";
            worksheet.Cell(3, 14).Value = "Termofikacinio vandens";
            worksheet.Range("N3:P3").Merge();

            worksheet.Cell(4, 13).Value = "Mw";
            worksheet.Cell(4, 14).Value = "T1 (C)";
            worksheet.Cell(4, 15).Value = "P1 (bar)";
            worksheet.Cell(4, 16).Value = "P2 (bar)";

            worksheet.Cell(2, 17).Value = "PEI katilinė VŠK Nr.1";
            worksheet.Range("Q2:T2").Merge();
            worksheet.Cell(3, 17).Value = "Šilumos gamyba";
            worksheet.Cell(3, 18).Value = "Termofikacinio vandens";
            worksheet.Range("R3:T3").Merge();

            worksheet.Cell(4, 17).Value = "Mw";
            worksheet.Cell(4, 18).Value = "T1 (C)";
            worksheet.Cell(4, 19).Value = "P1 (bar)";
            worksheet.Cell(4, 20).Value = "P2 (bar)";

            worksheet.Cell(2, 21).Value = "PRK-1 VŠK Nr.5";
            worksheet.Range("U2:X2").Merge();
            worksheet.Cell(3, 21).Value = "Šilumos gamyba";
            worksheet.Cell(3, 22).Value = "Termofikacinio vandens";
            worksheet.Range("V3:X3").Merge();

            worksheet.Cell(4, 21).Value = "Mw";
            worksheet.Cell(4, 22).Value = "T1 (C)";
            worksheet.Cell(4, 23).Value = "P1 (bar)";
            worksheet.Cell(4, 24).Value = "P2 (bar)";

            worksheet.Cell(1, 25).Value = "AB Panevėžio energija piko/rezervo įrenginiai";
            worksheet.Range("Y1:AB2").Merge();
            worksheet.Cell(3, 25).Value = "Šilumos gamyba";
            worksheet.Cell(3, 26).Value = "Termofikacinio vandens";
            worksheet.Range("Z3:AB3").Merge();

            worksheet.Cell(4, 25).Value = "Mw";
            worksheet.Cell(4, 26).Value = "T1 (C)";
            worksheet.Cell(4, 27).Value = "P1 (bar)";
            worksheet.Cell(4, 28).Value = "P2 (bar)";

            int index = 1;
            foreach (var device in devices) {
                if (device.Power == null)
                    worksheet.Cell(5, index).Value = "-";
                else
                    worksheet.Cell(5, index).Value = device.Power;
                index++;

                if (device.TFlow == null)
                    worksheet.Cell(5, index).Value = "-";
                else
                    worksheet.Cell(5, index).Value = device.TFlow;
                index++;

                if (device.P01 == null)
                    worksheet.Cell(5, index).Value = "-";
                else
                    worksheet.Cell(5, index).Value = device.P01;
                index++;

                if (device.P02 == null)
                    worksheet.Cell(5, index).Value = "-";
                else
                    worksheet.Cell(5, index).Value = device.P02;
                index++;
            }

            workbook.SaveAs(fileName);
        }

        memoryStream.Position = 0;
        return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
    }
}