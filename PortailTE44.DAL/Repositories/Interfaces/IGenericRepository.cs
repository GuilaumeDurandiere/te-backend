namespace PortailTE44.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class, new()
    {
        Task<TEntity?> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetByIdsAsync(int[] ids);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Add(TEntity entity);
        void AddAll(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateAll(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteAll(IEnumerable<TEntity> entities);
        Task<int> SaveAsync();
    }
}
