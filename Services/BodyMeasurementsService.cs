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
    }
}