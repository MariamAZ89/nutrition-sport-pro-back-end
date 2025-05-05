namespace NutriSportPro.API.Requests;

public class TrainingPlanRequest
{
    public int Id { get; set; }
    public string Objective { get; set; } = null!;
    public string Name { get; set; } = null!;
    public TrainingPlansLevelEnum Level { get; set; }
    public int DurationWeeks { get; set; }
}
