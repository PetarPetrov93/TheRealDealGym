using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TheRealDealGym.Infrastructure.Constants.ValidationConstants.ForClass;

namespace TheRealDealGym.Infrastructure.Data.Models
{
    /// <summary>
    /// The Class entity stores information about a specific class.
    /// </summary>
    [Comment("The Class entity stores information about a specific class")]
    public class Class
    {
        public Class()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Class identifier.
        /// </summary>
        [Key]
        [Comment("Class identifier")]
        public Guid Id { get; set; }

        /// <summary>
        /// The title of the class.
        /// </summary>
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        [Comment("The title of the class")]
        public string Title { get; set; } = null!;

        /// <summary>
        /// Description and additional info about the class.
        /// </summary>
        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Comment("Description and additional info about the class")]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Starting date and time of the class.
        /// </summary>
        [Required]
        [Comment("Starting date and time of the class")]
        public DateTime DateAndTime { get; set; }

        /// <summary>
        /// The price of the class.
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Comment("The price of the class")]
        public decimal Price { get; set; }

        /// <summary>
        /// Foreign key to Trainer.
        /// </summary>
        [Required]
        [ForeignKey(nameof(Trainer))]
        [Comment("Foreign key to Trainer")]
        public Guid TrainerId { get; set; }

        /// <summary>
        /// Navigation property for the Trainer.
        /// </summary>
        [Comment("Navigation property for the TrainerId")]
        public Trainer Trainer { get; set; } = null!;

        /// <summary>
        /// Foreign key to Sport.
        /// </summary>
        [Required]
        [ForeignKey(nameof(Sport))]
        [Comment("Foreign key to Sport")]
        public Guid SportId { get; set; }

        /// <summary>
        /// Navigation property for the Trainer.
        /// </summary>
        [Comment("Navigation property for the SportId")]
        public Sport Sport { get; set; } = null!;

        /// <summary>
        /// Foreign key to Room.
        /// </summary>
        [Required]
        [ForeignKey(nameof(Room))]
        [Comment("Foreign key to Room")]
        public Guid RoomId { get; set; }

        /// <summary>
        /// Navigation property for the Trainer.
        /// </summary>
        [Comment("Navigation property for the RoomId")]
        public Room Room { get; set; } = null!;

        /// <summary>
        /// Serves a soft delete purpose.
        /// </summary>
        [Comment("Serves a soft delete purpose")]
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// One Class can have many Bookings.
        /// </summary>
        [Comment("One Class can have many Bookings")]
        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
    }
}
