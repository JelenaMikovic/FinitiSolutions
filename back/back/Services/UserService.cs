using back.Repositories.Interfaces;
using back.Services.Interfaces;
using back.DTOs;

namespace back.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;

        }

        public Task<User> GetByEmailAndPassword(string email, string password)
        {
            return _userRepository.GetByEmailAndPassword(email, password);
        }
    }
}
