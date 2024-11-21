using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class MatchController : ControllerBase
{
    private readonly MatchService _matchService;

    public MatchController(MatchService matchService)
    {
        _matchService = matchService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Match>>> GetAll()
    {
        return Ok(await _matchService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Match>> GetById(int id)
    {
        var match = await _matchService.GetByIdAsync(id);
        if (match == null) return NotFound();
        return Ok(match);
    }

    [HttpPost]
    public async Task<ActionResult<Match>> Create(Match match)
    {
        var createdMatch = await _matchService.CreateAsync(match);
        return CreatedAtAction(nameof(GetById), new { id = createdMatch.Id }, createdMatch);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Match match)
    {
        if (id != match.Id) return BadRequest();
        await _matchService.UpdateAsync(match);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _matchService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}
