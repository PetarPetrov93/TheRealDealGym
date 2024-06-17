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

        Task<IEnumerable<string>> AllSportCategoriesAsync();

        Task<IEnumerable<string>> AllRoomNamesAsync();

        Task<bool> HasTrainerWithIdAsync(Guid classId, Guid userId);

        Task<bool> ExistsAsync(Guid classId);

        Task<ClassDetailsModel> ClassDetailsByIdAsync(Guid classId);

        Task Edit(Guid classId, ClassFormModel model);

        Task<ClassFormModel> GetClassFormModelByIdAsync(Guid classId);

        Task<bool> SportExistsAsync(Guid sportId);

        Task<bool> RoomExistsAsync(Guid roomId);
    }
}
