using System.ComponentModel.DataAnnotations;

namespace TheRealDealGym.Core.Models.Job
{
    /// <summary>
    /// This ViewModel is displayed in the admin area in the Reviw Applications View.
    /// </summary>
    public class ApplicationForApproveModel
    {
        public Guid JobAdvertId { get; set; }
        public Guid UserId { get; set; }

        [Display(Name ="Candidate Full Name")]
        public string UserFullName { get; set; } = null!;
        public int Age { get; set; }

        [Display(Name ="Years of Experience")]
        public int YearsOfExperience { get; set; }

        public string Bio { get; set; } = null!;
    }
}
