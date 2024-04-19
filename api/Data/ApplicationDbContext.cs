using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Portfolio> Portfolios { get; set; }

        public DbSet<CryptoCurrency> CryptoCurrencies { get; set; }

        public DbSet<CryptoTransaction> CryptoTransactions { get; set; }
    }
}
