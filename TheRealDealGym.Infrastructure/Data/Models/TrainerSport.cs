using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheRealDealGym.Infrastructure.Data.Models
{
    /// <summary>
    /// Mapping class to define the many-to-many relations between Trainer and Sport
    /// </summary>
    [Comment("Mapping the Trainer and Sport entities")]
    public class TrainerSport
    {
        /// <summary>
        /// Trainer identifier.
        /// </summary>
        [ForeignKey(nameof(Trainer))]
        [Comment("Trainer identifier")]
        public Guid TrainerId { get; set; }

        /// <summary>
        /// Navigation property for TrainerId.
        /// </summary>
        [Comment("Navigation property for TrainerId")]
        public Trainer Trainer { get; set; } = null!;

        /// <summary>
        /// Sport identifier.
        /// </summary>
        [ForeignKey(nameof(Sport))]
        [Comment("Sport identifier")]
        public Guid SportId { get; set; }

        /// <summary>
        /// Navigation property for SportId.
        /// </summary>
        [Comment("Navigation property for SportId")]
        public Sport Sport { get; set; } = null!;
    }
}
