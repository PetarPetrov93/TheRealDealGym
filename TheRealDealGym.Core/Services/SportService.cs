using Microsoft.EntityFrameworkCore;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Models.Room;
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

        /// <summary>
        /// This method creates a new sport.
        /// </summary>
        public async Task<Guid> CreateAsync(SportInfoModel model)
        {
            Sport sport = new Sport()
            {
                Title = model.Title
            };

            await repository.AddAsync(sport);
            await repository.SaveChangesAsync();

            return sport.Id;
        }

        /// <summary>
        /// This method performs a soft delete on a given sport by setting the IsDeleted property to "true".
        /// </summary>
        public async Task DeleteAsync(Guid sportId)
        {
            await repository.DeleteAsync<Sport>(sportId);
            await repository.SaveChangesAsync();
        }

        /// <summary>
        /// This method edits a selected sport.
        /// </summary>
        public async Task EditAsync(Guid sportId, SportInfoModel model)
        {
            var sport = await repository.GetByIdAsync<Sport>(sportId);

            if (sport != null)
            {
                sport.Title = model.Title;
                await repository.SaveChangesAsync();
            }
        }

        /// <summary>
        /// This method checks if a sport with a given Id exists.
        /// </summary>
        public async Task<bool> ExistsByIdAsync(Guid sportId)
        {
            return await repository.AllReadOnly<Sport>()
                 .AnyAsync(s => s.Id == sportId);
        }

        /// <summary>
        /// This method finds and returns a sport by a given Id
        /// </summary>
        public async Task<SportInfoModel> GetByIdAsync(Guid sportId)
        {
            return await repository.AllReadOnly<Sport>()
                .Where(s => s.Id == sportId)
                .Select(s => new SportInfoModel()
                {
                    Id = s.Id,
                    Title = s.Title,
                })
                .FirstAsync();
        }
    }
}
