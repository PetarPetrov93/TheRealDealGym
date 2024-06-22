using Microsoft.EntityFrameworkCore;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Models.Room;
using TheRealDealGym.Infrastructure.Data.Common;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Core.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRepository repository;

        public RoomService(IRepository _repository)
        {
            repository = _repository;
        }
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
