using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static TheRealDealGym.Infrastructure.Constants.ValidationConstants.ForApplicationUser;

namespace TheRealDealGym.Infrastructure.Data.Models
{
    /// <summary>
    /// This is an extension to the User. Adds FirstName and LastName properties to the User and changes the Id from string to GUID.
    /// </summary>
    [Comment("This is an extension to the User. Adds FirstName and LastName properties to the User and changes the Id from string to GUID")]
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
                this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// FirstName property - extension to the default User.
        /// </summary>
        [Required]
        [StringLength(FirstNameMaxLength)]
        [Comment("FirstName property - extension to the default User")]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// LastName property - extension to the default User.
        /// </summary>
        [Required]
        [StringLength(LastNameMaxLength)]
        [Comment("LastName property - extension to the default User")]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Navigation property. It helps you check if the signed-in user is a trainer.
        /// </summary>
        [Comment("Navigation property. It helps you check if the signed-in user is a trainer")]
        public Trainer? Trainer { get; set; }

        /// <summary>
        /// One ApplicationUser can have many bookings. He should be a customer, not a trainer (Trainer = null).
        /// </summary>
        [Comment("One ApplicationUser can have many bookings")]
        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

        /// <summary>
        /// One Applicant can apply for many Jobs.
        /// </summary>
        [Comment("One Applicant can apply for many Jobs")]
        public ICollection<JobApplication> AppliedJobs { get; set; } = new HashSet<JobApplication>();
    }
}
