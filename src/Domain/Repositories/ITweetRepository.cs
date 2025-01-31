using Domain.Entities;
using Domain.Repositories.Base;

namespace Domain.Repositories;

public interface ITweetRepository :
IGetabbleRepository<User>,
IAddableRepository<User>,
IDeletableRepository<User>,
IUpdatableRepository<User>
{

}