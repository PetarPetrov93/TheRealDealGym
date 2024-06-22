using TheRealDealGym.Core.Models.Room;

namespace TheRealDealGym.Core.Contracts
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomServiceModel>> AllRoomsAsync();
    }
}
