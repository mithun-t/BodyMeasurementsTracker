using BodyMeasurementsTracker.Models;
using BodyMeasurementsTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace BodyMeasurementsTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (string.IsNullOrEmpty(user.MobileNumber) || string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("Mobile number and password are required.");
            }

            try
            {
                await _userService.RegisterAsync(user);
                return Ok("User registered successfully.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            if (string.IsNullOrEmpty(user.MobileNumber) || string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("Mobile number and password are required.");
            }

            var loggedInUser = await _userService.LoginAsync(user.MobileNumber, user.Password);
            if (loggedInUser == null)
            {
                return Unauthorized("Invalid mobile number or password.");
            }

            return Ok(new
            {
                Message = "Login successful.",
                UserId = loggedInUser.Id
            });
        }
    }
}
