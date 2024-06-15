using TheRealDealGym.Core.Enums;
using TheRealDealGym.Core.Models.Class;

namespace TheRealDealGym.Core.Contracts
{
    public interface IClassService
    {
        Task<IEnumerable<ClassScheduleModel>> AllClassesAsync();
        Task<ClassDetailsModel> ClassDetailsAsync(Guid classId);
        Task<ClassQueryModel> AllAsync(
            string? category = null,
            string? searchTerm = null,
            ClassSorting sorting = ClassSorting.DateAscending,
            int currentPage = 1,
            int classesPerPage = 1);
        Task<IEnumerable<string>> AllSportCategoriesAsync();
    }
}
