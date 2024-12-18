// Data/AppDbContext.cs
using BodyMeasurementsTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BodyMeasurementsTracker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<BodyMeasurement> BodyMeasurements { get; set; }
        public DbSet<User> Users { get; set; }

    }

}
