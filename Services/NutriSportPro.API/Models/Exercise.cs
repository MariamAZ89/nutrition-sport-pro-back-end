namespace NutriSportPro.API.Models;

public class Exercise
{
    public int Id { get; set; }
    public double Duration { get; set; }
    public int Repetitions { get; set; }
    public int Sets { get; set; }
    public double Weight { get; set; }
    public int? TrainingId { get; set; }
    public Training? Training { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
