using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static TheRealDealGym.Infrastructure.Constants.ValidationConstants.ForJobAdvert;

namespace TheRealDealGym.Core.Models.Job
{
    /// <summary>
    /// This ViewModel is used to display the full information about the job advert.
    /// It is also used when creating a new job advert.
    /// </summary>
    public class JobAdvertModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = DescriptionMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        public bool IsActive { get; set; } = true;
    }
}
