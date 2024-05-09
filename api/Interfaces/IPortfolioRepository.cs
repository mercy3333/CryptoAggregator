using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces
{
    public interface IPortfolioRepository
    {
        public Task<Portfolio?> ClearPortfolioTransactions(int id);
        public Task<Portfolio> CreatePortfolio();
        public Task<Portfolio?> DeletePortfolioById(int id);
        public Task<Portfolio?> GetPortfolioById(int id);
    }
}