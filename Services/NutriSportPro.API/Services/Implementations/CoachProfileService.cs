namespace NutriSportPro.API.Services.Implementations;

public class CoachProfileService : AsyncService<CoachProfile>, ICoachProfileService
{
    public CoachProfileService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
