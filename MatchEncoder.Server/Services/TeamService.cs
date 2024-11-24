using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class TeamService
{
    private readonly MatchDbContext _context;

    public TeamService(MatchDbContext context)
    {
        _context = context;
    }

    public async Task<List<Team>> GetAllAsync()
    {
        return await _context.Teams.Select(t => new Team
        {
            Id = t.Id,
            Name = t.Name
        }).ToListAsync();
    }

    public async Task<Team> GetByIdAsync(int id)
    {
        return await _context.Teams.Include(t => t.Players).FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Team> CreateAsync(Team team)
    {
        _context.Teams.Add(team);
        await _context.SaveChangesAsync();
        return team;
    }

    public async Task<Team> UpdateAsync(Team team)
    {
        _context.Teams.Update(team);
        await _context.SaveChangesAsync();
        return team;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var team = await _context.Teams.FindAsync(id);
        if (team == null) return false;

        _context.Teams.Remove(team);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<Player>> GetPlayersByTeamIdAsync(int teamId)
    {
        var team = await _context.Teams.Include(t => t.Players)
                                       .FirstOrDefaultAsync(t => t.Id == teamId);

        return team?.Players.ToList() ?? new List<Player>();
    }
}
