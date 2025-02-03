using Domain.Entities;
using Domain.Repositories.Base;

namespace Domain.Repositories;

public interface IUserRepository :
IGetabbleRepository<User>,
IAddableRepository<User>,
IDeletableRepository<User>,
IUpdatableRepository<User>
{
    Task<User> GetAsync(Guid id, bool includeTweets);
    Task<IEnumerable<User>> GetFollowed(Guid userId);
}