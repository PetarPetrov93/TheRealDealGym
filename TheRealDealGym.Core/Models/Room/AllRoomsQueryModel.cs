using System.ComponentModel.DataAnnotations;
using TheRealDealGym.Core.Enums;

namespace TheRealDealGym.Core.Models.Room
{
    public class AllRoomsQueryModel
    {
        public int RoomsPerPage { get; } = 10;

        [Display(Name = "Order by")]
        public RoomSotring OrderBy { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalRoomsCount { get; set; }

        public IEnumerable<RoomServiceModel> Rooms { get; set; } = new List<RoomServiceModel>();
    }
}
