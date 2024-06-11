using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Infrastructure.Data.Configurations
{
    internal class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasQueryFilter(r => !r.IsDeleted);

            var data = new DataSeed();

            builder.HasData(new Room[]
            {
                data.FightingRoom,
                data.Pool,
                data.OpenSpaceRoom
            });
        }
    }
}
