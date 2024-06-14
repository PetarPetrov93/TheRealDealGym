using System.ComponentModel.DataAnnotations;

namespace TheRealDealGym.Core.Models.Class
{
    /// <summary>
    /// This ViewModel displays the class information in the schedule
    /// </summary>
    public class ClassModel
    {

        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public decimal Price { get; set; }

        public string Trainer { get; set; } = null!;

        public string Sport { get; set; } = null!;

        public string Room { get; set; } = null!;

        [Display(Name = "Availabe spaces")]
        public int AvaliableSpaces { get; set; }

    }
}
