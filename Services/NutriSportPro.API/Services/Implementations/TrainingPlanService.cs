namespace NutriSportPro.API.Services.Implementations;

public class TrainingPlanService : AsyncService<TrainingPlan>, ITrainingPlanService
{
    public TrainingPlanService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
