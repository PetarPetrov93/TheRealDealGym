using Microsoft.EntityFrameworkCore;
using Moq;
using TheRealDealGym.Core.Contracts;
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
        public void SetUp()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("GymDB")
                .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task AllAsyncReturnsAllClasses()
        {
            var repo = new Repository(applicationDbContext);
            classService = new ClassService(repo);

            await repo.AddAsync(new Class()
            {
                Id = Guid.Parse("4d7eadef-b3ad-4fe2-b9b2-ff9c0a9bf9e6"),
                Title = "",
                Description = "",
                Price = 0,
                DateAndTime = DateTime.Now,
                TrainerId = Guid.Parse("10c4a0b0-16ca-464a-bdc4-6f8fe432de42"),
                RoomId = Guid.Parse("b62f8c2e-f842-4812-ae27-70be5e24d309"),
                SportId = Guid.Parse("91458b63-8fc3-479b-b3b8-a7a920ec984e")
            });
            await repo.AddAsync(new Class()
            {
                Id = Guid.Parse("18f264d7-4715-4119-b11a-ff41be6fe491"),
                Title = "",
                Description = "",
                Price = 0,
                DateAndTime = DateTime.Now,
                TrainerId = Guid.Parse("04feea53-473b-44b0-8987-685eedfd862c"),
                RoomId = Guid.Parse("07c92ab2-93a1-43dd-8fc8-3e16541a9573"),
                SportId = Guid.Parse("4af95cd3-3829-4553-b6df-5d6b130a4ba8")
            });

            await repo.SaveChangesAsync();
            var allClasses = await classService.AllAsync();

            Assert.That(3, Is.EqualTo(allClasses.TotalClassesCount));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
