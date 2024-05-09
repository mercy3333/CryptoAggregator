using api.Data;
using api.Dto.TransactionDto;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext context;

        public TransactionRepository(ApplicationDbContext context) 
        {
            this.context = context;
        }
        public async Task<List<Transaction>> GetAllTransactions()
        {
            return await context.Transactions.Include(coin => coin.Coin).ToListAsync();
        }

        public async Task<Transaction> CreateTransaction(CreateTransactionDto transactionDto)
        {
            Transaction newTransaction = new Transaction
            {
                Price = transactionDto.Price,
                Quantity = transactionDto.Quantity,
                TransactionType = transactionDto.TransactionType,
                CoinId = transactionDto.CoinId,
                PortfolioId = transactionDto.PortfolioId,
            };

            await context.Transactions.AddAsync(newTransaction);
            await SaveAsync();
            return newTransaction;
        }
        public async Task<Transaction?> GetTransactionsById(int id)
        {
            return await context.Transactions.Include(x => x.Coin).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Transaction?> DeleteTransactionsById(int id)
        {
            var transaction = await context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return null;
            }
            context.Transactions.Remove(transaction);
            await SaveAsync();
            return transaction;
        }




        public async Task<Transaction?> UpdateTransactionsById(int id, UpdateTransaction updateTransaction)
        {
            var transaction = await GetTransactionsById(id);

            if (transaction == null)
            {
                return null;
            }

            transaction.Price = updateTransaction.Price;
            transaction.Quantity = updateTransaction.Quantity;
            await SaveAsync();

            return transaction;
        }
        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
