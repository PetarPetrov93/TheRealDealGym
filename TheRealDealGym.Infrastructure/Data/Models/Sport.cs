using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static TheRealDealGym.Infrastructure.Constants.ValidationConstants.ForSport;

namespace TheRealDealGym.Infrastructure.Data.Models
{
    /// <summary>
    /// The SportCategory holds the title of a given sport.
    /// </summary>
    [Comment("The Sport holds the title of a given sport and its category (type of sport)")]
    public class Sport
    {
        public Sport()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Sport identifier.
        /// </summary>
        [Key]
        [Comment("Sport identifier")]
        public Guid Id { get; set; }

        /// <summary>
        /// The title of the sport. e.g. Kickboxing, Boxing, BJJ, Swimming, Cango jumps etc.
        /// </summary>
        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("The title of the sport")]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Serves a soft delete purpose.
        /// </summary>
        [Comment("Serves a soft delete purpose")]
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// One Sport can have many Classes.
        /// </summary>
        [Comment("One Sport can have many Classes")]
        public ICollection<Class> Classes { get; set; } = new HashSet<Class>();
    }
}
