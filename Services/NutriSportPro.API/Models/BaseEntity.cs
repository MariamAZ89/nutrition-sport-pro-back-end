namespace NutriSportPro.API.Models;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public required string UserId { get; set; }
    public ApplicationUser? User { get; set; }
}
