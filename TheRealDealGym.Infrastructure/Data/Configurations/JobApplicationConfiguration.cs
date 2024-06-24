using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Infrastructure.Data.Configurations
{
    public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            builder.HasQueryFilter(b => !b.IsDeleted);
        }
    }
}
