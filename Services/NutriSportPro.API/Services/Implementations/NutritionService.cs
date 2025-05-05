namespace NutriSportPro.API.Services.Implementations;

public class NutritionService : AsyncService<Nutrition>, INutritionService
{
    public NutritionService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
