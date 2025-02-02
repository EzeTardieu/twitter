using Domain.Entities;
using Domain.Filters;
using Domain.Repositories.Base;

namespace Domain.Repositories;

public interface ITweetRepository :
IGetabbleRepository<Tweet>,
IAddableRepository<Tweet>,
IDeletableRepository<Tweet>,
IUpdatableRepository<Tweet>
{
    Task<IEnumerable<Tweet>> GetAllAsync(TweetFilter filter);
}