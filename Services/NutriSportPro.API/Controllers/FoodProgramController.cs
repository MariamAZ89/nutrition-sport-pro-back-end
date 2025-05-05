namespace NutriSportPro.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FoodProgramController : ControllerBase
{
    private readonly IFoodProgramService foodProgramService;

    public FoodProgramController(IFoodProgramService foodProgramService)
    {
        this.foodProgramService = foodProgramService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllFoodPrograms()
    {
        var foodPrograms = await foodProgramService.GetAllAsync();
        return Ok(foodPrograms);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetFoodProgramById(int id)
    {
        var foodProgram = await foodProgramService.GetByIdAsync(id);
        if (foodProgram == null)
        {
            return NotFound();
        }
        return Ok(foodProgram);
    }
    [HttpPost]
    public async Task<IActionResult> CreateFoodProgram([FromBody] FoodProgramRequest foodProgramRequest)
    {
        if (foodProgramRequest == null)
        {
            return BadRequest("Invalid food program data.");
        }
        var foodProgram = await foodProgramService.AddAsync(new FoodProgram
        {
            Name = foodProgramRequest.Name,
            Description = foodProgramRequest.Description,
            UserId = Helper.GetConnectedUserId(User)!,
            GenerationAI = foodProgramRequest.GenerationAI,
        });
        return CreatedAtAction(nameof(GetFoodProgramById), new { id = foodProgram.Id }, foodProgram);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFoodProgram(int id, [FromBody] FoodProgramRequest foodProgramRequest)
    {
        if (foodProgramRequest == null)
        {
            return BadRequest("Invalid food program data.");
        }
        var foodProgram = await foodProgramService.GetByIdAsync(id);
        if (foodProgram == null)
        {
            return NotFound();
        }
        foodProgram.Name = foodProgramRequest.Name;
        foodProgram.Description = foodProgramRequest.Description;
        foodProgram.GenerationAI = foodProgramRequest.GenerationAI;
        await foodProgramService.UpdateAsync(foodProgram);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFoodProgram(int id)
    {
        var foodProgram = await foodProgramService.GetByIdAsync(id);
        if (foodProgram == null)
        {
            return NotFound();
        }
        var isDeletd = await foodProgramService.DeleteAsync(id);
        if (!isDeletd)
        {
            return NotFound($"Food program with ID {id} not found.");
        }
        return NoContent();
    }
}
