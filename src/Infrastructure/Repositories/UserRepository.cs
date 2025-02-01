using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbcontext;

    public UserRepository(ApplicationDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    public async Task AddAsync(User user)
    {
        await _dbcontext.Users.AddAsync(user);
        await _dbcontext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await _dbcontext.Users.FindAsync(id);
        if(user is null)
            throw new KeyNotFoundException($"User with key {id} does not exist.");
        _dbcontext.Users.Remove(user);
        await _dbcontext.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _dbcontext.Users.ToArrayAsync();
    }

    public async Task<User> GetAsync(Guid id)
    {
        var user = await _dbcontext.Users.FindAsync(id);
        if(user is null)
            throw new KeyNotFoundException($"User with key {id} does not exist.");
        return user;
    }

    public async Task UpdateAsync(User user)
    {
        var userToUpdate = await _dbcontext.Users.FindAsync(user.Id);
        if(userToUpdate is null)
            throw new KeyNotFoundException($"User with key {user.Id} does not exist.");
        
        userToUpdate.Name = user.Name;
        userToUpdate.Email = user.Email;
        await _dbcontext.SaveChangesAsync();
    }
}