using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<IActionResult> GetAll()
    {
        var teams = await _teamService.GetAllAsync();
        var teamDtos = teams.Select(t => new
        {
            id = t.Id,
            name = t.Name
        }).ToList();
        return Ok(teamDtos);
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

    [HttpGet("{id}/Player")]
    public async Task<IActionResult> GetPlayersByTeamId(int id)
    {
        var players = await _teamService.GetPlayersByTeamIdAsync(id);

        if (players == null || !players.Any())
            return NotFound(new { message = $"No players found for team with ID {id}" });

        var playerDtos = players.Select(p => new
        {
            id = p.Id,
            name = p.Name,
            number = p.Number, 
            isCaptain = p.IsCaptain    
        }).ToList();

        return Ok(playerDtos);
    }
}
