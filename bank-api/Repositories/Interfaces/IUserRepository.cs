using bank_api.Models;

namespace bank_api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByID(int id);
        Task<IEnumerable<User>> GetAllUsers();
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int id);
    }
}
