namespace HighLowGame.Domain.Interfaces;

public interface IRepository<T> where T: IEntity
{
    Task<Guid> AddAsync(T entity);
    Task<T> GetAsync(Guid id);
    Task DeleteAsync(Guid id);
}