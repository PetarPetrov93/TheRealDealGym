using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations;
using static TheRealDealGym.Infrastructure.Constants.ValidationConstants.ForTrainer;

namespace TheRealDealGym.Core.Models.Trainer
{
    /// <summary>
    /// This is the form  that a registered user needs to fill in order to apply for a trainer position.
    /// If a user is not registered he is redirected to the register page and a message appears stating that he has to be registered on the platform in order to apply.
    /// </summary>
    public class JobApplication
    {
        [Required]
        [Range(MinAge, MaxAge)]
        [Comment("Trainer's age")]
        public int Age { get; set; }

        /// <summary>
        /// Trainer's years of experience.
        /// </summary>
        [Required]
        [Range(MinYearsOfExperience, MaxYearsOfExperience)]
        [Comment("Trainer's years of experience.")]
        public int YearsOfExperience { get; set; }

        /// <summary>
        /// More information about the trainer (Biography).
        /// </summary>
        [Required]
        [StringLength(MaxBio, MinimumLength = MinBio)]
        [Comment("More information about the trainer (Biography)")]
        public string Bio { get; set; } = null!;
    }
}
