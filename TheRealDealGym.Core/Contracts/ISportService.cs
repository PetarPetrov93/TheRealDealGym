using TheRealDealGym.Core.Enums;
using TheRealDealGym.Core.Models.Sport;

namespace TheRealDealGym.Core.Contracts
{
    public interface ISportService
    {
        Task<SportQueryModel> AllSportsAsync(SportSorting sorting = SportSorting.TitleAscending,
            int currentPage = 1,
            int sportsPerPage = 10);
        Task<Guid> CreateAsync(SportInfoModel model);
        Task DeleteAsync(Guid sportId);
        Task EditAsync(Guid sportId, SportInfoModel model);
        Task<bool> ExistsByIdAsync(Guid sportId);
        Task<SportInfoModel> GetByIdAsync(Guid sportId);
    }
}
