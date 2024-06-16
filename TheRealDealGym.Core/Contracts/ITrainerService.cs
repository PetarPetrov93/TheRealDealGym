using TheRealDealGym.Core.Models.Class;
using TheRealDealGym.Core.Models.Trainer;

namespace TheRealDealGym.Core.Contracts
{
    public interface ITrainerService
    {
        Task<bool> ExistsByIdAsync(Guid userId);
        Task CreateAsync(Guid userId, JobApplication trainerInfo);
        Task<Guid?> GetTrainerIdAsync(Guid userId);
        Task<TrainerProfileInfo> GetTrainerProfileInfoAsync(Guid trainerId);
        Task<IEnumerable<TrainerClassModel>> AllTrainerClassesAsync(Guid userId);
    }
}
