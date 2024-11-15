using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Infrastructure.Data.Common;
using TheRealDealGym.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TheRealDealGym.Core.Services;
using TheRealDealGym.Infrastructure.Data.Models;
using TheRealDealGym.Core.Enums;

namespace TheRealDealGym.UnitTests
{
    [TestFixture]
    public class RoomServiceTests
    {
        private IRepository repository;
        private IRoomService roomService;
        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public async Task SetUp()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("GymDB")
                .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            await applicationDbContext.Database.EnsureCreatedAsync();

            repository = new Repository(applicationDbContext);
            roomService = new RoomService(repository);

            var fightingRoom = new Room()
            {
                Id = Guid.Parse("b62f8c2e-f842-4812-ae27-70be5e24d309"),
                Type = "Fighting room",
                Capacity = 1
            };

            var swimmingPool = new Room()
            {
                Id = Guid.Parse("07c92ab2-93a1-43dd-8fc8-3e16541a9573"),
                Type = "Pool",
                Capacity = 16,

            };
            await repository.AddAsync(fightingRoom);
            await repository.AddAsync(swimmingPool);

            await repository.SaveChangesAsync();
        }

        [Test]
        public async Task AllRoomAsync_ShouldReturnAllRoomsByTitleAsc()
        {
            var allRoomsByTitleAsc = await roomService.AllRoomsAsync(RoomSotring.TitleAscending);
            var firstRoomTitle = allRoomsByTitleAsc.Rooms.First().Type;

            Assert.That(firstRoomTitle, Is.EqualTo("Fighting room"));
        }

        [Test]
        public async Task AllRoomAsync_ShouldReturnAllRoomsByTitleDesc()
        {
            var allRoomsByTitleDesc = await roomService.AllRoomsAsync(RoomSotring.TitleDescending);
            var firstRoomTitle = allRoomsByTitleDesc.Rooms.First().Type;

            Assert.That(firstRoomTitle, Is.EqualTo("Pool"));
        }

        [Test]
        public async Task AllRoomAsync_ShouldReturnAllRoomsByCapacityAsc()
        {
            var allRoomsByCapacityAsc = await roomService.AllRoomsAsync(RoomSotring.CapacityAscending);
            var firstRoomTitle = allRoomsByCapacityAsc.Rooms.First().Type;

            Assert.That(firstRoomTitle, Is.EqualTo("Fighting room"));
        }

        [Test]
        public async Task AllRoomAsync_ShouldReturnAllRoomsByCapacityDesc()
        {
            var allRoomsByCapacityDesc = await roomService.AllRoomsAsync(RoomSotring.CapacityDescending);
            var firstRoomTitle = allRoomsByCapacityDesc.Rooms.First().Type;

            Assert.That(firstRoomTitle, Is.EqualTo("Pool"));
        }

        [TearDown]
        public async Task TearDown()
        {
            await applicationDbContext.Database.EnsureDeletedAsync();
            await applicationDbContext.DisposeAsync();
        }
    }
}
