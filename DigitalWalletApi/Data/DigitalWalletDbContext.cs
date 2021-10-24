using DigitalWalletApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace DigitalWalletApi.Data
{
    public class DigitalWalletDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DigitalWalletDbContext(DbContextOptions<DigitalWalletDbContext> options)
            : base(options)
        {
            
        }
    }
}