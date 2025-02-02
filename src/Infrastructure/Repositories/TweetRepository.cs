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
        var query = _dbcontext.Tweets.AsQueryable();
        
        if(filter.UsersIds is not null)
            query = query.Where(tweet => filter.UsersIds.Contains(tweet.UserId)).AsQueryable();
        
        return await query.CountAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var tweet = await _dbcontext.Tweets.FindAsync(id);
        if (tweet is null)
            throw new KeyNotFoundException($"Tweet with key {id} does not exist.");
        _dbcontext.Tweets.Remove(tweet);
        await _dbcontext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Tweet>> GetAllAsync()
    {
        TweetFilter basicFilter = new TweetFilter(new PaginationFilter());
        return await GetAllAsync(basicFilter);
    }

    public async Task<IEnumerable<Tweet>> GetAllAsync(TweetFilter filter)
    {
        var query = _dbcontext.Tweets.Include(tweet => tweet.User).AsQueryable();
        
        if(filter.UsersIds is not null)
            query = query.Where(tweet => filter.UsersIds.Contains(tweet.UserId)).AsQueryable();
        
        return await query
            .OrderByDescending(tweet => tweet.Date)
            .Skip(filter.PaginationFilters.Offset)
            .Take(filter.PaginationFilters.Limit)
            .ToArrayAsync();
    }

    public async Task<Tweet> GetAsync(Guid id)
    {
        var tweet = await _dbcontext.Tweets.FindAsync(id);
        if (tweet is null)
            throw new KeyNotFoundException($"User with key {id} does not exist.");

        return tweet;
    }

    public async Task UpdateAsync(Tweet tweet)
    {
        var tweetToUpdate = await _dbcontext.Tweets.FindAsync(tweet.Id);
        if (tweetToUpdate is null)
            throw new KeyNotFoundException($"User with key {tweet.Id} does not exist.");

        _dbcontext.Tweets.Update(tweetToUpdate);

        await _dbcontext.SaveChangesAsync();
    }
}