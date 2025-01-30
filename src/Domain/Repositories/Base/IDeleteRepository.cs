using Domain.Entities;

namespace Domain.Repositories.Base;

public interface IDeleteRepository<T>
where T : Entity
{
    Task DeleteAsync(Guid id);
}