﻿using Microsoft.EntityFrameworkCore;
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
        /// This method creates a new Trainer.
        /// </summary>
        public async Task CreateAsync(Guid userId, JobApplication trainerInfo)
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
        /// This method checks if a trainer exists by a given Id.
        /// </summary>
        public async Task<bool> ExistsByIdAsync(Guid userId)
        {
            return await repository.AllReadOnly<Trainer>()
                .AnyAsync(t => t.UserId == userId);
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
        public async Task<TrainerProfileInfo> GetTrainerProfileInfoAsync(Guid trainerId)
        {
            var trainer = await repository.GetByIdAsync<Trainer>(trainerId);
            return new TrainerProfileInfo()
            {
                FirstName = trainer!.User.FirstName,
                LastName = trainer!.User.LastName,
                Age = trainer.Age,
                YearsOfExperience = trainer.YearsOfExperience,
                Bio = trainer.Bio
            };
        }
    }
}
