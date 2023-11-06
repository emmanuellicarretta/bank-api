using bank_api.Models;
using bank_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bank_api.Controllers
{

    [ApiController]
    [Route("api/wallets")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWalletByID(int id)
        {
            var wallet = await _walletService.GetWalletByID(id);
            return Ok(wallet);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWallets()
        {
            var wallets = await _walletService.GetAllWallets();
            return Ok(wallets);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetWalletByUserID(int userId)
        {
            var wallets = await _walletService.GetWalletByUserID(userId);
            return Ok(wallets);
        }

        [HttpPost]
        public async Task<IActionResult> AddWallet(Wallet wallet)
        {
            await _walletService.AddWallet(wallet);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWallet(int id, Wallet wallet)
        {
            await _walletService.UpdateWallet(wallet);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWallet(int id)
        {
            await _walletService.DeleteWallet(id);
            return Ok();
        }
    }
}
