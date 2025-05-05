namespace NutriSportPro.API.Models;

public class Nutrition : BaseEntity
{
    public double Calories { get; set; }
    public double Protein { get; set; }
    public double Carbohydrates { get; set; }
    public double Lipids { get; set; }
    public string? Food { get; set; }
    public required DateTime? Date { get; set; }
    public string? Notes { get; set; }
}
