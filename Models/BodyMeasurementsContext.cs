using Microsoft.EntityFrameworkCore;

namespace BodyMeasurementsTracker.Models
{
    public class BodyMeasurementsContext : DbContext
    {
        public BodyMeasurementsContext(DbContextOptions<BodyMeasurementsContext> options) : base(options) { }

        public DbSet<BodyMeasurement> BodyMeasurements { get; set; }
    }
}
