namespace NutriSportPro.API.Services.Implementations;

public class ExerciseService : AsyncService<Exercise>, IExerciseService
{
    public ExerciseService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
