using bank_api.Models;
using bank_api.Repositories.Interfaces;
using bank_api.Services.Interfaces;

namespace bank_api.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<Wallet?> GetWalletByID(int id)
        {
            return await _walletRepository.GetWalletByID(id);
        }

        public async Task<IEnumerable<Wallet>> GetAllWallets()
        {
            return await _walletRepository.GetAllWallets();
        }

        public async Task<Wallet?> GetWalletByUserID(int userId)
        {
            return await _walletRepository.GetWalletByUserID(userId);
        }

        public async Task AddWallet(Wallet wallet)
        {
            await _walletRepository.AddWallet(wallet);
        }

        public async Task UpdateWallet(Wallet wallet)
        {
            await _walletRepository.UpdateWallet(wallet);
        }

        public async Task DeleteWallet(int id)
        {
            await _walletRepository.DeleteWallet(id);
        }
    }
}
