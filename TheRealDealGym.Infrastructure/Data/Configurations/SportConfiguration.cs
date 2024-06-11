using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Infrastructure.Data.Configurations
{
    internal class SportConfiguration : IEntityTypeConfiguration<Sport>
    {
        public void Configure(EntityTypeBuilder<Sport> builder)
        {
            builder.HasQueryFilter(r => !r.IsDeleted);

            var data = new DataSeed();

            builder.HasData(new Sport[]
            {
                data.MuayThai,
                data.Swimming,
                data.Yoga
            });
        }
    }
}
