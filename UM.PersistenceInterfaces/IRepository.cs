namespace UM.PersistenceInterfaces;

public interface IRepository<TEntity, TKey>
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(TKey id);
    Task<TEntity> CreateAsync(TEntity user);
    Task<TEntity> UpdateAsync(TEntity user);
    Task DeleteAsync(TKey id);
}