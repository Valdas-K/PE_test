public class HeatDevice {
    public int ID { get; set; }
    public required string Title { get; set; }
    public required string PowerCode { get; set; }
    public required int TempCode { get; set; }
    public required int P1Code { get; set; }
    public required int P2Code { get; set; }
    public decimal? Power { get; set; }
    public decimal? TFlow { get; set; }
    public float? P01 { get; set; }
    public float? P02 { get; set; }
}