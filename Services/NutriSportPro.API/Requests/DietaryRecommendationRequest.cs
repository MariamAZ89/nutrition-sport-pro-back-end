using System.ComponentModel.DataAnnotations;

namespace NutriSportPro.API.Requests;

public class DietaryRecommendationRequest
{
    public int Id { get; set; }
    [Required]
    public string Text { get; set; } = null!;
}
