namespace NutriSportPro.API.Requests;

public class SportsProfileRequest
{
    public int Id { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public string? Goals { get; set; }
    public SportsProfileTypeEnum Level { get; set; }
}
