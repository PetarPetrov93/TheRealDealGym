using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var data = new DataSeed();

            builder.HasData(new ApplicationUser[]
            {
                data.TrainerUserFighting,
                data.TrainerUserWater,
                data.TrainerUserStretching,
                data.GuestUserBooked,
                data.GuestUserNotBooked
            });
        }
    }
}
