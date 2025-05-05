namespace NutriSportPro.API.Requests;

public class FoodProgramRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string GenerationAI { get; set; } = null!;
}
