using System.ComponentModel.DataAnnotations;
using static TheRealDealGym.Infrastructure.Constants.ValidationConstants.ForRoom;
namespace TheRealDealGym.Core.Models.Room
{
    /// <summary>
    /// This ViewModel is for Rooms entity intformation.
    /// </summary>
    public class RoomServiceModel
    {
        
        public Guid Id { get; set; }

        [Required]
        [StringLength(TypeMaxLength, MinimumLength = TypeMinLength)]
        public string Type { get; set; } = null!;

        [Required]
        [Range(MinCapacity, MaxCapacity)]
        public int Capacity { get; set; }

    }
}
