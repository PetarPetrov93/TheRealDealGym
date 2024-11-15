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

        [TearDown]
        public async Task TearDown()
        {
            await applicationDbContext.Database.EnsureDeletedAsync();
            await applicationDbContext.DisposeAsync();
        }
    }
}
