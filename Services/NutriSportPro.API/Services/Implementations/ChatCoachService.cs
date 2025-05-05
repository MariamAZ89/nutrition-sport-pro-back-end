namespace NutriSportPro.API.Services.Implementations;

public class ChatCoachService : AsyncService<ChatCoach>, IChatCoachService
{
    public ChatCoachService(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
}
