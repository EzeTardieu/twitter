using Domain.Entities;

namespace Domain.Repositories.Base;

public interface IAddRepository<T>
where T : Entity
{
    Task Add(T entity);
}