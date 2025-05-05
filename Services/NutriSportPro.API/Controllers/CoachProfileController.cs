namespace NutriSportPro.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoachProfileController : ControllerBase
{
    private readonly ICoachProfileService coachProfileService;

    public CoachProfileController(ICoachProfileService coachProfileService)
    {
        this.coachProfileService = coachProfileService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllCoachProfiles()
    {
        var coachProfiles = await coachProfileService.GetAllAsync();
        return Ok(coachProfiles);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCoachProfileById(int id)
    {
        var coachProfile = await coachProfileService.GetByIdAsync(id);
        if (coachProfile == null)
        {
            return NotFound();
        }
        return Ok(coachProfile);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCoachProfile([FromBody] CoachProfileRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var coachProfile = new CoachProfile
        {
            UserId = Helper.GetConnectedUserId(User)!,
            Certification = request.Certification
        };
        await coachProfileService.AddAsync(coachProfile);
        return CreatedAtAction(nameof(GetCoachProfileById), new { id = coachProfile.Id }, coachProfile);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCoachProfile(int id, [FromBody] CoachProfileRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var coachProfile = await coachProfileService.GetByIdAsync(id);
        if (coachProfile == null)
        {
            return NotFound();
        }
        coachProfile.Certification = request.Certification;
        coachProfile.UpdatedAt = DateTime.UtcNow;
        await coachProfileService.UpdateAsync(coachProfile);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCoachProfile(int id)
    {
        var coachProfile = await coachProfileService.GetByIdAsync(id);
        if (coachProfile == null)
        {
            return NotFound();
        }
        bool isDeleted = await coachProfileService.DeleteAsync(id);
        if (!isDeleted)
        {
            return BadRequest("Failed to delete the coach profile.");
        }
        return NoContent();
    }
}
