using TheRealDealGym.Core.Models.Sport;

namespace TheRealDealGym.Core.Contracts
{
    public interface ISportService
    {
        Task<IEnumerable<SportInfoModel>> AllSportsAsync();
    }
}
