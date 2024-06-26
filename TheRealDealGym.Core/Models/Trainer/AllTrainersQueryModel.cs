using System.ComponentModel.DataAnnotations;
using TheRealDealGym.Core.Enums;
using TheRealDealGym.Core.Models.Sport;

namespace TheRealDealGym.Core.Models.Trainer
{
    public class AllTrainersQueryModel
    {
        public int TrainersPerPage { get; } = 10;

        [Display(Name = "Order by")]
        public StaffSorting OrderBy { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalTrainersCount { get; set; }

        public IEnumerable<TrainerNameModel> Trainers { get; set; } = new List<TrainerNameModel>();
    }
}
