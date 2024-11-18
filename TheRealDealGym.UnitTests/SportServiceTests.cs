using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Infrastructure.Data.Common;
using TheRealDealGym.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TheRealDealGym.Core.Services;
using TheRealDealGym.Infrastructure.Data.Models;
using TheRealDealGym.Core.Enums;
using TheRealDealGym.Core.Models.Room;
using TheRealDealGym.Core.Models.Sport;

namespace TheRealDealGym.UnitTests
{
    [TestFixture]
    public class SportServiceTests
    {
        private IRepository repository;
        private ISportService sportService;
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
            sportService = new SportService(repository);

            var muayThaiSport = new Sport()
            {
                Id = Guid.Parse("91458b63-8fc3-479b-b3b8-a7a920ec984e"),
                Title = "MuayThai"
            };

            var swimmingSport = new Sport()
            {
                Id = Guid.Parse("4af95cd3-3829-4553-b6df-5d6b130a4ba8"),
                Title = "Swimming"
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

            await repository.AddAsync(muayThaiSport);
            await repository.AddAsync(swimmingSport);
            await repository.AddAsync(muayThaiClass);

            await repository.SaveChangesAsync();
        }

        [Test]
        public async Task AllSportsAsync_ShouldReturnAllSportsByTitleAsc()
        {
            var allSportsByTitleAsc = await sportService.AllSportsAsync(SportSorting.TitleAscending);
            var firstSportTitle = allSportsByTitleAsc.Sports.First().Title;

            Assert.That(firstSportTitle, Is.EqualTo("MuayThai"));
        }

        [Test]
        public async Task AllSportsAsync_ShouldReturnAllSportsByTitleDesc()
        {
            var allSportsByTitleDesc = await sportService.AllSportsAsync(SportSorting.TitleDescending);
            var firstSportTitle = allSportsByTitleDesc.Sports.First().Title;

            Assert.That(firstSportTitle, Is.EqualTo("Swimming"));
        }

        [Test]
        public async Task CreateAsync_ShouldCreateSport()
        {
            var sportInfoModel = new SportInfoModel()
            {
                Id = Guid.Parse("ddbe138c-ef3e-48d7-b025-5316685304ed"),
                Title = "Table tennis"
            };

            var newSport = await sportService.CreateAsync(sportInfoModel);

            var allSports = await sportService.AllSportsAsync();
            int sportsCount = allSports.Sports.Count();

            Assert.That(sportsCount, Is.EqualTo(3));
        }

        [Test]
        public async Task DeleteAsync_ShouldDeleteASport()
        {
            await sportService.DeleteAsync(Guid.Parse("4af95cd3-3829-4553-b6df-5d6b130a4ba8"));
            var sportsLeft = await sportService.AllSportsAsync();
            int sportsCount = sportsLeft.Sports.Count();

            Assert.That(sportsCount, Is.EqualTo(2));
        }

        [Test]
        public async Task DeleteAsync_ShouldNotDeleteASport()
        {
            try
            {
                await sportService.DeleteAsync(Guid.Parse("91458b63-8fc3-479b-b3b8-a7a920ec984e"));
            }
            catch (Exception ex)
            {

                Assert.That(ex.Message, Is.EqualTo("You cannot delete this sport because there's currently classes, scheduled for it!"));
            }
        }

        [Test]
        public async Task EditSportAsync_ShouldEditSportDetails()
        {
            var sportInfoModel = new SportInfoModel()
            {
                Id = Guid.Parse("4af95cd3-3829-4553-b6df-5d6b130a4ba8"),
                Title = "Swimming edited"
            };

            await sportService.EditAsync(Guid.Parse("4af95cd3-3829-4553-b6df-5d6b130a4ba8"), sportInfoModel);

            var editedSport = await sportService.GetByIdAsync(Guid.Parse("4af95cd3-3829-4553-b6df-5d6b130a4ba8"));

            Assert.That(editedSport.Title, Is.EqualTo("Swimming edited"));
        }

        [Test]
        public async Task EditSportAsync_ShouldNotEditSportDetails()
        {
            var sportInfoModel = new SportInfoModel()
            {
                Id = Guid.Parse("91458b63-8fc3-479b-b3b8-a7a920ec984e"),
                Title = "MuayThai edited"
            };

            try
            {
                await sportService.EditAsync(Guid.Parse("91458b63-8fc3-479b-b3b8-a7a920ec984e"), sportInfoModel);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("You cannot edit this sport because there's currently classes, scheduled for it!"));
            }

        }

        [Test]
        public async Task ExistsByIdAsync_ShouldReturnTrue()
        {
            var sportExistsById = await sportService.ExistsByIdAsync(Guid.Parse("91458b63-8fc3-479b-b3b8-a7a920ec984e"));

            Assert.That(sportExistsById, Is.EqualTo(true));
        }

        [Test]
        public async Task ExistsByIdAsync_ShouldReturnFalse()
        {
            var sportDoesNotExistById = await sportService.ExistsByIdAsync(Guid.Parse("91458b63-8fc3-479b-b3b8-a7a920ec984a"));

            Assert.That(sportDoesNotExistById, Is.EqualTo(false));
        }

        [Test]
        public async Task GetByIdAsync_ShouldReturnSportById()
        {
            var sport = await sportService.GetByIdAsync(Guid.Parse("91458b63-8fc3-479b-b3b8-a7a920ec984e"));

            Assert.That(sport.Title, Is.EqualTo("MuayThai"));
        }

        [TearDown]
        public async Task TearDown()
        {
            await applicationDbContext.Database.EnsureDeletedAsync();
            await applicationDbContext.DisposeAsync();
        }
    }
}
