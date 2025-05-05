namespace NutriSportPro.API.Models;

public class FoodProgram : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string GenerationAI { get; set; } = null!;
}
