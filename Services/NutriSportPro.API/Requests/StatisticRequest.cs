namespace NutriSportPro.API.Requests;

public class StatisticRequest
{
    public int Id { get; set; }
    public double Weight { get; set; }
    public double MuscleMass { get; set; }
    public double FatMass { get; set; }
    public double HeartRate { get; set; }
    public required DateTime? Date { get; set; }
    public string? Notes { get; set; }
}
