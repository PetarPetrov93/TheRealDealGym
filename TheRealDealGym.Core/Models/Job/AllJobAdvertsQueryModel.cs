using System.ComponentModel.DataAnnotations;
using TheRealDealGym.Core.Enums;

namespace TheRealDealGym.Core.Models.Job
{
    public class AllJobAdvertsQueryModel
    {
        public int JobsPerPage { get; } = 10;

        public string Status { get; set; } = null!;

        [Display(Name = "Order by")]
        public JobAdvertSorting OrderBy { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalJobAdvertsCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<JobAdvertListModel> JobAdverts { get; set; } = new List<JobAdvertListModel>();
    }
}
