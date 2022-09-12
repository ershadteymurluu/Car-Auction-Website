using MachineBazaar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MachineBazaar.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Transmission> transmissions { get; set; }
        public DbSet<BodyStyle> bodyStyles { get; set; }
        public DbSet<Year> years { get; set; }
        public DbSet<Car> cars { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<FuelType> fuelTypes { get; set; }
        public DbSet<MotorSize> motorSizes { get; set; }
        public DbSet<Comments> comments { get; set; }
        public DbSet<Bids> bids { get; set; }
    }
}
