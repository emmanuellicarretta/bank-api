using bank_api.Models;

namespace bank_api.Services.Interfaces
{
    public interface IWalletService
    {
        Task<Wallet?> GetWalletByID(int id);
        Task<IEnumerable<Wallet>> GetAllWallets();
        Task<Wallet?> GetWalletByUserID(int userId);
        Task AddWallet(Wallet wallet);
        Task UpdateWallet(Wallet wallet);
        Task DeleteWallet(int id);
    }
}
