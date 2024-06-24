using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TheRealDealGym.Infrastructure.Constants.ValidationConstants.ForTrainer;

namespace TheRealDealGym.Infrastructure.Data.Models
{
    public class JobApplication
    {
        public JobApplication()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// JobApplication identifier.
        /// </summary>
        [Key]
        [Comment("JobApplication identifier")]
        public Guid Id { get; set; }


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
        /// Foreign key to JobAdvert.
        /// </summary>
        [Required]
        [ForeignKey(nameof(JobAdvert))]
        [Comment("Foreign key to ApplicationUser")]
        public Guid JobAdvertId { get; set; }

        /// <summary>
        /// Navigation property for the JobAdvert.
        /// </summary>
        [Comment("Navigation property for the JobAdvert")]
        public JobAdvert JobAdvert { get; set; } = null!;

        /// <summary>
        /// Applicant's age.
        /// </summary>
        [Required]
        [Range(MinAge, MaxAge)]
        [Comment("Applicant's age")]
        public int Age { get; set; }

        /// <summary>
        /// Applicant's years of experience.
        /// </summary>
        [Required]
        [Range(MinYearsOfExperience, MaxYearsOfExperience)]
        [Comment("Applicant's years of experience.")]
        public int YearsOfExperience { get; set; }

        /// <summary>
        /// More information about the applicant (Biography).
        /// </summary>
        [Required]
        [StringLength(MaxBio, MinimumLength = MinBio)]
        [Comment("More information about the applicant (Biography)")]
        public string Bio { get; set; } = null!;

        /// <summary>
        /// Serves a soft delete purpose.
        /// </summary>
        [Comment("Serves a soft delete purpose")]
        public bool IsDeleted { get; set; } = false;

    }
}
