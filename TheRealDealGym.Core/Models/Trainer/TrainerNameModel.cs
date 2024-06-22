using System.ComponentModel.DataAnnotations;

namespace TheRealDealGym.Core.Models.Trainer
{
    /// <summary>
    /// This ViewModel gets the trainer's full name.
    /// </summary>
    public class TrainerNameModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Trainer's name")]
        public string FullName { get; set; } = null!;
    }
}
