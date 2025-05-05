namespace NutriSportPro.API.Models;

public class SportsProfile: BaseEntity
{
    public double Weight { get; set; }
    public double Height { get; set; }
    public string? Goals { get; set; }
    public SportsProfileTypeEnum Level { get; set; }
}
