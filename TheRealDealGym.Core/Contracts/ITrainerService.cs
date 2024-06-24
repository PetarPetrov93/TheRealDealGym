using TheRealDealGym.Core.Models.Trainer;

namespace TheRealDealGym.Core.Contracts
{
    public interface ITrainerService
    {
        Task<bool> ExistsByUserIdAsync(Guid userId);
        Task<bool> ExistsByTrainerIdAsync(Guid trainerId);
        Task<Guid?> GetTrainerIdAsync(Guid userId);
        Task<TrainerDetailsModel> GetTrainerDetailsAsync(Guid trainerId);
        Task<IEnumerable<TrainerClassModel>> AllTrainerClassesAsync(Guid? trainerId);
        Task<IEnumerable<TrainerNameModel>> AllTrainersAsync();
        Task EditAsync(Guid trainerId, TrainerDetailsModel model);
    }
}
