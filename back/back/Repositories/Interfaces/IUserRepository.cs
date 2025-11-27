namespace back.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAndPassword(string email, string password);
        Task<User> GetUserById(int id);
    }
}
