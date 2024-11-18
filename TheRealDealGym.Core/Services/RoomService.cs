using Microsoft.EntityFrameworkCore;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Enums;
using TheRealDealGym.Core.Models.Job;
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
        /// It also provides sorting functionality.
        /// </summary>
        public async Task<RoomQueryModel> AllRoomsAsync(RoomSotring sorting = RoomSotring.TitleAscending,
            int currentPage = 1,
            int roomsPerPage = 10)
        {
            var roomsToShow = repository.AllReadOnly<Room>();

            
            roomsToShow = sorting switch
            {
                RoomSotring.TitleAscending => roomsToShow.OrderBy(r => r.Type),
                RoomSotring.TitleDescending => roomsToShow.OrderByDescending(r => r.Type),
                RoomSotring.CapacityDescending => roomsToShow.OrderByDescending(r => r.Capacity),
                RoomSotring.CapacityAscending => roomsToShow.OrderBy(r => r.Capacity),
                _ => roomsToShow.OrderBy(r => r.Type)
            };

            var rooms = await roomsToShow
                .Skip((currentPage - 1) * roomsPerPage)
                .Take(roomsPerPage)
                .Select(r => new RoomServiceModel()
                {
                    Id = r.Id,
                    Type = r.Type,
                    Capacity = r.Capacity
                })
                .ToListAsync();

            int totalRooms = await roomsToShow.CountAsync();

            return new RoomQueryModel()
            {
                Rooms = rooms,
                RoomsCount = totalRooms,
            };
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
            var classesInThisRoom = await repository.AllReadOnly<Class>()
                .Where(c => c.RoomId == roomId)
                .ToListAsync();

            if (classesInThisRoom.Any())
            {
                throw new Exception("You cannot delete this room because there's currently classes, schduled for it!");
            }

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
        public async Task<RoomServiceModel> GetByIdAsync(Guid roomId)
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
