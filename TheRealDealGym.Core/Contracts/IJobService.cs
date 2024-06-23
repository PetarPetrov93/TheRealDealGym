using TheRealDealGym.Core.Models.Job;

namespace TheRealDealGym.Core.Contracts
{
    public interface IJobService
    {
        Task<IEnumerable<JobAdvertListModel>> AllJobsAsync();
        Task<Guid> CreateAsync(JobAdvertModel model);
        Task DeactivateAsync(Guid jobId);
        Task ActivateAsync(Guid jobId);
        Task EditAsync(Guid jobId, JobAdvertModel model);
        Task<bool> ExistsByIdAsync(Guid jobId);
        Task<JobAdvertModel> GetByIdAsync(Guid jobId);
    }
}
