using TheRealDealGym.Core.Models.Job;

namespace TheRealDealGym.Core.Contracts
{
    public interface IJobService
    {
        Task<IEnumerable<JobAdvertListModel>> AllJobAdvertsForAdminAsync();
        Task<IEnumerable<JobAdvertListModel>> AllActiveJobAdvertsForUsersAsync(Guid userId);
        Task<Guid> CreateAsync(JobAdvertModel model);
        Task DeactivateAsync(Guid jobId);
        Task ActivateAsync(Guid jobId);
        Task EditAsync(Guid jobId, JobAdvertModel model);
        Task<bool> JobAdvertExistsByIdAsync(Guid jobId);
        Task<bool> JobApplicationExistsByIdAsync(Guid jobApplicationId);
        Task<JobAdvertModel> GetJobAdvertByIdAsync(Guid jobId);
        Task CreateJobApplicationAsync(Guid jobAdvertId, Guid userId, ApplicationFormModel model);
        Task HireTrainerAsync(Guid applicationId);
        Task RejectApplicantAsync(Guid jobApplicationId);
        Task <IEnumerable<ApplicationForApproveModel>> AllApplicationsAsync();
    }
}
