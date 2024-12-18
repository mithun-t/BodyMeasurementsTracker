using BodyMeasurementsTracker.Models;
using BodyMeasurementsTracker.Repositories;
using System.Threading.Tasks;

namespace BodyMeasurementsTracker.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User?> LoginAsync(string mobileNumber, string password)
        {
            var user = await _repository.GetUserByMobileNumberAsync(mobileNumber);
            if (user != null && user.Password == password)
            {
                return user;
            }
            return null;
        }

        public async Task RegisterAsync(User user)
        {
            var existingUser = await _repository.GetUserByMobileNumberAsync(user.MobileNumber);
            if (existingUser != null)
            {
                throw new InvalidOperationException("User already exists.");
            }

            await _repository.RegisterAsync(user);
        }
    }
}
