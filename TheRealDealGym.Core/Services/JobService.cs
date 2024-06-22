using Microsoft.EntityFrameworkCore;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Models.Job;
using TheRealDealGym.Infrastructure.Data.Common;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Core.Services
{
    /// <summary>
    /// The service responsible for operations with JobAdvert entity.
    /// </summary>
    public class JobService : IJobService
    {
        private readonly IRepository repository;

        public JobService(IRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// This method returns a collection of all Jobs both active and unactive.
        /// </summary>
        public async Task<IEnumerable<JobAdvertListModel>> AllJobsAsync()
        {
            return await repository.AllReadOnly<JobAdvert>()
                .Select(j => new JobAdvertListModel()
                {
                    Id = j.Id,
                    Title = j.Title,
                    IsActive = j.IsActive,
                })
                .OrderByDescending(j => j.IsActive)
                .ThenBy(j => j.Title)
                .ToListAsync();
        }
    }
}
