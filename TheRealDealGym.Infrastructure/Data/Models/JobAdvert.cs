using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static TheRealDealGym.Infrastructure.Constants.ValidationConstants.ForJobAdvert;

namespace TheRealDealGym.Infrastructure.Data.Models
{
    /// <summary>
    /// This is the JobAdvert entity class. It is responsible for the opened job positions.
    /// </summary>
    public class JobAdvert
    {
        public JobAdvert()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// JobAdvert identifier.
        /// </summary>
        [Key]
        [Comment("JobAdvert identifier")]
        public Guid Id { get; set; }

        /// <summary>
        /// This is the title of the job advert.
        /// </summary>
        [Required]
        [StringLength(TitleMaxLength)]
        [Comment("This is the title of the job advert")]
        public string Title { get; set; } = null!;

        /// <summary>
        /// This is the description of the job advert.
        /// </summary>
        [Required]
        [StringLength(DescriptionMaxLength)]
        [Comment("This is the description of the job advert")]
        public string Description { get; set; } = null!;

        /// <summary>
        /// This property shows if the advert is active or not.
        /// </summary>
        [Comment("This property shows if the advert is active or not")]
        public bool IsActive { get; set; } = true;
    }
}
