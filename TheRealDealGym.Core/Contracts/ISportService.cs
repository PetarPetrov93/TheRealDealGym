using TheRealDealGym.Core.Models.Sport;

namespace TheRealDealGym.Core.Contracts
{
    public interface ISportService
    {
        Task<IEnumerable<SportInfoModel>> AllSportsAsync();
        Task<Guid> CreateAsync(SportInfoModel model);
        Task DeleteAsync(Guid sportId);
        Task EditAsync(Guid sportId, SportInfoModel model);
        Task<bool> ExistsByIdAsync(Guid sportId);
        Task<SportInfoModel> GetByIdAsync(Guid sportId);
    }
}
