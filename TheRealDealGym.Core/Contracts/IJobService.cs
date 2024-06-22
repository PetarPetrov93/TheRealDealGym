using TheRealDealGym.Core.Models.Job;

namespace TheRealDealGym.Core.Contracts
{
    public interface IJobService
    {
        Task<IEnumerable<JobAdvertListModel>> AllJobsAsync();
    }
}
