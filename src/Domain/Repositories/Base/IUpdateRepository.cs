using Domain.Entities;

namespace Domain.Repositories.Base;

public interface IUpdateRepository<T>
where T : Entity
{
    Task UpdateAsync(T entity);
}