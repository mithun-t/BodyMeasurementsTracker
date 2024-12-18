using BodyMeasurementsTracker.Data;
using BodyMeasurementsTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BodyMeasurementsTracker.Repositories
{
    public class BodyMeasurementRepository : IBodyMeasurementRepository
    {
        private readonly AppDbContext _context;

        public BodyMeasurementRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddBodyMeasurementAsync(BodyMeasurement measurement)
        {
            // Validate that the user exists
            var userExists = await _context.Users.AnyAsync(u => u.Id == measurement.UserId);
            if (!userExists)
            {
                throw new InvalidOperationException("User does not exist.");
            }

            measurement.Date = DateTime.UtcNow; // Set current date
            await _context.BodyMeasurements.AddAsync(measurement);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BodyMeasurement>> GetBodyMeasurementsByUserIdAsync(int userId)
        {
            // Validate that the user exists
            var userExists = await _context.Users.AnyAsync(u => u.Id == userId);
            if (!userExists)
            {
                throw new InvalidOperationException("User does not exist.");
            }

            return await _context.BodyMeasurements
                .Where(bm => bm.UserId == userId)
                .OrderByDescending(bm => bm.Date)
                .ToListAsync();
        }
    }
}