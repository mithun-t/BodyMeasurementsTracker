using BodyMeasurementsTracker.Models;
using BodyMeasurementsTracker.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BodyMeasurementsTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyMeasurementController : ControllerBase
    {
        private readonly BodyMeasurementService _bodyMeasurementService;

        public BodyMeasurementController(BodyMeasurementService bodyMeasurementService)
        {
            _bodyMeasurementService = bodyMeasurementService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveBodyMeasurement([FromBody] BodyMeasurement measurement)
        {
            if (measurement == null)
            {
                return BadRequest("Body measurement data is required.");
            }

            try
            {
                await _bodyMeasurementService.SaveBodyMeasurementAsync(measurement);
                return Ok("Body measurement saved successfully.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<BodyMeasurement>>> GetBodyMeasurementsByUserId([FromQuery] int userId)
        {
            if (userId <= 0)
            {
                return BadRequest("Invalid user ID.");
            }

            try
            {
                var measurements = await _bodyMeasurementService.GetBodyMeasurementsByUserIdAsync(userId);
                return Ok(measurements);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}