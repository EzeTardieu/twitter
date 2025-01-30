using Domain.Entities;
using Domain.Repositories.Base;

namespace Domain.Repositories;

public interface IUserRepository : IGetRepository<User>, IAddRepository<User>, IDeleteRepository<User>, IUpdateRepository<User>
{

}