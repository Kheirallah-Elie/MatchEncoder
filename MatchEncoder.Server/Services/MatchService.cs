using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class MatchService : Iservice<Match>
{
    private readonly MatchDbContext _context;

    public MatchService(MatchDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Match>> GetAllAsync()
    {
        return await _context.Matches
                             .Include(m => m.TeamA)
                             .Include(m => m.TeamB)
                             .Include(m => m.MatchPlayers)
                             .ThenInclude(mp => mp.Player)
                             .ToListAsync();
    }

    public async Task<Match> GetByIdAsync(int id)
    {
        return await _context.Matches
                             .Include(m => m.TeamA)
                             .Include(m => m.TeamB)
                             .Include(m => m.MatchPlayers)
                             .ThenInclude(mp => mp.Player)
                             .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Match> CreateAsync(Match match)
    {
        _context.Matches.Add(match);
        await _context.SaveChangesAsync();
        return match;
    }

    public async Task<Match> UpdateAsync(Match match)
    {
        _context.Matches.Update(match);
        await _context.SaveChangesAsync();
        return match;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var match = await _context.Matches.FindAsync(id);
        if (match == null) return false;

        _context.Matches.Remove(match);
        await _context.SaveChangesAsync();
        return true;
    }
}
