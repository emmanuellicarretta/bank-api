using bank_api.Models.Maps;
using bank_api.Models;
using Microsoft.EntityFrameworkCore;

namespace bank_api.Context
{
    public class BankDBContext : DbContext
    {

        public BankDBContext(DbContextOptions<BankDBContext> context) : base(context)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new WalletMap());
        }
    }
}
