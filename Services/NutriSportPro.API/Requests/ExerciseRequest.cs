using System.ComponentModel.DataAnnotations;

namespace NutriSportPro.API.Requests;

public class ExerciseRequest
{
    public int Id { get; set; }
    public double Duration { get; set; }
    public int Repetitions { get; set; }
    public int Sets { get; set; }
    public double Weight { get; set; }
    [Required]
    public int? TrainingId { get; set; }
}
