using Microsoft.EntityFrameworkCore;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Models.Trainer;
using TheRealDealGym.Infrastructure.Data.Common;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Core.Services
{
    /// <summary>
    /// The service responsible for operations with Trainer entity.
    /// </summary>
    public class TrainerService : ITrainerService
    {
        private readonly IRepository repository;

        public TrainerService(IRepository _repository)
        {
            repository = _repository;
        }

        /// <summary>
        /// This methods gets the infromation about a trainer's classes.
        /// </summary>
        public async Task<IEnumerable<TrainerClassModel>> AllTrainerClassesAsync(Guid? trainerId)
        {
            return await repository.AllReadOnly<Class>()
                .Where(c => c.TrainerId == trainerId)
                .Select(c => new TrainerClassModel()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Date = c.DateAndTime.ToString("dd/MM/yyyy"),
                    Time = c.DateAndTime.ToString("HH:mm")
                })
                .ToListAsync();
        }

        /// <summary>
        /// This method returns a collection of the full names of all trainers.
        /// </summary>
        public async Task<IEnumerable<TrainerNameModel>> AllTrainersAsync()
        {
            return await repository.AllReadOnly<Trainer>()
                .Select(t => new TrainerNameModel()
                {
                    Id = t.Id,
                    FullName = $"{t.User.FirstName} {t.User.LastName}"
                })
                .ToListAsync();
        }

        /// <summary>
        /// This method creates a new Trainer.
        /// </summary>
        public async Task CreateAsync(Guid userId, JobApplicationModel trainerInfo)
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

        /// <summary>
        /// This method checks if a trainer exists by a given UserId.
        /// </summary>
        public async Task<bool> ExistsByUserIdAsync(Guid userId)
        {
            return await repository.AllReadOnly<Trainer>()
                .AnyAsync(t => t.UserId == userId);
        }

        /// <summary>
        /// This method checks if a trainer exists by a given TrainerId.
        /// </summary>
        public async Task<bool> ExistsByTrainerIdAsync(Guid trainerId)
        {
            return await repository.AllReadOnly<Trainer>()
                .AnyAsync(t => t.Id == trainerId);
        }

        /// <summary>
        /// This method finds the trainer by Id.
        /// </summary>
        public async Task<Guid?> GetTrainerIdAsync(Guid userId)
        {
            return (await repository.AllReadOnly<Trainer>()
                .FirstOrDefaultAsync(t => t.UserId == userId))?.Id;
        }

        /// <summary>
        /// This method gets the information about the logged-in trainer.
        /// </summary>
        public async Task<TrainerDetailsModel> GetTrainerDetailsAsync(Guid trainerId)
        {
            var trainer = await repository.GetByIdAsync<Trainer>(trainerId);
            return new TrainerDetailsModel()
            {
                FullName = string.Empty,
                Age = trainer!.Age,
                YearsOfExperience = trainer.YearsOfExperience,
                Bio = trainer.Bio,
                UserId = trainer.UserId,
            };
        }
    }
}
