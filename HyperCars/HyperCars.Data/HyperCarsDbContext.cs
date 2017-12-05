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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}