using Microsoft.EntityFrameworkCore;
using Moq;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Enums;
using TheRealDealGym.Core.Models.Class;
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

            await repository.AddAsync(muayThaiSport);
            await repository.AddAsync(swimmingSport);
            await repository.AddAsync(fightingRoom);
            await repository.AddAsync(swimmingPool);
            await repository.AddAsync(userMuayThaiTrainer);
            await repository.AddAsync(userSwimmingTrainer);
            await repository.AddAsync(muayThaiTrainer);
            await repository.AddAsync(swimmingTrainer);
            await repository.AddAsync(muayThaiClass);
            await repository.AddAsync(swimmingClass);

            await repository.SaveChangesAsync();
        }

        [Test]
        public async Task AllAsync_ReturnsAllClasses()
        {
            var allClasses = await classService.AllAsync();

            Assert.That(allClasses.TotalClassesCount, Is.EqualTo(2));
        }

        [Test]
        public async Task AllAsync_ReturnsAllClassesFilteredBySportTitle()
        {
            var allClasses = await classService.AllAsync("Swimming");

            Assert.That(allClasses.TotalClassesCount, Is.EqualTo(1));
        }

        [Test]
        public async Task AllAsync_ReturnsAllClassesFilteredBySearchTerm()
        {
            var allClasses = await classService.AllAsync(null, "Thai");

            Assert.That(allClasses.TotalClassesCount, Is.EqualTo(1));
        }

        [Test]
        public async Task AllAsync_ReturnsAllClassesSortedByDateDesc()
        {
            var allClasses = await classService.AllAsync(null, null, ClassSorting.DateDescending);
            var classTitle = allClasses.Classes.First().Title;

            Assert.That(classTitle, Is.EqualTo("Beginners Swimming"));
        }

        [Test]
        public async Task AllAsync_ReturnsAllClassesSortedByDateAsc()
        {
            var allClasses = await classService.AllAsync(null, null, ClassSorting.DateAscending);
            var classTitle = allClasses.Classes.First().Title;

            Assert.That(classTitle, Is.EqualTo("Advanced MuayThai"));
        }

        [Test]
        public async Task AllAsync_ReturnsAllClassesSortedByTimeOfDayDesc()
        {
            var allClasses = await classService.AllAsync(null, null, ClassSorting.TimeDescending);
            var classTitle = allClasses.Classes.First().Title;

            Assert.That(classTitle, Is.EqualTo("Beginners Swimming"));
        }

        [Test]
        public async Task AllAsync_ReturnsAllClassesSortedByTimeOfDayAsc()
        {
            var allClasses = await classService.AllAsync(null, null, ClassSorting.TimeAscending);
            var classTitle = allClasses.Classes.First().Title;

            Assert.That(classTitle, Is.EqualTo("Advanced MuayThai"));
        }

        [Test]
        public async Task AllClassesAsync_ReturnsAllClasses()
        {
            var allClasses = await classService.AllClassesAsync();
            var count = allClasses.Count();

            Assert.That(count, Is.EqualTo(2));
        }

        [Test]
        public async Task AllRoomsAsync_ReturnsAllRooms()
        {
            var allRooms = await classService.AllRoomAsync();
            var count = allRooms.Count();

            Assert.That(count, Is.EqualTo(2));
        }

        [Test]
        public async Task AllSportNamesAsync_ReturnsAllSportNames()
        {
            var allSportNames = await classService.AllSportNamesAsync();
            var count = allSportNames.Count();

            Assert.That(count, Is.EqualTo(2));
        }

        [Test]
        public async Task AllSportsAsync_ReturnsAllSports()
        {
            var allSports = await classService.AllSportAsync();
            var count = allSports.Count();

            Assert.That(count, Is.EqualTo(2));
        }

        [Test]
        public async Task ClassDetailsByIdAsync_ReturnsClassDetails()
        {
            var classDetails = await classService.ClassDetailsByIdAsync(Guid.Parse("c618d5f4-4597-4920-9104-3d1bc92134ea"));
            var classTitle = classDetails.Title;

            Assert.That(classTitle, Is.EqualTo("Beginners Swimming"));
        }

        [Test]
        public async Task CreateAsync_ShouldCreateClass()
        {
            var classFormModel = new ClassFormModel()
            {
                Title = "New Class - swimming",
                Description = "This is a brand new swimming class",
                Date = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd"),
                Time = DateTime.Now.AddHours(1).ToString("HH:mm:ss"),
                Price = 14.50m,
                SportId = Guid.Parse("4af95cd3-3829-4553-b6df-5d6b130a4ba8"),
                RoomId = Guid.Parse("07c92ab2-93a1-43dd-8fc8-3e16541a9573")
            };

            var newClass = await classService.CreateAsync(classFormModel, Guid.Parse("04feea53-473b-44b0-8987-685eedfd862c"));

            var allClasses = await classService.AllClassesAsync();
            int classesCount = allClasses.Count();

            Assert.That(classesCount, Is.EqualTo(3));
        }

        [Test]
        public async Task CreateAsync_ShouldReturnRoomNotAvailable()
        {
            var classFormModel = new ClassFormModel()
            {
                Title = "New Class - swimming",
                Description = "This is a brand new swimming class",
                Date = DateTime.Now.ToString("yyyy-MM-dd"),
                Time = DateTime.Now.AddMinutes(2).ToString("HH:mm:ss"),
                Price = 14.50m,
                SportId = Guid.Parse("4af95cd3-3829-4553-b6df-5d6b130a4ba8"),
                RoomId = Guid.Parse("07c92ab2-93a1-43dd-8fc8-3e16541a9573")
            };

            try
            {
                var newClass = await classService.CreateAsync(classFormModel, Guid.Parse("04feea53-473b-44b0-8987-685eedfd862c"));
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Selected room is not available for the chosen time slot."));
            }
        }

        [Test]
        public async Task CreateAsync_ShouldReturnSelectValidDateAndTime()
        {
            var classFormModel = new ClassFormModel()
            {
                Title = "New Class - swimming",
                Description = "This is a brand new swimming class",
                Date = DateTime.Now.ToString("yyyy-MM-dd"),
                Time = DateTime.Now.AddMinutes(-2).ToString("HH:mm:ss"),
                Price = 14.50m,
                SportId = Guid.Parse("4af95cd3-3829-4553-b6df-5d6b130a4ba8"),
                RoomId = Guid.Parse("07c92ab2-93a1-43dd-8fc8-3e16541a9573")
            };

            try
            {
                var newClass = await classService.CreateAsync(classFormModel, Guid.Parse("04feea53-473b-44b0-8987-685eedfd862c"));
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Please set a valid date and time for this class."));
            }
        }

        [Test]
        public async Task DeleteAsync_ShouldDeleteAClass()
        {
            await classService.DeleteAsync(Guid.Parse("c618d5f4-4597-4920-9104-3d1bc92134ea"));
            var classesLeft = await classService.AllClassesAsync();
            int classesCount = classesLeft.Count();

            Assert.That(classesCount, Is.EqualTo(2));
        }

        [Test]
        public async Task EditAsync_ShouldEditAClass()
        {
            var classToEdit = new ClassFormModel()
            {
                Title = "Edited Advanced Muay Thai Class",
                Description = "This class is dited",
                Date = DateTime.Now.AddDays(5).ToString("yyyy-MM-dd"),
                Time = DateTime.Now.ToString("HH:mm:ss"),
                Price = 12m,
                RoomId = Guid.Parse("b62f8c2e-f842-4812-ae27-70be5e24d309"),
                SportId = Guid.Parse("91458b63-8fc3-479b-b3b8-a7a920ec984e")
            };
            await classService.EditAsync(Guid.Parse("ad61a644-76c7-4366-9686-82b65a42fd14"), classToEdit);

            var editedClass = await classService.GetClassFormModelByIdAsync(Guid.Parse("ad61a644-76c7-4366-9686-82b65a42fd14"));
            var editedTitle = editedClass.Title;
            var editedDescription = editedClass.Description;

            Assert.That(editedTitle, Is.EqualTo("Edited Advanced Muay Thai Class"));
            Assert.That(editedDescription, Is.EqualTo("This class is dited"));
        }

        [Test]
        public async Task EditAsync_ShouldNotBeEdited_UsersHaveBooked()
        {
            var booking = new Booking()
            {
                Id = Guid.Parse("4ae01d59-dba9-4b9a-a6f8-48fd88aa9c25"),
                ClassId = Guid.Parse("ad61a644-76c7-4366-9686-82b65a42fd14"),
                UserId = Guid.Parse("649fe967-dbfe-4679-864f-43c81a17ad61")
            };

            var classToEdit = new ClassFormModel()
            {
                Title = "Edited Advanced Muay Thai Class",
                Description = "This class is dited",
                Date = DateTime.Now.AddDays(5).ToString("yyyy-MM-dd"),
                Time = DateTime.Now.ToString("HH:mm:ss"),
                Price = 12m,
                RoomId = Guid.Parse("b62f8c2e-f842-4812-ae27-70be5e24d309"),
                SportId = Guid.Parse("91458b63-8fc3-479b-b3b8-a7a920ec984e")
            };

            try
            {
                await classService.EditAsync(Guid.Parse("ad61a644-76c7-4366-9686-82b65a42fd14"), classToEdit);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("You cannot edit this class because users have already booked for it!"));
            }
        }

        [Test]
        public async Task EditAsync_ShouldNotBeEdited_RoomNotAvailable()
        {
            var classToEdit = new ClassFormModel()
            {
                Title = "Edited Advanced Muay Thai Class",
                Description = "This class is dited",
                Date = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"),
                Time = DateTime.Now.ToString("HH:mm:ss"),
                Price = 12m,
                RoomId = Guid.Parse("07c92ab2-93a1-43dd-8fc8-3e16541a9573"),
                SportId = Guid.Parse("91458b63-8fc3-479b-b3b8-a7a920ec984e")
            };

            try
            {
                await classService.EditAsync(Guid.Parse("ad61a644-76c7-4366-9686-82b65a42fd14"), classToEdit);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Selected room is not available for the chosen time slot."));
            }
        }

        [Test]
        public async Task EditAsync_ShouldNotBeEdited_InvalidDate()
        {
            var classToEdit = new ClassFormModel()
            {
                Title = "Edited Advanced Muay Thai Class",
                Description = "This class is dited",
                Date = DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd"),
                Time = DateTime.Now.ToString("HH:mm:ss"),
                Price = 12m,
                RoomId = Guid.Parse("b62f8c2e-f842-4812-ae27-70be5e24d309"),
                SportId = Guid.Parse("91458b63-8fc3-479b-b3b8-a7a920ec984e")
            };

            try
            {
                await classService.EditAsync(Guid.Parse("ad61a644-76c7-4366-9686-82b65a42fd14"), classToEdit);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Please set a valid date and time for this class."));
            }
        }

        [Test]
        public async Task EditAsync_ShouldNotBeEdited_InvalidTime()
        {
            var classToEdit = new ClassFormModel()
            {
                Title = "Edited Advanced Muay Thai Class",
                Description = "This class is dited",
                Date = DateTime.Now.ToString("yyyy-MM-dd"),
                Time = DateTime.Now.AddHours(-8).ToString("HH:mm:ss"),
                Price = 12m,
                RoomId = Guid.Parse("b62f8c2e-f842-4812-ae27-70be5e24d309"),
                SportId = Guid.Parse("91458b63-8fc3-479b-b3b8-a7a920ec984e")
            };

            try
            {
                await classService.EditAsync(Guid.Parse("ad61a644-76c7-4366-9686-82b65a42fd14"), classToEdit);
            }
            catch (Exception ex)
            {
                Assert.That(ex.Message, Is.EqualTo("Please set a valid date and time for this class."));
            }
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnTrue()
        {
            var doesClassExist = await classService.ExistsAsync(Guid.Parse("c618d5f4-4597-4920-9104-3d1bc92134ea"));

            Assert.That(doesClassExist, Is.EqualTo(true));
        }

        [Test]
        public async Task ExistsAsync_ShouldReturnFalse()
        {
            var doesClassExist = await classService.ExistsAsync(Guid.Parse("c618d5f4-4597-4920-9104-3d1bc92134eB"));

            Assert.That(doesClassExist, Is.EqualTo(false));
        }

        [Test]
        public async Task GetClassFormModelByIdAsync_ShouldReturnClassFormModel()
        {
            var classFormModel = await classService.GetClassFormModelByIdAsync(Guid.Parse("ad61a644-76c7-4366-9686-82b65a42fd14"));
            var classTitle = classFormModel.Title;
            var classDescription = classFormModel.Description;

            Assert.That(classTitle, Is.EqualTo("Advanced MuayThai"));
            Assert.That(classDescription, Is.EqualTo("this is advanced class for fighters"));
        }

        [Test]
        public async Task HasTrainerWithIdAsync_ShouldReturnTrue()
        {
            var hasTrainer = await classService.HasTrainerWithIdAsync(Guid.Parse("ad61a644-76c7-4366-9686-82b65a42fd14"), Guid.Parse("79b39756-e15f-41fe-8a96-123beb6c8ba2"));

            Assert.That(hasTrainer, Is.EqualTo(true));
        }

        [Test]
        public async Task HasTrainerWithIdAsync_ShouldReturnFalse()
        {
            var hasTrainer = await classService.HasTrainerWithIdAsync(Guid.Parse("ad61a644-76c7-4366-9686-82b65a42fd14"), Guid.Parse("79b39756-e15f-41fe-8a96-123beb6c8ba1"));

            Assert.That(hasTrainer, Is.EqualTo(false));
        }

        [Test]
        public async Task RoomExistsAsync_ShouldReturnTrue()
        {
            var roomExists = await classService.RoomExistsAsync(Guid.Parse("07c92ab2-93a1-43dd-8fc8-3e16541a9573"));

            Assert.That(roomExists, Is.EqualTo(true));
        }

        [Test]
        public async Task RoomExistsAsync_ShouldReturnFalse()
        {
            var roomExists = await classService.RoomExistsAsync(Guid.Parse("07c92ab2-93a1-43dd-8fc8-3e16541a9572"));

            Assert.That(roomExists, Is.EqualTo(false));
        }

        [Test]
        public async Task SportExistsAsync_ShouldReturnTrue()
        {
            var sportExists = await classService.SportExistsAsync(Guid.Parse("4af95cd3-3829-4553-b6df-5d6b130a4ba8"));

            Assert.That(sportExists, Is.EqualTo(true));
        }

        [Test]
        public async Task SportExistsAsync_ShouldReturnFalse()
        {
            var sportExists = await classService.SportExistsAsync(Guid.Parse("4af95cd3-3829-4553-b6df-5d6b130a4ba4"));

            Assert.That(sportExists, Is.EqualTo(false));
        }

        [Test]
        public async Task HasAvailableSpacesAsync_ShouldReturnTrue()
        {
            var hasAvailableSpaces = await classService.HasAvailableSpacesAsync(Guid.Parse("ad61a644-76c7-4366-9686-82b65a42fd14"));

            Assert.That(hasAvailableSpaces, Is.EqualTo(true));
        }

        [TearDown]
        public async Task TearDown()
        {
            await applicationDbContext.Database.EnsureDeletedAsync();
            await applicationDbContext.DisposeAsync();
        }
    }
}
