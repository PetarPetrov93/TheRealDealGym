using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TheRealDealGym.Core.Models.Trainer
{
    /// <summary>
    /// Displays the trainer info in his MyProfile page
    /// </summary>
    public class TrainerDetailsModel
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }

        [Display(Name = "Years of experience")]
        public int YearsOfExperience { get; set; }

        public string Bio { get; set; } = null!;

        public Guid UserId { get; set; }
    }
}
