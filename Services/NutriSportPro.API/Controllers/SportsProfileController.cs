namespace NutriSportPro.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SportsProfileController : ControllerBase
{
    private readonly ISportsProfileService sportsProfileService;

    public SportsProfileController(ISportsProfileService sportsProfileService)
    {
        this.sportsProfileService = sportsProfileService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllSportsProfiles()
    {
        var sportsProfiles = await sportsProfileService.GetAllAsync();
        return Ok(sportsProfiles);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSportsProfileById(int id)
    {
        var sportsProfile = await sportsProfileService.GetByIdAsync(id);
        if (sportsProfile == null)
        {
            return NotFound();
        }
        return Ok(sportsProfile);
    }
    [HttpPost]
    public async Task<IActionResult> CreateSportsProfile([FromBody] SportsProfileRequest sportsProfileRequest)
    {
        if (sportsProfileRequest == null)
        {
            return BadRequest("Invalid sports profile data.");
        }
        var sportsProfile = await sportsProfileService.AddAsync(new SportsProfile
        {
            Weight = sportsProfileRequest.Weight,
            Height = sportsProfileRequest.Height,
            Goals = sportsProfileRequest.Goals,
            Level = sportsProfileRequest.Level,
            UserId = Helper.GetConnectedUserId(User)!
        });
        return CreatedAtAction(nameof(GetSportsProfileById), new { id = sportsProfile.Id }, sportsProfile);
    }

}
