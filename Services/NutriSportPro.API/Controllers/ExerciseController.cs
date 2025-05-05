namespace NutriSportPro.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseService exerciseService;
    private readonly ITrainingService trainingService;

    public ExerciseController(IExerciseService exerciseService, ITrainingService trainingService)
    {
        this.exerciseService = exerciseService;
        this.trainingService = trainingService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllExercises()
    {
        var exercises = await exerciseService.GetAllAsync();
        return Ok(exercises);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetExerciseById(int id)
    {
        var exercise = await exerciseService.GetByIdAsync(id);
        if (exercise == null)
        {
            return NotFound();
        }
        return Ok(exercise);
    }
    [HttpPost]
    public async Task<IActionResult> CreateExercise([FromBody] ExerciseRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var training = await trainingService.GetByIdAsync(request.TrainingId!.Value);
        if (training == null)
        {
            return NotFound($"Training with ID {request.TrainingId} not found.");
        }
        var exercise = new Exercise
        {
            Duration = request.Duration,
            Repetitions = request.Repetitions,
            Sets = request.Sets,
            Weight = request.Weight,
            TrainingId = request.TrainingId
        };
        await exerciseService.AddAsync(exercise);
        return CreatedAtAction(nameof(GetExerciseById), new { id = exercise.Id }, exercise);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateExercise(int id, [FromBody] ExerciseRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var exercise = await exerciseService.GetByIdAsync(id);
        if (exercise == null)
        {
            return NotFound();
        }
        var training = await trainingService.GetByIdAsync(request.TrainingId!.Value);
        if (training == null)
        {
            return NotFound($"Training with ID {request.TrainingId} not found.");
        }
        exercise.Duration = request.Duration;
        exercise.Repetitions = request.Repetitions;
        exercise.Sets = request.Sets;
        exercise.Weight = request.Weight;
        exercise.TrainingId = request.TrainingId;
        await exerciseService.UpdateAsync(exercise);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExercise(int id)
    {
        var exercise = await exerciseService.GetByIdAsync(id);
        if (exercise == null)
        {
            return NotFound();
        }
        var isDeletd = await exerciseService.DeleteAsync(id);
        if (!isDeletd)
        {
            return BadRequest("Exercise could not be deleted.");
        }
        return NoContent();

    }
}
