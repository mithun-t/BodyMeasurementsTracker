using BodyMeasurementsTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BodyMeasurementsTracker.Repositories
{
    public interface IBodyMeasurementRepository
    {
        Task AddBodyMeasurementAsync(BodyMeasurement measurement);
        Task<List<BodyMeasurement>> GetBodyMeasurementsByUserIdAsync(int userId);
        Task UpdateBodyMeasurementAsync(int id, BodyMeasurement updatedMeasurement);
        Task DeleteBodyMeasurementAsync(int id);
    }
}