using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static TheRealDealGym.Infrastructure.Constants.ValidationConstants.ForSport;

namespace TheRealDealGym.Core.Models.Sport
{
    /// <summary>
    /// This ViewModel is for Sport entity information.
    /// </summary>
    public class SportInfoModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;
    }
}
