namespace NutriSportPro.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChatCoachController : ControllerBase
{
    private readonly IChatCoachService chatCoachService;

    public ChatCoachController(IChatCoachService chatCoachService)
    {
        this.chatCoachService = chatCoachService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllChatCoaches()
    {
        var chatCoaches = await chatCoachService.GetAllAsync();
        return Ok(chatCoaches);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetChatCoachById(int id)
    {
        var chatCoach = await chatCoachService.GetByIdAsync(id);
        if (chatCoach == null)
        {
            return NotFound();
        }
        return Ok(chatCoach);
    }
    [HttpPost]
    public async Task<IActionResult> CreateChatCoach([FromBody] ChatCoachRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var chatCoach = new ChatCoach
        {
            SenderId = Helper.GetConnectedUserId(User)!,
            ReceiverId = request.ReceiverId,
            Message = request.Message
        };
        await chatCoachService.AddAsync(chatCoach);
        return CreatedAtAction(nameof(GetChatCoachById), new { id = chatCoach.Id }, chatCoach);
    }
}
