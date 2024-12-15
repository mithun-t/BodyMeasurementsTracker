// Controllers/BodyMeasurementsController.cs
using BodyMeasurementsTracker.Models;
using BodyMeasurementsTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace BodyMeasurementsTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyMeasurementsController : ControllerBase
    {
        private readonly BodyMeasurementsService _service;

        public BodyMeasurementsController(BodyMeasurementsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var measurements = await _service.GetAllAsync();
            return Ok(measurements);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var measurement = await _service.GetByIdAsync(id);
            if (measurement == null)
                return NotFound();

            return Ok(measurement);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BodyMeasurement bodyMeasurement)
        {
            if (bodyMeasurement == null)
                return BadRequest();

            await _service.AddAsync(bodyMeasurement);
            return CreatedAtAction(nameof(Get), new { id = bodyMeasurement.Id }, bodyMeasurement);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BodyMeasurement bodyMeasurement)
        {
            if (bodyMeasurement == null || bodyMeasurement.Id != id)
                return BadRequest();

            await _service.UpdateAsync(bodyMeasurement);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
