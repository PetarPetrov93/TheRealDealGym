using System.ComponentModel.DataAnnotations;

namespace TheRealDealGym.Core.Models.Job
{
    /// <summary>
    /// This ViewModel is displayed in the admin area in the Reviw Applications View.
    /// </summary>
    public class ApplicationForApproveModel
    {
        public Guid Id { get; set; }
        public Guid JobAdvertId { get; set; }
        public Guid UserId { get; set; }
        public string JobAdvertTitle { get; set; } = null!;
        public string UserFullName { get; set; } = null!;
        public int Age { get; set; }
        public int YearsOfExperience { get; set; }
        public string Bio { get; set; } = null!;
    }
}
