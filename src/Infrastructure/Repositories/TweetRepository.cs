using Domain.Entities;
using Domain.Filters;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TweetRepository : ITweetRepository
{
    private readonly ApplicationDbContext _dbcontext;

    public TweetRepository(ApplicationDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }
    public async Task AddAsync(Tweet tweet)
    {
        await _dbcontext.Tweets.AddAsync(tweet);
        await _dbcontext.SaveChangesAsync();
    }

    public async Task<int> CountAllAsync(TweetFilter filter)
    {
        return await _dbcontext.Tweets
            .Include(tweet => tweet.User)
            .Where(tweet => filter.UsersIds.Contains(tweet.UserId))
            .CountAsync();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Tweet>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Tweet>> GetAllAsync(TweetFilter filter)
    {
        return await _dbcontext.Tweets
            .Include(tweet => tweet.User)
            .Where(tweet => filter.UsersIds.Contains(tweet.UserId))
            .Skip(filter.PaginationFilters.Offset)
            .Take(filter.PaginationFilters.Limit)
            .ToArrayAsync();
    }

    public Task<Tweet> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Tweet entity)
    {
        throw new NotImplementedException();
    }
}