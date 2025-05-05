namespace NutriSportPro.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NutritionController : ControllerBase
{
    private readonly INutritionService nutritionService;

    public NutritionController(INutritionService nutritionService)
    {
        this.nutritionService = nutritionService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllNutritionPlans()
    {
        var nutritionPlans = await nutritionService.GetAllAsync();
        return Ok(nutritionPlans);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetNutritionPlanById(int id)
    {
        var nutritionPlan = await nutritionService.GetByIdAsync(id);
        if (nutritionPlan == null)
        {
            return NotFound();
        }
        return Ok(nutritionPlan);
    }
    [HttpPost]
    public async Task<IActionResult> CreateNutritionPlan([FromBody] NutritionRequest nutritionRequest)
    {
        if (nutritionRequest == null)
        {
            return BadRequest("Invalid nutrition plan data.");
        }
        var nutritionPlan = await nutritionService.AddAsync(new Nutrition
        {
            Calories = nutritionRequest.Calories,
            Carbohydrates = nutritionRequest.Carbohydrates,
            Date = nutritionRequest.Date ?? DateTime.UtcNow,
            UserId = Helper.GetConnectedUserId(User)!,
            Protein = nutritionRequest.Protein,
            Food = nutritionRequest.Food,
            Lipids = nutritionRequest.Lipids,
            Notes = nutritionRequest.Notes
        });
        return CreatedAtAction(nameof(GetNutritionPlanById), new { id = nutritionPlan.Id }, nutritionPlan);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNutritionPlan(int id, [FromBody] NutritionRequest nutritionRequest)
    {
        if (nutritionRequest == null)
        {
            return BadRequest("Invalid nutrition plan data.");
        }
        var nutritionPlan = await nutritionService.GetByIdAsync(id);
        if (nutritionPlan == null)
        {
            return NotFound();
        }
        nutritionPlan.Calories = nutritionRequest.Calories;
        nutritionPlan.Carbohydrates = nutritionRequest.Carbohydrates;
        nutritionPlan.Date = nutritionRequest.Date ?? DateTime.UtcNow;
        nutritionPlan.Protein = nutritionRequest.Protein;
        nutritionPlan.Food = nutritionRequest.Food;
        nutritionPlan.Lipids = nutritionRequest.Lipids;
        nutritionPlan.Notes = nutritionRequest.Notes;
        await nutritionService.UpdateAsync(nutritionPlan);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNutritionPlan(int id)
    {
        var nutritionPlan = await nutritionService.GetByIdAsync(id);
        if (nutritionPlan == null)
        {
            return NotFound();
        }
        var isDeleted = await nutritionService.DeleteAsync(id);
        if (!isDeleted)
        {
            return NotFound($"Nutrition plan with ID {id} not found.");
        }
        return NoContent();
    }
}
