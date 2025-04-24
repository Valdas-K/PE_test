namespace PE_test.Server; 

public class HeatDevice {
    public required int ID { get; set; }
    public required string Title { get; set; }
    public required string PowerCode { get; set; }
    public required int TempCode { get; set; }
    public required int P1Code { get; set; }
    public required int P2Code { get; set; }
    public decimal? Power { get; set; }
    public decimal? TFlow { get; set; }
    public float? P01 { get; set; }
    public float? P02 { get; set; }

    //Pradinė informacija
    public static List<HeatDevice> heatDevices = [
        new HeatDevice { ID = 1, Title = "AB Panevėžio stiklas", PowerCode = "94467", TempCode = 94462, P1Code = 94457, P2Code = 94458 },
        new HeatDevice { ID = 2, Title = "UAB Biokuro energija", PowerCode = "69509", TempCode = 69361, P1Code = 69488, P2Code = 69489 },
        new HeatDevice { ID = 3, Title = "PRK-1 GK Nr.6 ir Nr.7 kogeneracinis blokas", PowerCode = "41908-66239+49217+76713+76719-49209-49219", TempCode = 69361, P1Code = 69488, P2Code = 69489 },
        new HeatDevice { ID = 4, Title = "PRK-1 VŠK Nr.8 ir Nr.9 blokas", PowerCode = "66239+49217+76713+76719", TempCode = 41905, P1Code = 41901, P2Code = 41902 },
        new HeatDevice { ID = 5, Title = "PEI katilinė VŠK Nr.1", PowerCode = "89652", TempCode = 71719, P1Code = 71717, P2Code = 71718 },
        new HeatDevice { ID = 6, Title = "PRK-1 VŠK Nr.5", PowerCode = "49209", TempCode = 41905, P1Code = 41901, P2Code = 41902 },
        new HeatDevice { ID = 7, Title = "AB Panevėžio energija piko/rezervo įrenginiai", PowerCode = "89875-89652+49219", TempCode = 71719, P1Code = 71717, P2Code = 71718 },
    ];
}