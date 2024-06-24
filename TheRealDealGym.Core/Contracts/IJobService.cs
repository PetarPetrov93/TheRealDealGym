using TheRealDealGym.Core.Models.Job;

namespace TheRealDealGym.Core.Contracts
{
    public interface IJobService
    {
        Task<IEnumerable<JobAdvertListModel>> AllJobsAsync(Guid userId);
        Task<Guid> CreateAsync(JobAdvertModel model);
        Task DeactivateAsync(Guid jobId);
        Task ActivateAsync(Guid jobId);
        Task EditAsync(Guid jobId, JobAdvertModel model);
        Task<bool> ExistsByIdAsync(Guid jobId);
        Task<JobAdvertModel> GetByIdAsync(Guid jobId);
        Task CreateJobApplicationAsync(Guid jobAdvertId, Guid userId, ApplicationFormModel model);
        Task HireTrainerAsync(Guid applicationId);
        Task <IEnumerable<ApplicationForApproveModel>> AllApplicationsAsync();
    }
}
