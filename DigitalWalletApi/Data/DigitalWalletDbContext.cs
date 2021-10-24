using DigitalWalletApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace DigitalWalletApi.Data
{
    public class DigitalWalletDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }

        public DigitalWalletDbContext(DbContextOptions<DigitalWalletDbContext> options)
            : base(options)
        {
            
        }
    }
}