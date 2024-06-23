using TheRealDealGym.Core.Models.Room;

namespace TheRealDealGym.Core.Contracts
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomServiceModel>> AllRoomsAsync();
        Task<Guid> CreateAsync(RoomServiceModel model);
        Task DeleteAsync(Guid roomId);
        Task EditAsync(Guid roomId, RoomServiceModel model);
        Task<bool> ExistsByIdAsync(Guid roomId);
        Task<RoomServiceModel> GetRoomByIdAsync(Guid roomId);
    }
}
