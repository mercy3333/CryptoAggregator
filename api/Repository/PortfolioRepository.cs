using api.Controllers;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly ApplicationDbContext context;

        public PortfolioRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Portfolio?> GetPortfolioById(int id)
        {
            var portfolio = await context.Portfolios
             .Include(x => x.Transactions)
             .ThenInclude(c => c.Coin)
             .FirstOrDefaultAsync(t => t.Id == id);

            if (portfolio == null)
            {
                return null;
            }

            return portfolio;
        }
        public async  Task<Portfolio> CreatePortfolio()
        {
            var portfolio = new Portfolio();  //Portfolio id dolzhno ravno account id
            await context.AddAsync(portfolio);
            await context.SaveChangesAsync();
            return portfolio;
        }
        public async Task<Portfolio?> ClearPortfolioTransactions(int id)
        {
            var portfolio = await context.Portfolios.Include(x => x.Transactions)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (portfolio == null)
            {
                return null;
            }

            context.Transactions.RemoveRange(portfolio.Transactions);
            await context.SaveChangesAsync();
            return portfolio;
        }
        public async Task<Portfolio?> DeletePortfolioById(int id)
        {
            var portfolio = await context.Portfolios.FindAsync(id);

            if (portfolio == null)
            {
                return null;
            }

            context.Portfolios.Remove(portfolio);
            await context.SaveChangesAsync();
            return portfolio;
        }
    }
}
