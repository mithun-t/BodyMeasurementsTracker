// Repositories/BodyMeasurementsRepository.cs
using BodyMeasurementsTracker.Data;
using BodyMeasurementsTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace BodyMeasurementsTracker.Repositories
{
    public class BodyMeasurementsRepository : IBodyMeasurementsRepository
    {
        private readonly AppDbContext _context;

        public BodyMeasurementsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BodyMeasurement>> GetAllAsync()
        {
            return await _context.BodyMeasurements.ToListAsync();
        }

        public async Task<BodyMeasurement> GetByIdAsync(int id)
        {
            return await _context.BodyMeasurements.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddAsync(BodyMeasurement bodyMeasurement)
        {
            await _context.BodyMeasurements.AddAsync(bodyMeasurement);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BodyMeasurement bodyMeasurement)
        {
            _context.BodyMeasurements.Update(bodyMeasurement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var bodyMeasurement = await GetByIdAsync(id);
            if (bodyMeasurement != null)
            {
                _context.BodyMeasurements.Remove(bodyMeasurement);
                await _context.SaveChangesAsync();
            }
        }
    }
}
