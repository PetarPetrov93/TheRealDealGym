using Microsoft.EntityFrameworkCore;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Models.Job;
using TheRealDealGym.Core.Models.Trainer;
using TheRealDealGym.Infrastructure.Data.Common;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Core.Services
{
    /// <summary>
    /// The service responsible for operations with JobAdvert entity.
    /// </summary>
    public class JobService : IJobService
    {
        private readonly IRepository repository;

        public JobService(IRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// This method returns a collection of all Jobs both active and unactive.
        /// </summary>
        public async Task<IEnumerable<JobAdvertListModel>> AllJobsAsync(Guid userId)
        {
            return await repository.AllReadOnly<JobAdvert>()
                .Include(j => j.JobApplications)
                .Where(j => j.JobApplications.Any(a => a.UserId == userId) == false)
                .Select(j => new JobAdvertListModel()
                {
                    Id = j.Id,
                    Title = j.Title,
                    IsActive = j.IsActive,
                })
                .OrderByDescending(j => j.IsActive)
                .ThenBy(j => j.Title)
                .ToListAsync();
        }

        /// <summary>
        /// This method creates a new job advert.
        /// </summary>
        public async Task<Guid> CreateAsync(JobAdvertModel model)
        {
            JobAdvert jobAdvert = new JobAdvert()
            {
                Title = model.Title,
                Description = model.Description
            };

            await repository.AddAsync(jobAdvert);
            await repository.SaveChangesAsync();

            return jobAdvert.Id;
        }

        /// <summary>
        /// This method activates a job advert.
        /// </summary>
        public async Task ActivateAsync(Guid jobAdvertId)
        {
            var jobAdvert = await repository.GetByIdAsync<JobAdvert>(jobAdvertId);

            if (jobAdvert != null)
            {
                jobAdvert.IsActive = true;
                await repository.SaveChangesAsync();
            }
        }

        /// <summary>
        /// This method deactivates a job advert.
        /// </summary>
        public async Task DeactivateAsync(Guid jobAdvertId)
        {
            var jobAdvert = await repository.GetByIdAsync<JobAdvert>(jobAdvertId);

            if (jobAdvert != null)
            {
                jobAdvert.IsActive = false;
                await repository.SaveChangesAsync();
            }
        }

        /// <summary>
        /// This method edits a selected job advert.
        /// </summary>
        public async Task EditAsync(Guid jobAdvertId, JobAdvertModel model)
        {
            var jobAdvert = await repository.GetByIdAsync<JobAdvert>(jobAdvertId);

            if (jobAdvert != null)
            {
                jobAdvert.Title = model.Title;
                jobAdvert.Description = model.Description;
                await repository.SaveChangesAsync();
            }
        }

        /// <summary>
        /// This method checks if a job advert with a given Id exists.
        /// </summary>
        public async Task<bool> ExistsByIdAsync(Guid jobAdvertId)
        {
            return await repository.AllReadOnly<JobAdvert>()
                 .AnyAsync(j => j.Id == jobAdvertId);
        }

        /// <summary>
        /// This method finds and returns a job advert by a given Id
        /// </summary>
        public async Task<JobAdvertModel> GetByIdAsync(Guid jobAdvertId)
        {
            return await repository.AllReadOnly<JobAdvert>()
                .Where(j => j.Id == jobAdvertId)
                .Select(j => new JobAdvertModel()
                {
                    Id = j.Id,
                    Title = j.Title,
                    Description = j.Description,
                    IsActive = j.IsActive
                })
                .FirstAsync();
        }

        /// <summary>
        /// This method creates a new job application.
        /// </summary>
        public async Task CreateJobApplicationAsync(Guid jobAdvertId, Guid userId, ApplicationFormModel model)
        {
            var JobApplication = new JobApplication()
            {
                JobAdvertId = jobAdvertId,
                UserId = userId,
                Age = model.Age,
                YearsOfExperience = model.YearsOfExperience,
                Bio = model.Bio
            };

            await repository.AddAsync(JobApplication);
            await repository.SaveChangesAsync();
        }

        /// <summary>
        /// This method creates a new Trainer when a user is hired.
        /// </summary>
        public async Task MakeTrainerAsync(Guid userId, ApplicationFormModel trainerInfo)
        {
            await repository.AddAsync(new Trainer()
            {
                Age = trainerInfo.Age,
                YearsOfExperience = trainerInfo.YearsOfExperience,
                Bio = trainerInfo.Bio,
                UserId = userId,
            });

            await repository.SaveChangesAsync();
        }
    }
}
