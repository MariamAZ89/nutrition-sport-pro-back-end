namespace NutriSportPro.API.Models;

public class Training : BaseEntity
{
    public double Duration { get; set; }
    public string? Notes { get; set; }
    public required DateTime? Date { get; set; }
    public virtual ICollection<Exercise> Exercises { get; set; } = default!;
}