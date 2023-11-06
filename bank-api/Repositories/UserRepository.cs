using bank_api.Context;
using bank_api.Models;
using bank_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bank_api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BankDBContext _bankDBContext;

        public UserRepository(BankDBContext bankDBContext)
        {
            _bankDBContext = bankDBContext;
        }

        public async Task<User?> GetUserByID(int id)
        {
            var user = await _bankDBContext.Users.FindAsync(id);
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _bankDBContext.Users.ToListAsync();
            return users;
        }

        public async Task AddUser(User user)
        {
            await _bankDBContext.Users.AddAsync(user);
            await _bankDBContext.SaveChangesAsync();
        }

        public async Task UpdateUser(User user)
        {
            var foundUser = await _bankDBContext.Users.FindAsync(user.Id);
            if (foundUser != null)
            {
                foundUser.Name = user.Name;
                foundUser.BirthDate = user.BirthDate;
                foundUser.Cpf = user.Cpf;
                _bankDBContext.Users.Update(foundUser);
                await _bankDBContext.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(int id)
        {
            var user = await _bankDBContext.Users.FindAsync(id);
            if (user != null)
            {
                _bankDBContext.Users.Remove(user);
                await _bankDBContext.SaveChangesAsync();
            }
        }
    }
}
