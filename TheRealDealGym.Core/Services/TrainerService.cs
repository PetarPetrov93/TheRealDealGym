using Microsoft.EntityFrameworkCore;
using TheRealDealGym.Core.Contracts;
using TheRealDealGym.Core.Enums;
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
            await ExpireClasses(trainerId);
            return await repository.AllReadOnly<Class>()
                .OrderBy(c => c.DateAndTime)
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
        /// It also sorts by name asc/desc.
        /// </summary>
        public async Task<TrainerQueryModel> AllTrainersAsync(StaffSorting sorting = StaffSorting.NameAscending,
            int currentPage = 1,
            int trainersPerPage = 10)
        {
            var trainersToShow = repository.AllReadOnly<Trainer>();


            trainersToShow = sorting switch
            {
                StaffSorting.NameAscending => trainersToShow.OrderBy(t => t.User.FirstName).ThenBy(t => t.User.LastName),
                StaffSorting.NameDescending => trainersToShow.OrderByDescending(t => t.User.FirstName).ThenByDescending(t => t.User.LastName),
                _ => trainersToShow.OrderBy(t => t.User.FirstName).ThenBy(t => t.User.LastName)
            };

            var trainers = await trainersToShow
                .Skip((currentPage - 1) * trainersPerPage)
                .Take(trainersPerPage)
                .Select(t => new TrainerNameModel()
                {
                    Id = t.Id,
                    FullName = $"{t.User.FirstName} {t.User.LastName}"
                })
                .ToListAsync();

            int totalTrainers = await trainersToShow.CountAsync();

            return new TrainerQueryModel()
            {
                Trainers = trainers,
                TrainersCount = totalTrainers
            };
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

        /// <summary>
        /// This method edits the trainers information.
        /// </summary>
        public async Task EditAsync(Guid trainerId, TrainerDetailsModel model)
        {
            var trainer = await repository.GetByIdAsync<Trainer>(trainerId);

            if (trainer != null)
            {
                trainer.Age = model.Age;
                trainer.YearsOfExperience = model.YearsOfExperience;
                trainer.Bio = model.Bio;
                await repository.SaveChangesAsync();
            }
        }

        /// <summary>
        /// This method returns the userId by trainerId.
        /// </summary>
        public async Task<Guid> GetUserIdByTrainerIdAsync(Guid trainerId)
        {
            return await repository.AllReadOnly<Trainer>()
                .Where(t => t.Id == trainerId)
                .Select(t => t.UserId)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// This method expires classes which due date and time has passed.
        /// </summary>
        private async Task ExpireClasses(Guid? trainerId)
        {
            var allClasses = await repository.AllReadOnly<Class>()
                .Where(c => c.TrainerId == trainerId)
                .ToListAsync();
            allClasses = allClasses
                .Where(c => c.DateAndTime < DateTimeOffset.Now).ToList();

            foreach (var currClass in allClasses)
            {
                await repository.DeleteAsync<Class>(currClass.Id);
                await repository.SaveChangesAsync();
            }
        }
    }
}
