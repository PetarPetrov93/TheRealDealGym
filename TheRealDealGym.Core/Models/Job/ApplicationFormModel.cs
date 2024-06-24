using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static TheRealDealGym.Infrastructure.Constants.ValidationConstants.ForTrainer;

namespace TheRealDealGym.Core.Models.Job
{
    /// <summary>
    /// This ViewModel is used when a non-trainer user applies for a job.
    /// </summary>
    public class ApplicationFormModel
    {
        
        [Required]
        [Range(MinAge, MaxAge)]
        public int Age { get; set; }

        [Required]
        [Range(MinYearsOfExperience, MaxYearsOfExperience)]
        public int YearsOfExperience { get; set; }

        [Required]
        [StringLength(MaxBio, MinimumLength = MinBio)]
        public string Bio { get; set; } = null!;
    }
}
