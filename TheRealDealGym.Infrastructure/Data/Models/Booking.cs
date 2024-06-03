using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheRealDealGym.Infrastructure.Data.Models
{
    /// <summary>
    /// This is the Booking entity class. Many bookings by different users can be made for one Class. One User can have many bookings for different classes.
    /// </summary>
    [Comment("Many bookings by different users can be made for one Class. One User can have many bookings for different classes")]
    public class Booking
    {
        public Booking()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Booking identifier.
        /// </summary>
        [Key]
        [Comment("Booking identifier")]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key to ApplicationUser.
        /// </summary>
        [Required]
        [ForeignKey(nameof(User))]
        [Comment("Foreign key to ApplicationUser")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Navigation property for the UserId.
        /// </summary>
        [Comment("Navigation property for the UserId")]
        public ApplicationUser User { get; set; } = null!;

        /// <summary>
        /// Foreign key to Class.
        /// </summary>
        [Required]
        [ForeignKey(nameof(Class))]
        [Comment("Foreign key to Class")]
        public Guid ClassId { get; set; }

        /// <summary>
        /// Navigation property for the ClassId.
        /// </summary>
        [Comment("Navigation property for the ClassId")]
        public Class Class { get; set; } = null!;

        /// <summary>
        /// Serves a soft delete purpose.
        /// </summary>
        [Comment("Serves a soft delete purpose")]
        public bool IsDeleted { get; set; } = false;
    }
}
