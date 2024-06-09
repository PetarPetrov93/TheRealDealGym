namespace TheRealDealGym.Infrastructure.Data.Common
{
    /// <summary>
    /// This repository interface adds another layer of abstraction and would be helpful in case we decide to change the database in the future.
    /// It is implemented in the Repository class.
    /// </summary>
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;
        IQueryable<T> AllReadOnly<T>() where T : class;
        Task AddAsync<T>(T entity) where T : class;
        Task<int> SaveChangesAsync();
        Task<T?> GetByIdAsync<T>(object id) where T : class;
        Task DeleteAsync<T>(object id) where T : class;
    }
}
