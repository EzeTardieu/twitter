using Domain.Entities;
using Domain.Repositories.Base;

namespace Domain.Repositories;

public interface ITweetRepository :
IGetabbleRepository<Tweet>,
IAddableRepository<Tweet>,
IDeletableRepository<Tweet>,
IUpdatableRepository<Tweet>
{

}