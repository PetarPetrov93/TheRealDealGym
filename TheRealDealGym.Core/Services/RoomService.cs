using Microsoft.EntityFrameworkCore;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Models.Class;
using TheRealDealGym.Core.Models.Room;
using TheRealDealGym.Infrastructure.Data.Common;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Core.Services
{
    /// <summary>
    /// The service responsible for operations with Room entity.
    /// </summary>
    public class RoomService : IRoomService
    {
        private readonly IRepository repository;

        public RoomService(IRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// This method returns a collection of all rooms currently created.
        /// </summary>
        public async Task<IEnumerable<RoomServiceModel>> AllRoomsAsync()
        {
            return await repository.AllReadOnly<Room>()
                .Select(r => new RoomServiceModel()
                {
                    Id = r.Id,
                    Type = r.Type,
                    Capacity = r.Capacity
                })
                .OrderBy(r => r.Type)
                .ToListAsync();
        }

        /// <summary>
        /// This method creates a new room.
        /// </summary>
        public async Task<Guid> CreateAsync(RoomServiceModel model)
        {
            Room room = new Room()
            {
                Type = model.Type,
                Capacity = model.Capacity
            };

            await repository.AddAsync(room);
            await repository.SaveChangesAsync();

            return room.Id;
        }

        /// <summary>
        /// This method performs a soft delete on a given room by setting the IsDeleted property to "true".
        /// </summary>
        public async Task DeleteAsync(Guid roomId)
        {
            await repository.DeleteAsync<Room>(roomId);
            await repository.SaveChangesAsync();
        }

        /// <summary>
        /// This method edits a selected room.
        /// </summary>
        public async Task EditAsync(Guid roomId, RoomServiceModel model)
        {
            var room = await repository.GetByIdAsync<Room>(roomId);

            if (room != null)
            {
                room.Type = model.Type;
                room.Capacity = model.Capacity;
                await repository.SaveChangesAsync();
            }
        }

        /// <summary>
        /// This method checks if a room with a given Id exists.
        /// </summary>
        public async Task<bool> ExistsByIdAsync(Guid roomId)
        {
            return await repository.AllReadOnly<Room>()
                 .AnyAsync(r => r.Id == roomId);
        }

        /// <summary>
        /// This method finds and returns a room by a given Id
        /// </summary>
        public async Task<RoomServiceModel> GetRoomByIdAsync(Guid roomId)
        {
            return await repository.AllReadOnly<Room>()
                .Where(r => r.Id == roomId)
                .Select(r => new RoomServiceModel()
                {
                    Id = r.Id,
                    Type = r.Type,
                    Capacity = r.Capacity
                })
                .FirstAsync();
        }
    }
}
