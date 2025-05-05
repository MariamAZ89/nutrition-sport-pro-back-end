namespace NutriSportPro.API.Models;

public class TrainingPlan : BaseEntity
{
    public string Objective { get; set; } = null!;
    public string Name { get; set; } = null!;
    public TrainingPlansLevelEnum Level { get; set; }
    public int DurationWeeks { get; set; }
}
