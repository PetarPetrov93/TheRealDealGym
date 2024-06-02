﻿using Microsoft.AspNetCore.Identity;
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
    }
}
