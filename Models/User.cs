using System.ComponentModel.DataAnnotations;

namespace BodyMeasurementsTracker.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string MobileNumber { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}