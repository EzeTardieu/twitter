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
        return await GetAsync(id,false);
    }
    public async Task<User> GetAsync(Guid id, bool includeTweets)
    {
        var usersQuery = _dbcontext.Users.AsQueryable();
        if(includeTweets)
           usersQuery = usersQuery.Include(user => user.Tweets); 
        
        var user = await usersQuery.SingleOrDefaultAsync(user => user.Id.Equals(id));
        if(user is null)
            throw new KeyNotFoundException($"User with key {id} does not exist.");
        return user;
    }
    public async Task<IEnumerable<User>> GetFollowed(Guid userId)
    {
        var user = await _dbcontext.Users.Include(user => user.FollowedUsers).SingleOrDefaultAsync(user => user.Id == userId);
        if(user is null)
            throw new KeyNotFoundException($"User with key {userId} does not exist.");
        
        return user.FollowedUsers;
    }

    public async Task UpdateAsync(User user)
    {
        var userToUpdate = await _dbcontext.Users.FindAsync(user.Id);
        if(userToUpdate is null)
            throw new KeyNotFoundException($"User with key {user.Id} does not exist.");
        
        _dbcontext.Users.Update(user);
        
        await _dbcontext.SaveChangesAsync();
    }
}