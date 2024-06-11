using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Infrastructure.Data.Configurations
{
    internal class TrainerSportConfiguration : IEntityTypeConfiguration<TrainerSport>
    {
        public void Configure(EntityTypeBuilder<TrainerSport> builder)
        {
            builder
                .HasKey(ts => new { ts.TrainerId, ts.SportId });

            builder
                .HasQueryFilter(ts => !ts.Trainer.IsDeleted && !ts.Sport.IsDeleted);

            var data = new DataSeed();

            builder.HasData(new TrainerSport[]
            {
                data.TrainerFighting,
                data.TrainerWater,
                data.TrainerStretching
            });
        }
    }
}
