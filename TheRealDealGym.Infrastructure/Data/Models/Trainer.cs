using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TheRealDealGym.Infrastructure.Constants.ValidationConstants.ForTrainer;

namespace TheRealDealGym.Infrastructure.Data.Models
{
    /// <summary>
    /// Trainer can organize classes and teach all the Sports which he is qualified to teach.
    /// </summary>
    [Comment("Trainer can organize classes and teach all the Sports which he is qualified to teach")]
    public class Trainer
    {
        public Trainer()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Trainer identifier.
        /// </summary>
        [Key]
        [Comment("Trainer identifier")]
        public Guid Id { get; set; }

        /// <summary>
        /// Trainer's age.
        /// </summary>
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


        /// <summary>
        /// Foreign key to ApplicationUser.
        /// </summary>
        [Required]
        [ForeignKey(nameof(User))]
        [Comment("Foreign key to ApplicationUser")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Navigation property for the UserId.
        /// </summary>
        [Comment("Navigation property for the UserId")]
        public ApplicationUser User { get; set; } = null!;

        /// <summary>
        /// Serves a soft delete purpose.
        /// </summary>
        [Comment("Serves a soft delete purpose")]
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// A collection of all the Sports the trainer is qualified to teach.
        /// </summary>
        [Comment("A collection of all the Sports the trainer is qualified to teach")]
        public ICollection<TrainerSport> TrainersSports { get; set; } = new HashSet<TrainerSport>();

        /// <summary>
        /// One Trainer can have many Classes.
        /// </summary>
        [Comment("One Trainer can have many Classes")]
        public ICollection<Class> Classes { get; set; } = new HashSet<Class>();
    }
}
