namespace NutriSportPro.API.Services.Implementations;

public class FoodProgramService : AsyncService<FoodProgram>, IFoodProgramService
{
    public FoodProgramService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
