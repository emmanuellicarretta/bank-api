using bank_api.Models;

namespace bank_api.Repositories.Interfaces
{
    public interface IWalletRepository
    {
        Task<Wallet?> GetWalletByID(int id);
        Task<IEnumerable<Wallet>> GetAllWallets();
        Task<Wallet?> GetWalletByUserID(int userId);
        Task AddWallet(Wallet wallet);
        Task UpdateWallet(Wallet wallet);
        Task DeleteWallet(int id);
    }
}
