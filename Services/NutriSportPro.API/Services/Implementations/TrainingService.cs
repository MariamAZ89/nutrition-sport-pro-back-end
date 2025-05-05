namespace NutriSportPro.API.Services.Implementations;

public class TrainingService : AsyncService<Training>, ITrainingService
{
    public TrainingService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
