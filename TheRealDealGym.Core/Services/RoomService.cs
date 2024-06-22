using Microsoft.EntityFrameworkCore;
using TheRealDealGym.Core.Contracts;
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
    }
}
