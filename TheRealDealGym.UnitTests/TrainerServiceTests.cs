using Microsoft.EntityFrameworkCore;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Enums;
using TheRealDealGym.Core.Services;
using TheRealDealGym.Infrastructure.Data;
using TheRealDealGym.Infrastructure.Data.Common;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.UnitTests
{
    [TestFixture]
    public class TrainerServiceTests
    {
        private IRepository repository;
        private ITrainerService trainerService;
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
            trainerService = new TrainerService(repository);

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

            var muayThaiClass2 = new Class()
            {
                Id = Guid.Parse("0e218d7a-cefa-40bd-811c-e2fde567f8bd"),
                Title = "Beginners MuayThai",
                Description = "this is begginers class for fighters",
                Price = 14,
                DateAndTime = DateTime.Now.AddDays(3),
                TrainerId = Guid.Parse("10c4a0b0-16ca-464a-bdc4-6f8fe432de42"),
                RoomId = Guid.Parse("b62f8c2e-f842-4812-ae27-70be5e24d309"),
                SportId = Guid.Parse("91458b63-8fc3-479b-b3b8-a7a920ec984e")
            };

            var muayThaiClass3 = new Class()
            {
                Id = Guid.Parse("025a605e-0db6-4665-8b13-82f1ec2e02f8"),
                Title = "Intermediate MuayThai",
                Description = "this is intermediate class for fighters",
                Price = 18,
                DateAndTime = DateTime.Now.AddDays(5),
                TrainerId = Guid.Parse("10c4a0b0-16ca-464a-bdc4-6f8fe432de42"),
                RoomId = Guid.Parse("b62f8c2e-f842-4812-ae27-70be5e24d309"),
                SportId = Guid.Parse("91458b63-8fc3-479b-b3b8-a7a920ec984e")
            };

            var swimmingClass = new Class()
            {
                Id = Guid.Parse("c618d5f4-4597-4920-9104-3d1bc92134ea"),
                Title = "Beginners Swimming",
                Description = "this is a begginers class for newcomers",
                Price = 10,
                DateAndTime = DateTime.Now.AddDays(1),
                TrainerId = Guid.Parse("04feea53-473b-44b0-8987-685eedfd862c"),
                RoomId = Guid.Parse("07c92ab2-93a1-43dd-8fc8-3e16541a9573"),
                SportId = Guid.Parse("4af95cd3-3829-4553-b6df-5d6b130a4ba8")
            };

            //var muayThaiSport = new Sport()
            //{
            //    Id = Guid.Parse("91458b63-8fc3-479b-b3b8-a7a920ec984e"),
            //    Title = "MuayThai"
            //};

            //var swimmingSport = new Sport()
            //{
            //    Id = Guid.Parse("4af95cd3-3829-4553-b6df-5d6b130a4ba8"),
            //    Title = "Swimming"
            //};

            //var fightingRoom = new Room()
            //{
            //    Id = Guid.Parse("b62f8c2e-f842-4812-ae27-70be5e24d309"),
            //    Type = "Fighting room",
            //    Capacity = 1
            //};

            //var swimmingPool = new Room()
            //{
            //    Id = Guid.Parse("07c92ab2-93a1-43dd-8fc8-3e16541a9573"),
            //    Type = "Pool",
            //    Capacity = 16,

            //};

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

            var muayThaiTrainer = new Trainer()
            {
                Id = Guid.Parse("10c4a0b0-16ca-464a-bdc4-6f8fe432de42"),
                Bio = "Muay Thai Trainer",
                YearsOfExperience = 10,
                Age = 45,
                UserId = Guid.Parse("79b39756-e15f-41fe-8a96-123beb6c8ba2")
            };

            var swimmingTrainer = new Trainer()
            {
                Id = Guid.Parse("04feea53-473b-44b0-8987-685eedfd862c"),
                Bio = "Swimming Trainer",
                YearsOfExperience = 5,
                Age = 30,
                UserId = Guid.Parse("b4922f34-d4be-478f-9828-f207d277ea86")
            };

            //await repository.AddAsync(muayThaiSport);
            //await repository.AddAsync(swimmingSport);
            //await repository.AddAsync(fightingRoom);
            //await repository.AddAsync(swimmingPool);
            await repository.AddAsync(userMuayThaiTrainer);
            await repository.AddAsync(userSwimmingTrainer);
            await repository.AddAsync(muayThaiTrainer);
            await repository.AddAsync(swimmingTrainer);
            await repository.AddAsync(muayThaiClass);
            await repository.AddAsync(muayThaiClass2);
            await repository.AddAsync(muayThaiClass3);
            await repository.AddAsync(swimmingClass);

            await repository.SaveChangesAsync();
        }

        [Test]
        public async Task AllTrainerClassesAsync_ShouldReturnAllClassesOFATrainer()
        {
            var muayThaiClasses = await trainerService.AllTrainerClassesAsync(Guid.Parse("10c4a0b0-16ca-464a-bdc4-6f8fe432de42"));
            var swimmingClasses = await trainerService.AllTrainerClassesAsync(Guid.Parse("04feea53-473b-44b0-8987-685eedfd862c"));

            Assert.That(muayThaiClasses.Count(), Is.EqualTo(3));
            Assert.That(swimmingClasses.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task AllTrainersAsync_ShouldReturnAllTrainers_NameAsc()
        {
            var allTrainersNameAsc = await trainerService.AllTrainersAsync(StaffSorting.NameAscending);
            var firstTrainerName = allTrainersNameAsc.Trainers.First().FullName;

            Assert.That(firstTrainerName, Is.EqualTo("Georgi Georgiev"));
        }

        [Test]
        public async Task AllTrainersAsync_ShouldReturnAllTrainers_NameDesc()
        {
            var allTrainersNameDesc = await trainerService.AllTrainersAsync(StaffSorting.NameDescending);
            var firstTrainerName = allTrainersNameDesc.Trainers.First().FullName;

            Assert.That(firstTrainerName, Is.EqualTo("Petar Petrov"));
        }

        [Test]
        public async Task ExistsByUserIdAsync_ShouldReturnTrue()
        {
            var trainerByUserIdExists = await trainerService.ExistsByUserIdAsync(Guid.Parse("b4922f34-d4be-478f-9828-f207d277ea86"));

            Assert.That(trainerByUserIdExists, Is.EqualTo(true));
        }

        [Test]
        public async Task ExistsByUserIdAsync_ShouldReturnFalse()
        {
            var trainerByUserIdExists = await trainerService.ExistsByUserIdAsync(Guid.Parse("b4922f34-d4be-478f-9828-f207d277ea85"));

            Assert.That(trainerByUserIdExists, Is.EqualTo(false));
        }

        [TearDown]
        public async Task TearDown()
        {
            await applicationDbContext.Database.EnsureDeletedAsync();
            await applicationDbContext.DisposeAsync();
        }
    }
}
