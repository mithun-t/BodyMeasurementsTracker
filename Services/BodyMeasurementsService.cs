using BodyMeasurementsTracker.Models;
using BodyMeasurementsTracker.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BodyMeasurementsTracker.Services
{
    public class BodyMeasurementService
    {
        private readonly IBodyMeasurementRepository _repository;

        public BodyMeasurementService(IBodyMeasurementRepository repository)
        {
            _repository = repository;
        }

        public async Task SaveBodyMeasurementAsync(BodyMeasurement measurement)
        {
            await _repository.AddBodyMeasurementAsync(measurement);
        }

        public async Task<List<BodyMeasurement>> GetBodyMeasurementsByUserIdAsync(int userId)
        {
            return await _repository.GetBodyMeasurementsByUserIdAsync(userId);
        }

        public async Task UpdateBodyMeasurementAsync(int id, BodyMeasurement updatedMeasurement)
        {
            await _repository.UpdateBodyMeasurementAsync(id, updatedMeasurement);
        }

        public async Task DeleteBodyMeasurementAsync(int id)
        {
            await _repository.DeleteBodyMeasurementAsync(id);
        }
    }
}
