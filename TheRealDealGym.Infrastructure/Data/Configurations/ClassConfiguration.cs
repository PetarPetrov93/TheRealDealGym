using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Infrastructure.Data.Configurations
{
    internal class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasOne(c => c.Trainer)
                   .WithMany(t => t.Classes)
                   .HasForeignKey(c => c.TrainerId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Sport)
                  .WithMany(s => s.Classes)
                  .HasForeignKey(c => c.SportId)
                  .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Room)
                  .WithMany(r => r.Classes)
                  .HasForeignKey(c => c.RoomId)
                  .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(c => !c.IsDeleted);

            var data = new DataSeed();

            builder.HasData(new Class[]
            {
                data.MuayThaiBeginners,
                data.SwimmingForKids,
                data.YogaAdvanced
            });
        }
    }
}
