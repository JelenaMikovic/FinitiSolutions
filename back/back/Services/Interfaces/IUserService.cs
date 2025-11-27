using back.DTOs;

namespace back.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByEmailAndPassword(string email, string password);
    }
}
