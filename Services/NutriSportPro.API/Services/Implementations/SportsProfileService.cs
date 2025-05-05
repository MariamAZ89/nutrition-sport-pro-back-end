namespace NutriSportPro.API.Services.Implementations;

public class SportsProfileService : AsyncService<SportsProfile>, ISportsProfileService
{
    public SportsProfileService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
