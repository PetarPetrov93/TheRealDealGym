using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Infrastructure.Data.Configurations
{
    internal class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.HasQueryFilter(r => !r.IsDeleted);

            var data = new DataSeed();

            builder.HasData(new Trainer[]
            {
                data.FightingTrainer,
                data.WaterTrainer,
                data.StretchingTrainer
            });
        }
    }
}
