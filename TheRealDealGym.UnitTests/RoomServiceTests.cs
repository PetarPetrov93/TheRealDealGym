using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Infrastructure.Data.Common;
using TheRealDealGym.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TheRealDealGym.Core.Services;
using TheRealDealGym.Infrastructure.Data.Models;
using TheRealDealGym.Core.Enums;
using TheRealDealGym.Core.Models.Class;
using TheRealDealGym.Core.Models.Room;
using TheRealDealGym.Core.Models.Trainer;

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

            var muayThaiClass = new Class()
            {
                Id = Guid.Parse("ad61a644-76c7-4366-9686-82b65a42fd14"),
                Title = "Advanced MuayThai",
                Description = "this is advanced class for fighters",
                Price = 20,
                DateAndTime = DateTime.Now,
                TrainerId = Guid.Parse("10c4a0b0-16ca-464a-bdc4-6f8fe432de42"),
                RoomId = Guid.Parse("b62f8c2e-f842-4812-ae27-70be5e24d309"),
                SportId = Guid.Parse("91458b63-8fc3-479b-b3b8-a7a920ec984e")
            };

            await repository.AddAsync(fightingRoom);
            await repository.AddAsync(swimmingPool);
            await repository.AddAsync(muayThaiClass);

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

        [Test]
        public async Task CreateAsync_ShouldCreateRoom()
        {
            var roomFormModel = new RoomServiceModel()
            {
                Id = Guid.Parse("0262254b-0b3d-439e-a543-d6e06c7a5717"),
                Capacity = 30,
                Type = "Table tennis room"
            };

            var newRoom = await roomService.CreateAsync(roomFormModel);

            var allRooms = await roomService.AllRoomsAsync();
            int roomsCount = allRooms.Rooms.Count();

            Assert.That(roomsCount, Is.EqualTo(3));
        }

        [Test]
        public async Task DeleteAsync_ShouldDeleteARoom()
        {
            await roomService.DeleteAsync(Guid.Parse("07c92ab2-93a1-43dd-8fc8-3e16541a9573"));
            var roomsLeft = await roomService.AllRoomsAsync();
            int roomsCount = roomsLeft.Rooms.Count();

            Assert.That(roomsCount, Is.EqualTo(2));
        }

        [Test]
        public async Task DeleteAsync_ShouldNotDeleteARoom()
        {
            try
            {
                await roomService.DeleteAsync(Guid.Parse("b62f8c2e-f842-4812-ae27-70be5e24d309"));
            }
            catch (Exception ex)
            {

                Assert.That(ex.Message, Is.EqualTo("You cannot delete this room because there's currently classes, scheduled for it!"));
            }
        }

        [Test]
        public async Task EditRoomAsync_ShouldEditRoomDetails()
        {
            var roomModel = new RoomServiceModel()
            {
                Id = Guid.Parse("07c92ab2-93a1-43dd-8fc8-3e16541a9573"),
                Capacity = 17,
                Type = "Edited Fighting room"
            };

            await roomService.EditAsync(Guid.Parse("07c92ab2-93a1-43dd-8fc8-3e16541a9573"), roomModel);

            var editedRoom = await roomService.GetByIdAsync(Guid.Parse("07c92ab2-93a1-43dd-8fc8-3e16541a9573"));

            Assert.That(editedRoom.Capacity, Is.EqualTo(17));
            Assert.That(editedRoom.Type, Is.EqualTo("Edited Fighting room"));
        }

        [Test]
        public async Task ExistsByIdAsync_ShouldReturnTrue()
        {
            var roomExistsById = await roomService.ExistsByIdAsync(Guid.Parse("07c92ab2-93a1-43dd-8fc8-3e16541a9573"));

            Assert.That(roomExistsById, Is.EqualTo(true));
        }

        [Test]
        public async Task ExistsByIdAsync_ShouldReturnFalse()
        {
            var roomDoesNotExistById = await roomService.ExistsByIdAsync(Guid.Parse("07c92ab2-93a1-43dd-8fc8-3e16541a9572"));

            Assert.That(roomDoesNotExistById, Is.EqualTo(false));
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnRoomById()
        {
            var room = await roomService.GetByIdAsync(Guid.Parse("07c92ab2-93a1-43dd-8fc8-3e16541a9573"));

            Assert.That(room.Capacity, Is.EqualTo(16));
            Assert.That(room.Type, Is.EqualTo("Pool"));
        }

        [TearDown]
        public async Task TearDown()
        {
            await applicationDbContext.Database.EnsureDeletedAsync();
            await applicationDbContext.DisposeAsync();
        }
    }
}
