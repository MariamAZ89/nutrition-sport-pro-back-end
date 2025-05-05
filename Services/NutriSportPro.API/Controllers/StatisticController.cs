namespace NutriSportPro.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatisticController : ControllerBase
{
    private readonly IStatisticService statisticService;

    public StatisticController(IStatisticService statisticService)
    {
        this.statisticService = statisticService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStatistics()
    {
        var statistics = await statisticService.GetAllAsync();
        return Ok(statistics);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStatisticById(int id)
    {
        var statistic = await statisticService.GetByIdAsync(id);
        if (statistic == null)
        {
            return NotFound();
        }
        return Ok(statistic);
    }

    [HttpPost]
    public async Task<IActionResult> AddStatistic([FromBody] StatisticRequest statisticRequest)
    {
        if (statisticRequest == null)
        {
            return BadRequest("Statistic data is invalid.");
        }

        var statistic = new Statistic
        {
            Weight = statisticRequest.Weight,
            MuscleMass = statisticRequest.MuscleMass,
            FatMass = statisticRequest.FatMass,
            HeartRate = statisticRequest.HeartRate,
            Date = statisticRequest.Date,
            Notes = statisticRequest.Notes,
            UserId = Helper.GetConnectedUserId(User)!
        };

        var createdStatistic = await statisticService.AddAsync(statistic);
        return CreatedAtAction(nameof(GetStatisticById), new { id = createdStatistic.Id }, createdStatistic);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStatistic(int id, [FromBody] StatisticRequest statisticRequest)
    {
        if (statisticRequest == null)
        {
            return BadRequest("Statistic data is invalid.");
        }
        var existingStatistic = await statisticService.GetByIdAsync(id);
        if (existingStatistic == null)
        {
            return NotFound($"Statistic with ID {id} not found.");
        }

        existingStatistic.Weight = statisticRequest.Weight;
        existingStatistic.MuscleMass = statisticRequest.MuscleMass;
        existingStatistic.FatMass = statisticRequest.FatMass;
        existingStatistic.HeartRate = statisticRequest.HeartRate;
        existingStatistic.Date = statisticRequest.Date;
        existingStatistic.Notes = statisticRequest.Notes;

        var updatedStatistic = await statisticService.UpdateAsync(existingStatistic);
        if (!updatedStatistic)
        {
            return NotFound($"Statistic with ID {id} not found.");
        }

        return Ok(updatedStatistic);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStatistic(int id)
    {
        var isDeleted = await statisticService.DeleteAsync(id);
        if (!isDeleted)
        {
            return NotFound($"Statistic with ID {id} not found.");
        }

        return NoContent();
    }
}
