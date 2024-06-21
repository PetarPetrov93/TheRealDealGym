using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Infrastructure.Data.Configurations
{
    internal class JobAdvertConfiguration : IEntityTypeConfiguration<JobAdvert>
    {
        public void Configure(EntityTypeBuilder<JobAdvert> builder)
        {
            var data = new DataSeed();

            builder.HasData(data.JobAdvert);
        }
    }
}
