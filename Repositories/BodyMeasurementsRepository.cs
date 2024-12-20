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

        public async Task UpdateBodyMeasurementAsync(int id, BodyMeasurement updatedMeasurement)
        {
            var existingMeasurement = await _context.BodyMeasurements.FindAsync(id);
            if (existingMeasurement == null)
            {
                throw new KeyNotFoundException("Body measurement not found.");
            }

            // Update fields
            existingMeasurement.Weight = updatedMeasurement.Weight;
            existingMeasurement.BodyFat = updatedMeasurement.BodyFat;
            existingMeasurement.Neck = updatedMeasurement.Neck;
            existingMeasurement.Waist = updatedMeasurement.Waist;
            existingMeasurement.Chest = updatedMeasurement.Chest;
            existingMeasurement.Date = updatedMeasurement.Date;

            _context.BodyMeasurements.Update(existingMeasurement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBodyMeasurementAsync(int id)
        {
            var measurement = await _context.BodyMeasurements.FindAsync(id);
            if (measurement == null)
            {
                throw new KeyNotFoundException("Body measurement not found.");
            }

            _context.BodyMeasurements.Remove(measurement);
            await _context.SaveChangesAsync();
        }
    }
}
