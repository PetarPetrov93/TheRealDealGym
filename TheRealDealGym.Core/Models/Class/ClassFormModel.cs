using System.ComponentModel.DataAnnotations;
using static TheRealDealGym.Infrastructure.Constants.ValidationConstants.ForClass;

namespace TheRealDealGym.Core.Models.Class
{
    /// <summary>
    /// This ViewModel is used when creating or editing a class.
    /// </summary>
    public class ClassFormModel
    {
        
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        
        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;


        [Required]
        public string Date { get; set; } = null!;

        [Required]
        public string Time { get; set; } = null!;


        [Required]
        [Range(typeof(decimal), MinPrice, MaxPrice)]
        public decimal Price { get; set; }
        
        [Required]
        [Display(Name = "Sport")]
        public Guid SportId { get; set; }

        public IEnumerable<string> Sports { get; set; } = new HashSet<string>();

        [Required]
        [Display(Name = "Room")]
        public Guid RoomId { get; set; }

        public IEnumerable<string> Rooms { get; set; } = new HashSet<string>();


    }
}
