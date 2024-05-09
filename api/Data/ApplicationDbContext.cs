using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
            
        }

        public DbSet<Coin> Coins { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasOne(d => d.Coin)
                .WithMany()
                .HasForeignKey(d => d.CoinId);
            });

            modelBuilder.Entity<Portfolio>()
                .HasMany(x => x.Transactions)
                .WithOne()
                .HasForeignKey(c => c.PortfolioId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
