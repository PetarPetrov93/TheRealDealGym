using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Infrastructure.Data.Common;
using TheRealDealGym.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TheRealDealGym.Core.Services;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.UnitTests
{
    [TestFixture]
    public class BookingServiceTests
    {
        private IRepository repository;
        private IBookingService bookingService;
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
            bookingService = new BookingService(repository);


            var userOne = new ApplicationUser()
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

            var userTwo = new ApplicationUser()
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

            var booking = new Booking()
            {
                Id = Guid.Parse("c929f48d-ccd4-43a4-a429-1345a4701e33"),
                UserId = Guid.Parse("79b39756-e15f-41fe-8a96-123beb6c8ba2"),
                ClassId = Guid.Parse("ad61a644-76c7-4366-9686-82b65a42fd14")
            };

            await repository.AddAsync(userOne);
            await repository.AddAsync(userTwo);
            await repository.AddAsync(muayThaiClass);
            await repository.AddAsync(swimmingClass);
            await repository.AddAsync(booking);

            await repository.SaveChangesAsync();
        }

        [Test]
        public async Task AllUserBookingsAsync_ReturnsAllBooklingsOfAGivenUser()
        {
            var allBookingsUserOne = await bookingService.AllUserBookingsAsync(Guid.Parse("79b39756-e15f-41fe-8a96-123beb6c8ba2"));
            var allBookingsUserTwo = await bookingService.AllUserBookingsAsync(Guid.Parse("b4922f34-d4be-478f-9828-f207d277ea86"));

            Assert.That(allBookingsUserOne.Count(), Is.EqualTo(1));
            Assert.That(allBookingsUserTwo.Count(), Is.EqualTo(0));
        }

        [Test]
        public async Task BookAsync_ShouldCreateANewBookingForAUser()
        {
             await bookingService.BookAsync(Guid.Parse("c618d5f4-4597-4920-9104-3d1bc92134ea"), Guid.Parse("b4922f34-d4be-478f-9828-f207d277ea86"));
            var allBookingsUserTwo = await bookingService.AllUserBookingsAsync(Guid.Parse("b4922f34-d4be-478f-9828-f207d277ea86"));

            Assert.That(allBookingsUserTwo.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task CancelBookingAsync_ShouldCancelABookingForAUser()
        {
            await bookingService.CancelBookingAsync(Guid.Parse("ad61a644-76c7-4366-9686-82b65a42fd14"));
            var allBookingsUserOne = await bookingService.AllUserBookingsAsync(Guid.Parse("79b39756-e15f-41fe-8a96-123beb6c8ba2"));

            Assert.That(allBookingsUserOne.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task ExistsByIdAsync_ReturnsTrue()
        {
            var bookingExists = await bookingService.ExistsByIdAsync(Guid.Parse("c929f48d-ccd4-43a4-a429-1345a4701e33"));

            Assert.That(bookingExists, Is.EqualTo(true));
        }

        [Test]
        public async Task ExistsByIdAsync_ReturnsFalse()
        {
            var bookingDoeNotExist = await bookingService.ExistsByIdAsync(Guid.Parse("c929f48d-ccd4-43a4-a429-1345a4701e32"));

            Assert.That(bookingDoeNotExist, Is.EqualTo(false));
        }

        [Test]
        public async Task GetBookingIdAsync_ReturnsBookingId()
        {
            var bookingId = await bookingService.GetBookingIdAsync(Guid.Parse("79b39756-e15f-41fe-8a96-123beb6c8ba2"), Guid.Parse("ad61a644-76c7-4366-9686-82b65a42fd14"));

            Assert.That(bookingId, Is.EqualTo(Guid.Parse("c929f48d-ccd4-43a4-a429-1345a4701e33")));
        }

        [TearDown]
        public async Task TearDown()
        {
            await applicationDbContext.Database.EnsureDeletedAsync();
            await applicationDbContext.DisposeAsync();
        }
    }
}
