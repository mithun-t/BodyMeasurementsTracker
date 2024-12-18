using BodyMeasurementsTracker.Models;
using System.Threading.Tasks;

namespace BodyMeasurementsTracker.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserByMobileNumberAsync(string mobileNumber);
        Task RegisterAsync(User user);
    }
}
