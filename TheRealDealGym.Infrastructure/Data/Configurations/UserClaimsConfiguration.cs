using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Infrastructure.Data.Configurations
{
    public class UserClaimsConfiguration : IEntityTypeConfiguration<IdentityUserClaim<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<Guid>> builder)
        {
            var data = new DataSeed();

            builder.HasData(
                data.AdminUserClaim,
                data.TrainerUserFightingClaim,
                data.TrainerUserWaterClaim,
                data.TrainerUserStretchingClaim,
                data.GuestUserBookedClaim,
                data.GuestUserNotBookedClaim
            );
        }
    }
}
