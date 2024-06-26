using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRealDealGym.Core.Models.Sport;

namespace TheRealDealGym.Core.Models.Trainer
{
    public class TrainerQueryModel
    {
        public int TrainersCount { get; set; }

        public IEnumerable<TrainerNameModel> Trainers { get; set; } = new List<TrainerNameModel>();
    }
}
