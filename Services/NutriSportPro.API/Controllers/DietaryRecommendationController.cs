namespace NutriSportPro.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DietaryRecommendationController : ControllerBase
{
    private readonly IDietaryRecommendationService dietaryRecommendationService;

    public DietaryRecommendationController(IDietaryRecommendationService dietaryRecommendationService)
    {
        this.dietaryRecommendationService = dietaryRecommendationService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllDietaryRecommendations()
    {
        var dietaryRecommendations = await dietaryRecommendationService.GetAllAsync();
        return Ok(dietaryRecommendations);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetDietaryRecommendationById(int id)
    {
        var dietaryRecommendation = await dietaryRecommendationService.GetByIdAsync(id);
        if (dietaryRecommendation == null)
        {
            return NotFound();
        }
        return Ok(dietaryRecommendation);
    }
    [HttpPost]
    public async Task<IActionResult> CreateDietaryRecommendation([FromBody] DietaryRecommendationRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var dietaryRecommendation = new DietaryRecommendation
        {
            Text = request.Text,
            UserId = Helper.GetConnectedUserId(User)!
        };
        await dietaryRecommendationService.AddAsync(dietaryRecommendation);
        return CreatedAtAction(nameof(GetDietaryRecommendationById), new { id = dietaryRecommendation.Id }, dietaryRecommendation);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDietaryRecommendation(int id, [FromBody] DietaryRecommendationRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var dietaryRecommendation = await dietaryRecommendationService.GetByIdAsync(id);
        if (dietaryRecommendation == null)
        {
            return NotFound();
        }
        dietaryRecommendation.Text = request.Text;
        await dietaryRecommendationService.UpdateAsync(dietaryRecommendation);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDietaryRecommendation(int id)
    {
        var dietaryRecommendation = await dietaryRecommendationService.GetByIdAsync(id);
        if (dietaryRecommendation == null)
        {
            return NotFound();
        }
        var isDelted = await dietaryRecommendationService.DeleteAsync(id);
        if (!isDelted)
        {
            return BadRequest("Failed to delete the dietary recommendation.");
        }
        return NoContent();
    }
}
