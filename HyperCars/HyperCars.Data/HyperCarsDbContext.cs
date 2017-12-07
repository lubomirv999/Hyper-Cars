namespace HyperCars.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class HyperCarsDbContext : IdentityDbContext<User>
    {
        public HyperCarsDbContext(DbContextOptions<HyperCarsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Part> Parts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Car>()
                .HasOne(c => c.User)
                .WithMany(u => u.Cars)
                .HasForeignKey(c => c.UserId);

            builder
                .Entity<Part>()
                .HasOne(p => p.User)
                .WithMany(u => u.Parts)
                .HasForeignKey(c => c.UserId);

            base.OnModelCreating(builder);
        }
    }
}