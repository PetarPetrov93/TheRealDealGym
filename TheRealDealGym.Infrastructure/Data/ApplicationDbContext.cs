using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheRealDealGym.Infrastructure.Data.Models;

namespace TheRealDealGym.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Room>(entity =>
            {
                entity.HasQueryFilter(r => !r.IsDeleted);
            });

            builder.Entity<Sport>(entity =>
            {
                entity.HasQueryFilter(s => !s.IsDeleted);
            });

            builder.Entity<Trainer>(entity =>
            {
                entity.HasQueryFilter(t => !t.IsDeleted);
            });

            builder.Entity<TrainerSport>(entity =>
            {
                entity.HasKey(ts => new { ts.TrainerId, ts.SportId });
                entity.HasQueryFilter(ts => !ts.Trainer.IsDeleted && !ts.Sport.IsDeleted);
            });

            builder.Entity<Booking>(entity =>
            {
                entity.HasQueryFilter(b => !b.IsDeleted);
            });

            builder.Entity<Class>(entity =>
            {
                entity.HasQueryFilter(c => !c.IsDeleted);
            });

            base.OnModelCreating(builder);
        }

        /// <summary>
        /// These DbSets represent each table in the database.
        /// </summary>
        public DbSet<Room> Rooms { get; set; } = null!;
        public DbSet<Sport> Sports { get; set; } = null!;
        public DbSet<Trainer> Trainers { get; set; } = null!;
        public DbSet<TrainerSport> TrainerSports { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<Class> Classes { get; set; } = null!;
    }
}
