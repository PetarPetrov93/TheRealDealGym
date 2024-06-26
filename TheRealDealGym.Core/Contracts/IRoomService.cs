using TheRealDealGym.Core.Enums;
using TheRealDealGym.Core.Models.Room;

namespace TheRealDealGym.Core.Contracts
{
    public interface IRoomService
    {
        Task<RoomQueryModel> AllRoomsAsync(RoomSotring sorting = RoomSotring.TitleAscending,
            int currentPage = 1,
            int roomsPerPage = 10);
        Task<Guid> CreateAsync(RoomServiceModel model);
        Task DeleteAsync(Guid roomId);
        Task EditAsync(Guid roomId, RoomServiceModel model);
        Task<bool> ExistsByIdAsync(Guid roomId);
        Task<RoomServiceModel> GetByIdAsync(Guid roomId);
    }
}
