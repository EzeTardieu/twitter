using Domain.Entities;

namespace Domain.Repositories.Base;

public interface IAddableRepository<T>
where T : Entity
{
    Task AddAsync(T entity);
}