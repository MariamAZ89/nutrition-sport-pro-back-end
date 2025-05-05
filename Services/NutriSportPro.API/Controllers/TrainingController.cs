namespace NutriSportPro.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TrainingController : ControllerBase
{
    private readonly ITrainingService trainingService;

    public TrainingController(ITrainingService trainingService)
    {
        this.trainingService = trainingService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllTrainings()
    {
        var trainings = await trainingService.GetAllAsync();
        return Ok(trainings);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTrainingById(int id)
    {
        var training = await trainingService.GetByIdAsync(id);
        if (training == null)
        {
            return NotFound();
        }
        return Ok(training);
    }
    [HttpPost]
    public async Task<IActionResult> CreateTraining([FromBody] TrainingRequest trainingRequest)
    {
        if (trainingRequest == null)
        {
            return BadRequest("Invalid training data.");
        }
        var training = await trainingService.AddAsync(new Training
        {
            Duration = trainingRequest.Duration,
            Notes = trainingRequest.Notes,
            Date = trainingRequest.Date ?? DateTime.UtcNow,
            UserId = Helper.GetConnectedUserId(User)!
        });
        return CreatedAtAction(nameof(GetTrainingById), new { id = training.Id }, training);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTraining(int id, [FromBody] TrainingRequest trainingRequest)
    {
        if (trainingRequest == null)
        {
            return BadRequest("Invalid training data.");
        }
        var training = await trainingService.GetByIdAsync(id);
        if (training == null)
        {
            return NotFound();
        }
        training.Duration = trainingRequest.Duration;
        training.Notes = trainingRequest.Notes;
        training.Date = trainingRequest.Date ?? DateTime.UtcNow;
        await trainingService.UpdateAsync(training);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTraining(int id)
    {
        var training = await trainingService.GetByIdAsync(id);
        if (training == null)
        {
            return NotFound();
        }
        var isDeleted = await trainingService.DeleteAsync(id);
        if (!isDeleted)
        {
            return BadRequest("Failed to delete the training.");
        }
        return NoContent();
    }
}
