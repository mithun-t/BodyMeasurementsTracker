// Services/BodyMeasurementsService.cs
using BodyMeasurementsTracker.Models;
using BodyMeasurementsTracker.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BodyMeasurementsTracker.Services
{
    public class BodyMeasurementsService
    {
        private readonly IBodyMeasurementsRepository _repository;

        public BodyMeasurementsService(IBodyMeasurementsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BodyMeasurement>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<BodyMeasurement> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(BodyMeasurement bodyMeasurement)
        {
            await _repository.AddAsync(bodyMeasurement);
        }

        public async Task UpdateAsync(BodyMeasurement bodyMeasurement)
        {
            await _repository.UpdateAsync(bodyMeasurement);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
