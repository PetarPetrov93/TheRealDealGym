using System.ComponentModel.DataAnnotations;
using TheRealDealGym.Core.Enums;

namespace TheRealDealGym.Core.Models.Sport
{
    public class AllSportsQueryModel
    {
        public int SportsPerPage { get; } = 10;

        [Display(Name = "Order by")]
        public SportSorting OrderBy { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalSportsCount { get; set; }

        public IEnumerable<SportInfoModel> Sports { get; set; } = new List<SportInfoModel>();
    }
}
