using System.ComponentModel.DataAnnotations;

namespace NutriSportPro.API.Requests;

public class CoachProfileRequest
{
    public int Id { get; set; } = 0;
    [Required]
    public required byte[]? Certification { get; set; }
}
