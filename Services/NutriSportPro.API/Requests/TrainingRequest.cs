namespace NutriSportPro.API.Requests;

public class TrainingRequest
{
    public double Duration { get; set; }
    public string? Notes { get; set; }
    public required DateTime? Date { get; set; }
}
