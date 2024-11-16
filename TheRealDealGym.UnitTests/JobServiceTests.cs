using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Infrastructure.Data.Common;
using TheRealDealGym.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TheRealDealGym.Core.Services;
using TheRealDealGym.Infrastructure.Data.Models;
using TheRealDealGym.Core.Enums;
using TheRealDealGym.Core.Models.Class;
using TheRealDealGym.Core.Models.Job;
using TheRealDealGym.Core.Models.Trainer;

namespace TheRealDealGym.UnitTests
{
    [TestFixture]
    public class JobServiceTests
    {
        private IRepository repository;
        private IJobService jobService;
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
            jobService = new JobService(repository);

            var jobAdvertActive = new JobAdvert()
            {
                Id = new Guid("4990319a-041d-4d42-80ae-4e07849a29aa"),
                Title = "Fitness coach full time",
                Description = "We are looking for a motivated and experienced fitness coach for a position in our great team.",
                IsActive = true
            };

            var jobAdvertActive2 = new JobAdvert()
            {
                Id = new Guid("f7e314b1-060e-4a4d-94f0-2a6b7d39e393"),
                Title = "Powerlifting coach",
                Description = "We are looking for a motivated and experienced powerlifting coach for a position in our great team.",
                IsActive = true
            };

            var jobAdvertInactive = new JobAdvert()
            {
                Id = new Guid("5d2f453e-1cc7-47d5-94ae-a58868b76b52"),
                Title = "CrossFit coach full time",
                Description = "We are looking for a motivated and experienced CrossFit coach for a position in our great team.",
                IsActive = false
            };

            var jobApplication = new JobApplication()
            {
                Id = Guid.Parse("ab139913-bcfe-4a60-af9c-cea8dd0a16c2"),
                JobAdvertId = Guid.Parse("4990319a-041d-4d42-80ae-4e07849a29aa"),
                UserId = Guid.Parse("79b39756-e15f-41fe-8a96-123beb6c8ba2"),
                Age = 28,
                YearsOfExperience = 4,
                Bio = "I am a very good fitness coach!"
            };

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

            await repository.AddAsync(jobAdvertActive);
            await repository.AddAsync(jobAdvertActive2);
            await repository.AddAsync(jobAdvertInactive);
            await repository.AddAsync(jobApplication);
            await repository.AddAsync(userOne);
            await repository.AddAsync(userTwo);

            await repository.SaveChangesAsync();
        }

        [Test]
        public async Task AllJobAdvertsForAdminAsync_ReturnsAllActiveJobAdverts()
        {
            var allActiveJobAdverts = await jobService.AllJobAdvertsForAdminAsync("Active");

            Assert.That(allActiveJobAdverts.TotalJobAdvertsCount, Is.EqualTo(2));
        }

        [Test]
        public async Task AllJobAdvertsForAdminAsync_ReturnsAllInActiveJobAdverts()
        {
            var allActiveJobAdverts = await jobService.AllJobAdvertsForAdminAsync("Inactive");

            Assert.That(allActiveJobAdverts.TotalJobAdvertsCount, Is.EqualTo(1));
        }

        [Test]
        public async Task AllJobAdvertsForAdminAsync_ReturnsAllJobAdvertsSortedByDateAsc()
        {
            var allJobAdverts = await jobService.AllJobAdvertsForAdminAsync(null, JobAdvertSorting.TitleAscending);
            var firstJobAdvertTitle = allJobAdverts.JobAdverts.First().Title;

            Assert.That(firstJobAdvertTitle, Is.EqualTo("CrossFit coach full time"));
        }

        [Test]
        public async Task AllJobAdvertsForAdminAsync_ReturnsAllJobAdvertsSortedByDateDesc()
        {
            var allJobAdverts = await jobService.AllJobAdvertsForAdminAsync(null, JobAdvertSorting.TitleDescending);
            var firstJobAdvertTitle = allJobAdverts.JobAdverts.First().Title;

            Assert.That(firstJobAdvertTitle, Is.EqualTo("Powerlifting coach"));
        }

        [Test]
        public async Task AllJobAdvertsForAdminAsync_ReturnsAllActiveJobAdvertsSortedByDateAsc()
        {
            var allActiveJobAdverts = await jobService.AllJobAdvertsForAdminAsync("Active", JobAdvertSorting.TitleAscending);
            var firstJobAdvertTitle = allActiveJobAdverts.JobAdverts.First().Title;

            Assert.That(firstJobAdvertTitle, Is.EqualTo("Fitness coach full time"));
            Assert.That(allActiveJobAdverts.JobAdverts.Count(), Is.EqualTo(2));
        }

