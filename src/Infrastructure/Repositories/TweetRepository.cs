using Domain.Entities;
using Domain.Repositories;

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

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Tweet>> GetAllAsync()
    {
        throw new NotImplementedException();
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