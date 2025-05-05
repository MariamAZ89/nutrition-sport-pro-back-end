namespace NutriSportPro.API.Services.Implementations;

public class StatisticService : AsyncService<Statistic>, IStatisticService
{
    public StatisticService(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