        [Test]
        public async Task AllJobAdvertsForAdminAsync_ReturnsAllInactiveJobAdvertsSortedByDateAsc()
        {
            var allInactiveJobAdverts = await jobService.AllJobAdvertsForAdminAsync("Inactive", JobAdvertSorting.TitleDescending);
            var firstJobAdvertTitle = allInactiveJobAdverts.JobAdverts.First().Title;

            Assert.That(firstJobAdvertTitle, Is.EqualTo("CrossFit coach full time"));
            Assert.That(allInactiveJobAdverts.JobAdverts.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task AllActiveJobAdvertsForUsersAsync_ShouldReturnJobAdsWhichTheUserHasNotAppliedFor()
        {
            var allJobAdsWhichTheUserHasNotAppliedFor = await jobService.AllActiveJobAdvertsForUsersAsync(Guid.Parse("79b39756-e15f-41fe-8a96-123beb6c8ba2"));
            var firstJobAd = allJobAdsWhichTheUserHasNotAppliedFor.First();

            Assert.That(firstJobAd.Id, Is.EqualTo(Guid.Parse("f7e314b1-060e-4a4d-94f0-2a6b7d39e393")));
            Assert.That(firstJobAd.Title, Is.EqualTo("Powerlifting coach"));
            Assert.That(allJobAdsWhichTheUserHasNotAppliedFor.Count(), Is.EqualTo(1));
        }

        [Test]
        public async Task CreateAsync_ShouldCreateJobAdvert()
        {
            var jobAdvertModel = new JobAdvertModel()
            {
                Id = Guid.Parse("c7cfc9d5-73c5-4ce8-9714-afc289e3751f"),
                Title = "New Job Ad - Yoga coach",
                Description = "We are looking for a new Yoga coach."
            };

            var newJobAd = await jobService.CreateAsync(jobAdvertModel);

            var allJobAds = await jobService.AllJobAdvertsForAdminAsync();
            int jobAdsCount = allJobAds.TotalJobAdvertsCount;

            Assert.That(jobAdsCount, Is.EqualTo(4));
        }

        [Test]
        public async Task ActivateAsync_ShouldActivateTheJobAd()
        {
            await jobService.ActivateAsync(Guid.Parse("5d2f453e-1cc7-47d5-94ae-a58868b76b52"));
            var allJobs = await jobService.AllJobAdvertsForAdminAsync();
            var currJob = allJobs.JobAdverts.First(j => j.Id == Guid.Parse("5d2f453e-1cc7-47d5-94ae-a58868b76b52"));

            Assert.That(currJob.IsActive, Is.EqualTo(true));
            Assert.That(currJob.Title, Is.EqualTo("CrossFit coach full time"));
        }

        [Test]
        public async Task ActivateAsync_ShouldDeactivateTheJobAd()
        {
            await jobService.DeactivateAsync(Guid.Parse("f7e314b1-060e-4a4d-94f0-2a6b7d39e393"));
            var allJobs = await jobService.AllJobAdvertsForAdminAsync("Inactive");
            var currJob = allJobs.JobAdverts.First(j => j.Id == Guid.Parse("f7e314b1-060e-4a4d-94f0-2a6b7d39e393"));

            Assert.That(currJob.IsActive, Is.EqualTo(false));
            Assert.That(currJob.Title, Is.EqualTo("Powerlifting coach"));
        }

        [Test]
        public async Task EditAsync_ShouldEditJobAdvert()
        {
            var jobAdvertModel = new JobAdvertModel()
            {
                Title = "Edited Powerlifting coach",
                Description = "Edited powerlifting coach job advert"
            };

            await jobService.EditAsync(Guid.Parse("f7e314b1-060e-4a4d-94f0-2a6b7d39e393"), jobAdvertModel);

            var editedJobAdvert = await jobService.GetJobAdvertByIdAsync(Guid.Parse("f7e314b1-060e-4a4d-94f0-2a6b7d39e393"));

            Assert.That(editedJobAdvert.Title, Is.EqualTo("Edited Powerlifting coach"));
            Assert.That(editedJobAdvert.Description, Is.EqualTo("Edited powerlifting coach job advert"));
        }

        [Test]
        public async Task JobAdvertExistsByIdAsync_ReturnsTrue()
        {
            var jobAdvertExists = await jobService.JobAdvertExistsByIdAsync(Guid.Parse("5d2f453e-1cc7-47d5-94ae-a58868b76b52"));

            Assert.That(jobAdvertExists, Is.EqualTo(true));
        }

        [TearDown]
        public async Task TearDown()
        {
            await applicationDbContext.Database.EnsureDeletedAsync();
            await applicationDbContext.DisposeAsync();
        }
    }
}
