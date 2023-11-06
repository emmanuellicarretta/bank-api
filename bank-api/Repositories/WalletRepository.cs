using bank_api.Context;
using bank_api.Models;
using bank_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace bank_api.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly BankDBContext _bankDBContext;

        public WalletRepository(BankDBContext kognitDBContext)
        {
            _bankDBContext = kognitDBContext;
        }

        public async Task<Wallet?> GetWalletByID(int id)
        {
            var wallet = await _bankDBContext.Wallets.FindAsync(id);
            return wallet;
        }

        public async Task<IEnumerable<Wallet>> GetAllWallets()
        {
            var wallets = await _bankDBContext.Wallets.ToListAsync();
            return wallets;
        }

        public async Task<Wallet?> GetWalletByUserID(int userId)
        {
            var wallet = await _bankDBContext.Wallets.FindAsync(userId);
            return wallet;
        }

        public async Task AddWallet(Wallet wallet)
        {
            await _bankDBContext.Wallets.AddAsync(wallet);
            await _bankDBContext.SaveChangesAsync();
        }

        public async Task UpdateWallet(Wallet wallet)
        {
            var foundWallet = await _bankDBContext.Wallets.FindAsync(wallet.Id);
            if (foundWallet != null)
            {
                foundWallet.UserId = wallet.UserId;
                foundWallet.CurrentValue = wallet.CurrentValue;
                foundWallet.Bank = wallet.Bank;
                foundWallet.LastUpdate = wallet.LastUpdate;
                _bankDBContext.Wallets.Update(foundWallet);
                await _bankDBContext.SaveChangesAsync();
            }
        }

        public async Task DeleteWallet(int id)
        {
            var wallet = await _bankDBContext.Wallets.FindAsync(id);
            if (wallet != null)
            {
                _bankDBContext.Wallets.Remove(wallet);
                await _bankDBContext.SaveChangesAsync();
            }
        }
    }
}
