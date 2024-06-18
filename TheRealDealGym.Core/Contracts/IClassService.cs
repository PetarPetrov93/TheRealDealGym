using TheRealDealGym.Core.Enums;
using TheRealDealGym.Core.Models.Class;

namespace TheRealDealGym.Core.Contracts
{
    public interface IClassService
    {
        Task<IEnumerable<ClassScheduleModel>> AllClassesAsync();

        Task<ClassQueryModel> AllAsync(
            string? category = null,
            string? searchTerm = null,
            ClassSorting sorting = ClassSorting.DateAscending,
            int currentPage = 1,
            int classesPerPage = 1);

        Task<IEnumerable<string>> AllSportNamesAsync();
        Task<IEnumerable<SportCategoryModel>> AllSportAsync();

        Task<IEnumerable<RoomCategoryModel>> AllRoomAsync();

        Task<bool> HasTrainerWithIdAsync(Guid classId, Guid userId);

        Task<bool> ExistsAsync(Guid classId);

        Task<ClassDetailsModel> ClassDetailsByIdAsync(Guid classId);

        Task EditAsync(Guid classId, ClassFormModel model);

        Task<ClassFormModel> GetClassFormModelByIdAsync(Guid classId);

        Task<bool> SportExistsAsync(Guid sportId);

        Task<bool> RoomExistsAsync(Guid roomId);

        Task<Guid> CreateAsync(ClassFormModel model, Guid trainerId);

        Task DeleteAsync(Guid classId);
    }
}
