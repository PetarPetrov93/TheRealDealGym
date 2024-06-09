using Microsoft.EntityFrameworkCore;

namespace TheRealDealGym.Infrastructure.Data.Common
{
    /// <summary>
    /// This repository adds another layer of abstraction and would be helpful in case we decide to change the database in the future.
    /// </summary>
    public class Repository : IRepository
    {
        private readonly DbContext context;
        public Repository(ApplicationDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// This is a private method which gets the required DbSet from the database.
        /// </summary>
        private DbSet<T> DbSet<T>() where T : class
        {
            return context.Set<T>();
        }

        /// <summary>
        /// This method adds newly created entity of type T to the respective DbSet.
        /// </summary>
        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        /// <summary>
        /// This method gets all entities from the respective DbSet WITH TRACKING.
        /// </summary>
        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        /// <summary>
        /// This method gets all entities from the respective DbSet WITH NO TRACKING.
        /// </summary>
        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return DbSet<T>().AsNoTracking();
        }

        /// <summary>
        /// This method performs a soft delete (sets the IsDeleted property value to 'true') over the selected entity from the respective DbSet.
        /// </summary>
        public async Task DeleteAsync<T>(object id) where T : class
        {
            T? entity = await GetByIdAsync<T>(id);

            if (entity != null)
            {
                var property = entity.GetType().GetProperty("IsDeleted");
                property!.SetValue(entity, true);
            }
        }

        /// <summary>
        /// This method gets a specific entity from the DbSet by Id.
        /// </summary>
        public async Task<T?> GetByIdAsync<T>(object id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }

        /// <summary>
        /// This method saves changes.
        /// </summary>
        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
