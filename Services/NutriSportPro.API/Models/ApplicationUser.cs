namespace NutriSportPro.API.Models;

public class ApplicationUser : IdentityUser
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public virtual ICollection<SportsProfile> SportsProfiles { get; set; } = default!;
    public virtual ICollection<Training> Training { get; set; } = default!;
    public virtual ICollection<DietaryRecommendation> DietaryRecommendations { get; set; } = default!;
    public virtual ICollection<TrainingPlan> TrainingPlans { get; set; } = default!;
    public virtual ICollection<Nutrition> Nutritions { get; set; } = default!;
    public virtual ICollection<Statistic> Statistics { get; set; } = default!;
    public virtual ICollection<FoodProgram> FoodPrograms { get; set; } = default!;
    public virtual ICollection<ChatCoach> SentMessages { get; set; } = default!;
    public virtual ICollection<ChatCoach> ReceivedMessages { get; set; } = default!;
    public virtual CoachProfile?  CoachProfile { get; set; }
    public virtual int? CoachProfileId { get; set; }
}
