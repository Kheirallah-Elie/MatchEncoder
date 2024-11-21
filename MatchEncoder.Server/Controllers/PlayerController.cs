using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PlayerController : ControllerBase
{
    private readonly PlayerService _playerService;

    public PlayerController(PlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Player>>> GetAll()
    {
        return Ok(await _playerService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Player>> GetById(int id)
    {
        var player = await _playerService.GetByIdAsync(id);
        if (player == null) return NotFound();
        return Ok(player);
    }

    [HttpPost]
    public async Task<ActionResult<Player>> Create(Player player)
    {
        var createdPlayer = await _playerService.CreateAsync(player);
        return CreatedAtAction(nameof(GetById), new { id = createdPlayer.Id }, createdPlayer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Player player)
    {
        if (id != player.Id) return BadRequest();
        await _playerService.UpdateAsync(player);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _playerService.DeleteAsync(id);
        if (!result) return NotFound();
        return NoContent();
    }
}
