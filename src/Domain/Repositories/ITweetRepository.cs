using Domain.Entities;
using Domain.Repositories.Base;

namespace Domain.Repositories;

public interface ITweetRepository : IGetRepository<Tweet>, IAddRepository<Tweet>, IDeleteRepository<Tweet>, IUpdateRepository<Tweet>
{

}