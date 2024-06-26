namespace TheRealDealGym.Core.Models.Room
{
    public class RoomQueryModel
    {
        public int RoomsCount { get; set; }

        public IEnumerable<RoomServiceModel> Rooms { get; set; } = new List<RoomServiceModel>();
    }
}
