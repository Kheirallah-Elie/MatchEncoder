using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UserService
{
    private readonly MatchDbContext _context;

    public UserService(MatchDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User> CreateAsync(User user)
    {
        // Check if a user with the same name already exists
        if (await _context.Users.AnyAsync(u => u.Name == user.Name))
        {
            throw new InvalidOperationException($"User with name '{user.Name}' already exists.");
        }

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;  // The user object now has the auto-generated Id from the database
    }

    public async Task<User> UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null) return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<User> AuthenticateAsync(string name, string password)
    {
        // Verify if the user exists with the given name and password
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Name == name && u.Password == password);
    }
}
