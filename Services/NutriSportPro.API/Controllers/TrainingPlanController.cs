namespace NutriSportPro.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class TrainingPlanController : ControllerBase
{
    private readonly ITrainingPlanService _trainingPlanService;

    public TrainingPlanController(ITrainingPlanService trainingPlanService)
    {
        this._trainingPlanService = trainingPlanService;
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _trainingPlanService.GetAllAsync();
        if (result == null || !result.Any())
        {
            return NotFound("No training plans found.");
        }
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _trainingPlanService.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound($"Training plan with ID {id} not found.");
        }
        return Ok(result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] TrainingPlanRequest trainingPlan)
    {
        if (trainingPlan == null)
        {
            return BadRequest("Training plan data is invalid.");
        }

        var createdTrainingPlan = await _trainingPlanService.AddAsync(new TrainingPlan
        {
            Objective = trainingPlan.Objective,
            Name = trainingPlan.Name,
            Level = trainingPlan.Level,
            DurationWeeks = trainingPlan.DurationWeeks,
            UserId = Helper.GetConnectedUserId(User)!
        });
        return CreatedAtAction(nameof(GetById), new { id = createdTrainingPlan.Id }, createdTrainingPlan);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] TrainingPlanRequest trainingPlan)
    {
        if (trainingPlan == null || id != trainingPlan.Id)
        {
            return BadRequest("Training plan data is invalid or ID mismatch.");
        }
        var existingTrainingPlan = await _trainingPlanService.GetByIdAsync(id);
        if (existingTrainingPlan == null)
        {
            return NotFound($"Training plan with ID {id} not found.");
        }
        existingTrainingPlan.Objective = trainingPlan.Objective;
        existingTrainingPlan.Name = trainingPlan.Name;
        existingTrainingPlan.Level = trainingPlan.Level;
        existingTrainingPlan.DurationWeeks = trainingPlan.DurationWeeks;

        var updatedTrainingPlan = await _trainingPlanService.UpdateAsync(existingTrainingPlan);
        if (!updatedTrainingPlan)
        {
            return NotFound($"Training plan with ID {id} not found.");
        }

        return Ok(updatedTrainingPlan);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var isDeleted = await _trainingPlanService.DeleteAsync(id);
        if (!isDeleted)
        {
            return NotFound($"Training plan with ID {id} not found.");
        }

        return NoContent();
    }
}
