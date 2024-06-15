using System.ComponentModel.DataAnnotations;

namespace TheRealDealGym.Core.Models.Class
{
    public class ClassScheduleModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Date { get; set; } = null!;

        public string Time { get; set; } = null!;

        public decimal Price { get; set; }

        public string Trainer { get; set; } = null!;
    }
}
