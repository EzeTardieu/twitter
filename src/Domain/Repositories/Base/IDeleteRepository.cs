using Domain.Entities;

namespace Domain.Repositories.Base;

public interface IDeletableRepository<T>
where T : Entity
{
    Task DeleteAsync(Guid id);
}