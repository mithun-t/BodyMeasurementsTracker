// Repositories/IBodyMeasurementsRepository.cs
using BodyMeasurementsTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BodyMeasurementsTracker.Repositories
{
    public interface IBodyMeasurementsRepository
    {
        Task<IEnumerable<BodyMeasurement>> GetAllAsync();
        Task<BodyMeasurement> GetByIdAsync(int id);
        Task AddAsync(BodyMeasurement bodyMeasurement);
        Task UpdateAsync(BodyMeasurement bodyMeasurement);
        Task DeleteAsync(int id);
    }
}
