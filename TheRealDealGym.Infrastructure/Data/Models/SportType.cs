using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static TheRealDealGym.Infrastructure.Constants.ValidationConstants.ForSportType;

namespace TheRealDealGym.Infrastructure.Data.Models
{
    /// <summary>
    /// The SportType holds the title of a given sport and its category (type of sport)
    /// </summary>
    [Comment("The SportType holds the title of a given sport and its category (type of sport)")]
    public class SportType
    {
        public SportType()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// SportType identifier.
        /// </summary>
        [Key]
        [Comment("SportType identifier")]
        public Guid Id { get; set; }

        /// <summary>
        /// The title of the sport. e.g. Kickboxing, Boxing, BJJ, Swimming, Cango jumps etc.
        /// </summary>
        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("The title of the sport")]
        public string Title { get; set; } = null!;

        /// <summary>
        /// The category of the sport. e.g. Fighting, Grappling, Cardio, Watersport etc.
        /// </summary>
        [Required]
        [MaxLength(CategoryMaxLength)]
        [Comment("The category of the sport")]
        public string Category { get; set; } = null!;

        /// <summary>
        /// Serves a soft delete purpose.
        /// </summary>
        [Comment("Serves a soft delete purpose")]
        public bool IsDeleted { get; set; } = false;
    }
}
