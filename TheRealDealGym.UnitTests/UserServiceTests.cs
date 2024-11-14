using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Infrastructure.Data.Common;
using TheRealDealGym.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TheRealDealGym.Core.Services;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.UnitTests
{
    [TestFixture]
    public class UserServiceTests
    {
        private IRepository repository;
        private IUserService userService;
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
            userService = new UserService(repository);

            var userMuayThaiTrainer = new ApplicationUser()
            {
                Id = Guid.Parse("79b39756-e15f-41fe-8a96-123beb6c8ba2"),
                FirstName = "Petar",
                LastName = "Petrov",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0
            };

            var userSwimmingTrainer = new ApplicationUser()
            {
                Id = Guid.Parse("b4922f34-d4be-478f-9828-f207d277ea86"),
                FirstName = "Georgi",
                LastName = "Georgiev",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0
            };

            await repository.AddAsync(userMuayThaiTrainer);
            await repository.AddAsync(userSwimmingTrainer);

            await repository.SaveChangesAsync();
        }

        [Test]
        public async Task UserFullNameAsync_ShouldReturnUserFullName()
        {
            var petarPetrov = await userService.UserFullNameAsync(Guid.Parse("79b39756-e15f-41fe-8a96-123beb6c8ba2"));
            var georgiGeorgiev = await userService.UserFullNameAsync(Guid.Parse("b4922f34-d4be-478f-9828-f207d277ea86"));

            Assert.That(petarPetrov, Is.EqualTo("Petar Petrov"));
            Assert.That(georgiGeorgiev, Is.EqualTo("Georgi Georgiev"));
        }

        [TearDown]
        public async Task TearDown()
        {
            await applicationDbContext.Database.EnsureDeletedAsync();
            await applicationDbContext.DisposeAsync();
        }
    }
}
