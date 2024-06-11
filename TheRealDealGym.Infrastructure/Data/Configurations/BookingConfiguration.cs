using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Infrastructure.Data.Configurations
{
    internal class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder
                .HasOne(b => b.Class)
                      .WithMany(c => c.Bookings)
                      .HasForeignKey(b => b.ClassId)
                      .OnDelete(DeleteBehavior.NoAction);

            builder.HasQueryFilter(b => !b.IsDeleted);

            var data = new DataSeed();

            builder.HasData(new Booking[]
            {
                data.BookingMuayThai
            });
        }
    }
}
