using System.ComponentModel.DataAnnotations;
using TheRealDealGym.Core.Enums;

namespace TheRealDealGym.Core.Models.Class
{
    /// <summary>
    /// This ViewModel is used for the implementation of the search bar and the filtering options.
    /// </summary>
    public class AllClassesQueryModel
    {
        public int ClassesPerPage { get; } = 6;

        public string Category { get; set; } = null!;

        [Display(Name = "Search by keyword")]
        public string SearchTerm { get; set; } = null!;

        public ClassSorting Sorting {  get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalClassesCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<ClassScheduleModel> Classes { get; set; } = new List<ClassScheduleModel>();
    }
}
