
using Microsoft.EntityFrameworkCore;

namespace TheRealDealGym.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        private readonly DbContext context;
        public Repository(ApplicationDbContext _context)
        {
            context = _context;
        }
        public Task AddAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> All<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync<T>(object id) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByIdAsync<T>(object id) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
