namespace PE_test.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LastDayStatsController : ControllerBase {
    private readonly ApplicationDbContext _context;
    public LastDayStatsController(ApplicationDbContext context) {
        _context = context;
    }

    [HttpGet]
    public async Task<List<HeatDevice>> GetDayStats() {
        //Kiekvienam sąrašo įrašui yra randamos galios reikšmės ir paleidžiama saugojimo funkcija
        foreach (var device in HeatDevice.heatDevices) {
            device.Volume = await GetDaysVolume(device.PowerCode);
        }
        await SaveDayData(HeatDevice.heatDevices);
        return HeatDevice.heatDevices;
    }

    [HttpGet("day-volume-query")]
    public decimal? DayPowerQuery(string powerCodeString) {
        //Vykdoma užklausa
        var query = from dcValue in _context.TblDcvalues
                    join heatmeters in _context.CmpHeatMetersVals on dcValue.DevCompId equals heatmeters.DevCompId
                    where dcValue.DcvalueId == int.Parse(powerCodeString) &&
                        heatmeters.RecordTime >= new DateTime(2024, 05, 01, 07, 00, 00) &&
                        heatmeters.RecordTime <= new DateTime(2024, 05, 01, 08, 00, 00)
                    select new {
                        heatmeters.Volume,
                        dcValue.Caption,
                        dcValue.UnitId
                    };

        //Gaunamas rezultatas, kuris yra patikrinamas ir grąžinamas
        decimal? volume = null;
        var result = query.FirstOrDefault();
        if (result != null) {
            volume = result.Volume;
            if (!result.Caption.Contains("mwh", StringComparison.CurrentCultureIgnoreCase) && (result.UnitId != 14)) {
                volume /= 1000;
            }
        }
        return volume;
    }

    [HttpGet("day-volume")]
    public async Task<decimal?> GetDaysVolume(string powerCode) {
        //Tikrinami simboliai
        char[] chars = ['+', '-'];
        decimal? volume;
        bool containsChar = chars.Any(c => powerCode.Contains(c));
        if (containsChar == false) {
            //Jei nėra jokio papildomo simbolio, yra gaunama galios reikšmė
            volume = DayPowerQuery(powerCode);
        } else {
            //Jei yra papildomas simbolis, yra randami visi atskiri kodai
            string[] strings = powerCode.Split(chars);
            decimal[] volumeValues = new decimal[strings.Length];
            string finalString = powerCode;

            //Kiekvienam kodui yra gaunama galios reikšmė
            for (int i = 0; i < strings.Length; i++) {
                volumeValues[i] = DayPowerQuery(strings[i]).GetValueOrDefault();
            }

            //Į originalią formulę yra įterpiamos galios reikšmės vieotje kodų
            for (int i = 0; i < strings.Length; i++) {
                finalString = finalString.Replace(strings[i], volumeValues[i].ToString());
            }

            //Atliekama funkcija, kuri tekstą paverčia matematine formule ir apskaičiuoja bendrą galios reikšmę 
            volume = Convert.ToDecimal(new DataTable().Compute(finalString, null));
        }
        return volume;
    }

