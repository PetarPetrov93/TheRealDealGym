using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static TheRealDealGym.Infrastructure.Constants.ValidationConstants.ForRoom;
namespace TheRealDealGym.Infrastructure.Data.Models
{
    /// <summary>
    /// The room is the place where a specific type of classes will be taking place.
    /// </summary>
    [Comment("The room is the place where a specific type of classes will be taking place.")]
    public class Room
    {
        public Room()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Room identifier.
        /// </summary>
        [Key]
        [Comment("Room identifier")]
        public Guid Id { get; set; }

        /// <summary>
        /// The name of the room. Helps the customers find where the class they've booked for will take place.
        /// Also helps with search filtering.
        /// </summary>
        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("The name of the room")]
        public string Type { get; set; } = null!;

        /// <summary>
        /// The maximum capacity of the room. This shows how many people can book for a specific class.
        /// Helps keeping track of the bookings and available spaces.
        /// </summary>
        [Required]
        [Range(MinCapacity, MaxCapacity)]
        [Comment("The maximum capacity of the room")]
        public int Capacity { get; set; }

        /// <summary>
        /// Serves a soft delete purpose.
        /// </summary>
        [Comment("Serves a soft delete purpose")]
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// One Room can have many Classes.
        /// </summary>
        [Comment("One Room can have many Classes")]
        public ICollection<Class> Classes { get; set; } = new HashSet<Class>();
    }
}
