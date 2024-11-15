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
            await repository.AddAsync(muayThaiSport);
            await repository.AddAsync(swimmingSport);

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



        [TearDown]
        public async Task TearDown()
        {
            await applicationDbContext.Database.EnsureDeletedAsync();
            await applicationDbContext.DisposeAsync();
        }
    }
}