    [HttpGet("save-day-data")]
    public async Task<ActionResult> SaveDayData(List<HeatDevice> devices) {
        //Sukuriamas Excel failas ir failo pavadinimas
        var memoryStream = new MemoryStream();
        DateTime currentDate = DateTime.Now;
        string fileName = "LastDay_" + currentDate.ToString("yyyy-MM-dd_HH-mm-ss.fff") + ".xlsx";
        using (var workbook = new XLWorkbook()) {
            //Sukuriamas darbo lapas
            var worksheet = workbook.Worksheets.Add("Pirmas");

            //Sujungiami informacijos lengeliai
            worksheet.Cell(1, 1).Value = "Data";
            worksheet.Range("A1:A3").Merge();
            worksheet.Cell(1, 2).Value = "Laikas";
            worksheet.Range("B1:C3").Merge();

            //Šilumos gamintojų tipai ir sujungiami langeliai
            worksheet.Cell(1, 4).Value = "AŠG";
            worksheet.Cell(1, 5).Value = "NŠG";
            worksheet.Cell(1, 6).Value = "AB Panevėžio energija konkurenciniai įrenginiai";
            worksheet.Range("F1:I1").Merge();

            //Katilinių pavadinimai ir sujungiami langeliai
            worksheet.Cell(2, 4).Value = "AB Panevėžio stiklas";
            worksheet.Cell(2, 5).Value = "UAB Biokuro energija";
            worksheet.Cell(2, 6).Value = "PRK-1 GK Nr.6 ir Nr.7 kogeneracinis blokas";
            worksheet.Cell(2, 7).Value = "PRK-1 VŠK Nr.8 ir Nr.9 blokas";
            worksheet.Cell(2, 8).Value = "PEI katilinė VŠK Nr.1";
            worksheet.Cell(2, 9).Value = "PRK-1 VŠK Nr.5";
            worksheet.Cell(1, 10).Value = "AB Panevėžio energija piko/rezervo įrenginiai";
            worksheet.Range("J1:J2").Merge();

            //Įdedami duomenys ir kita pasikartojanti informacija
            //index - stulpelio numeris
            int index = 4;
            foreach (var device in devices) {
                for(int i = 1; i <= 24; i++) {
                    //Informacijos laukai
                    worksheet.Cell(i + 3, 1).Value = DateTime.Now.ToString("yyyy-MM-dd");
                    worksheet.Cell(i + 3, 2).Value = "07-08";
                    worksheet.Cell(i + 3, 3).Value = i;

                    //VOLUME
                    if (device.Volume == null)
                        worksheet.Cell(i + 3, index).Value = "-";
                    else
                        worksheet.Cell(i + 3, index).Value = device.Volume;
                }
                worksheet.Cell(3, index).Value = "Šilumos gamyba (Mwh)";
                index++;
            }

            //Pridedami lentelės stiliai: linijų plotis, teksto lygiavimas, numerių formatas, pastorintas šriftas ir automatiniai langelių pločiai
            var allCells = worksheet.RangeUsed().Style;
            allCells.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            allCells.Alignment.Vertical = XLAlignmentVerticalValues.Top;
            allCells.NumberFormat.Format = "0.0";
            allCells.Alignment.WrapText = true;
            worksheet.Range(1, 1, 27, index - 1).Style.Border.OutsideBorder = XLBorderStyleValues.Hair;
            worksheet.Range(1, 1, 27, index - 1).Style.Border.InsideBorder = XLBorderStyleValues.Hair;
            worksheet.Range(1, 1, 2, index - 1).Style.Font.Bold = true;
            worksheet.Columns().AdjustToContents(10.0, 25.0);

            //Išsaugomas failas
            workbook.SaveAs(fileName);
        }
        memoryStream.Position = 0;
        ExportLastDayStats(fileName);
        return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
    }

    [HttpGet("export")]
    public void ExportLastDayStats(string fileName) {
        //Kintamieji
        //Naudojamas Rebex Tiny FTP Server
        string ftpServer = "ftp://localhost";
        string username = "tester";
        string password = "password";
        string projectFolder = AppDomain.CurrentDomain.BaseDirectory;
        projectFolder = Directory.GetParent(Directory.GetParent(projectFolder).FullName).FullName;
        projectFolder = Directory.GetParent(Directory.GetParent(projectFolder).FullName).FullName;
        string localFilePath = Path.Combine(projectFolder, fileName);

        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpServer + "/" + fileName);
        request.Method = WebRequestMethods.Ftp.UploadFile;
        request.Credentials = new NetworkCredential(username, password);
        byte[] fileContents = System.IO.File.ReadAllBytes(localFilePath);
        request.ContentLength = fileContents.Length;

        //Siunčiama ataskaita
        using Stream requestStream = request.GetRequestStream();
        requestStream.Write(fileContents, 0, fileContents.Length);
    }
}