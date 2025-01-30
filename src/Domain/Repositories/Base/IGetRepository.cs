using Domain.Entities;

namespace Domain.Repositories.Base;

public interface IGetRepository<T>
where T : Entity
{
    Task<T> GetAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();

}