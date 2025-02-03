using Domain.Entities;

namespace Domain.Repositories.Base;

public interface IUpdatableRepository<T>
where T : Entity
{
    Task UpdateAsync(T entity);
}