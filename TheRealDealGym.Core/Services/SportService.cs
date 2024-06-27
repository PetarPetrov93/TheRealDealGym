using Microsoft.EntityFrameworkCore;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Enums;
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
        /// It also sorts the Sports by name asc/desc.
        /// </summary>
        public async Task<SportQueryModel> AllSportsAsync(SportSorting sorting = SportSorting.TitleAscending,
            int currentPage = 1,
            int sportsPerPage = 10)
        {
            var sportsToShow = repository.AllReadOnly<Sport>();


            sportsToShow = sorting switch
            {
                SportSorting.TitleAscending => sportsToShow.OrderBy(s => s.Title),
                SportSorting.TitleDescending => sportsToShow.OrderByDescending(s => s.Title),
                _ => sportsToShow.OrderBy(s => s.Title)
            };

            var sports = await sportsToShow
                .Skip((currentPage - 1) * sportsPerPage)
                .Take(sportsPerPage)
                .Select(s => new SportInfoModel()
                {
                    Id = s.Id,
                    Title = s.Title
                })
                .ToListAsync();

            int totalRooms = await sportsToShow.CountAsync();

            return new SportQueryModel()
            {
                Sports = sports,
                SportsCount = totalRooms
            };
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
