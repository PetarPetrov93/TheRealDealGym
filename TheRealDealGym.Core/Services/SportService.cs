using Microsoft.EntityFrameworkCore;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Models.Sport;
using TheRealDealGym.Infrastructure.Data.Common;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Core.Services
{
    /// <summary>
    /// The service responsible for operations with Sport entity.
    /// </summary>
    public class SportService : ISportService
    {
        private readonly IRepository repository;

        public SportService(IRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// This method returns a collection of all Sports currently created.
        /// </summary>
        public async Task<IEnumerable<SportInfoModel>> AllSportsAsync()
        {
            return await repository.AllReadOnly<Sport>()
                .Select(s => new SportInfoModel()
                {
                    Id = s.Id,
                    Title = s.Title
                })
                .OrderBy(s => s.Title)
                .ToListAsync();
        }
    }
}
