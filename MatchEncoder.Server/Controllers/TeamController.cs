using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TeamController : ControllerBase
{
    private readonly TeamService _teamService;

    public TeamController(TeamService teamService)
    {
        _teamService = teamService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Team>>> GetAll()
    {
        return Ok(await _teamService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Team>> GetById(int id)
    {
        var team = await _teamService.GetByIdAsync(id);
        if (team == null) return NotFound();
        return Ok(team);
    }

    [HttpPost]
    public async Task<ActionResult<Team>> Create(Team team)
    {
        var createdTeam = await _teamService.CreateAsync(team);
        return CreatedAtAction(nameof(GetById), new { id = createdTeam.Id }, createdTeam);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Team team)
    {
        if (id != team.Id) return BadRequest();
        await _teamService.UpdateAsync(team);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _teamService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}
