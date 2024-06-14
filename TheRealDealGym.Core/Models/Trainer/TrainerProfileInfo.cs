using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TheRealDealGym.Core.Models.Trainer
{
    /// <summary>
    /// Displays the trainer info in his MyProfile page
    /// </summary>
    public class TrainerProfileInfo
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        public int Age { get; set; }

        [Display(Name = "Years of experience")]
        public int YearsOfExperience { get; set; }

        public string Bio { get; set; } = null!;
    }
}
