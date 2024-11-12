using Microsoft.EntityFrameworkCore;
using Moq;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Enums;
using TheRealDealGym.Core.Services;
using TheRealDealGym.Infrastructure.Data;
using TheRealDealGym.Infrastructure.Data.Common;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.UnitTests
{
    [TestFixture]
    public class ClassServiceTests
    {
        private IRepository repository;
        private IClassService classService;
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
            classService = new ClassService(repository);

            await repository.AddAsync(new Class()
            {
                Title = "Advanced MuayThai",
                Description = "",
                Price = 0,
                DateAndTime = DateTime.Now,
                TrainerId = Guid.Parse("10c4a0b0-16ca-464a-bdc4-6f8fe432de42"),
                RoomId = Guid.Parse("b62f8c2e-f842-4812-ae27-70be5e24d309"),
                SportId = Guid.Parse("91458b63-8fc3-479b-b3b8-a7a920ec984e")
            });
            await repository.AddAsync(new Class()
            {
                Title = "Beginners Swimming",
                Description = "some other class",
                Price = 10,
                DateAndTime = DateTime.Now.AddDays(1),
                TrainerId = Guid.Parse("04feea53-473b-44b0-8987-685eedfd862c"),
                RoomId = Guid.Parse("07c92ab2-93a1-43dd-8fc8-3e16541a9573"),
                SportId = Guid.Parse("4af95cd3-3829-4553-b6df-5d6b130a4ba8")
            });

            await repository.AddAsync(new Sport()
            {
                Id = Guid.Parse("4af95cd3-3829-4553-b6df-5d6b130a4ba8"),
                Title = "Swimming"
            });

            await repository.AddAsync(new Sport()
            {
                Id = Guid.Parse("91458b63-8fc3-479b-b3b8-a7a920ec984e"),
                Title = "MuayThai"
            });

            await repository.AddAsync(new Room()
            {
                Id = Guid.Parse("07c92ab2-93a1-43dd-8fc8-3e16541a9573"),
                Type = "Pool",
                Capacity = 16
            });

            await repository.AddAsync(new Room()
            {
                Id = Guid.Parse("b62f8c2e-f842-4812-ae27-70be5e24d309"),
                Type = "Fighting room",
                Capacity = 40
            });

            await repository.SaveChangesAsync();
        }

        //AllAsync() method tests:
        [Test]
        public async Task AllAsyncReturnsAllClasses()
        {
            var allClasses = await classService.AllAsync();

            Assert.That(allClasses.TotalClassesCount, Is.EqualTo(2));
        }

        [Test]
        public async Task AllAsyncReturnsAllClassesFilteredBySportTitle()
        {
            var allClasses = await classService.AllAsync("Swimming");

            Assert.That(allClasses.TotalClassesCount, Is.EqualTo(1));
        }

        [Test]
        public async Task AllAsyncReturnsAllClassesFilteredBySearchTerm()
        {
            var allClasses = await classService.AllAsync(null, "nothing");

            Assert.That(allClasses.TotalClassesCount, Is.EqualTo(0));
        }

        [Test]
        public async Task AllAsyncReturnsAllClassesSortedByDateDesc()
        {
            var allClasses = await classService.AllAsync(null, null, ClassSorting.DateDescending);
            var classTitle = allClasses.Classes.First().Title;

            Assert.That(classTitle, Is.EqualTo("Beginners Swimming"));
        }

        [Test]
        public async Task AllClassesAsyncReturnsAllClasses()
        {
            var allClasses = await classService.AllClassesAsync();
            var count = allClasses.Count();

            Assert.That(count, Is.EqualTo(2));
        }

        [Test]
        public async Task AllRoomsAsyncReturnsAllRooms()
        {
            var allRooms = await classService.AllRoomAsync();
            var count = allRooms.Count();

            Assert.That(count, Is.EqualTo(2));
        }

        [Test]
        public async Task AllSportNamesAsyncReturnsAllSportNames()
        {
            var allSportNames = await classService.AllSportNamesAsync();
            var count = allSportNames.Count();

            Assert.That(count, Is.EqualTo(2));
        }

        [Test]
        public async Task AllSportsAsyncReturnsAllSports()
        {
            var allSports = await classService.AllSportAsync();
            var count = allSports.Count();

            Assert.That(count, Is.EqualTo(2));
        }

        [TearDown]
        public async Task TearDown()
        {
            await applicationDbContext.Database.EnsureDeletedAsync();
            await applicationDbContext.DisposeAsync();
        }
    }
}
