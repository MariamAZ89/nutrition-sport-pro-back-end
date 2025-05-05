namespace NutriSportPro.API.Services.Implementations;

public class DietaryRecommendationService : AsyncService<DietaryRecommendation>, IDietaryRecommendationService
{
    public DietaryRecommendationService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
