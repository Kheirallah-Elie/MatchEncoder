using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PlayerService : Iservice<Player>
{
    private readonly MatchDbContext _context;

    public PlayerService(MatchDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Player>> GetAllAsync()
    {
        return await _context.Players.Include(p => p.Team).ToListAsync(); // List of players of each Team
    }

    public async Task<Player> GetByIdAsync(int id)
    {
        return await _context.Players.Include(p => p.Team).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Player> CreateAsync(Player player)
    {
        _context.Players.Add(player);
        await _context.SaveChangesAsync();
        return player;
    }

    public async Task<Player> UpdateAsync(Player player)
    {
        _context.Players.Update(player);
        await _context.SaveChangesAsync();
        return player;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var player = await _context.Players.FindAsync(id);
        if (player == null) return false;

        _context.Players.Remove(player);
        await _context.SaveChangesAsync();
        return true;
    }
}
