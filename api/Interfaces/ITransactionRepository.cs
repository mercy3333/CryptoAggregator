using api.Dto.TransactionDto;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces
{
    public interface ITransactionRepository
    {
        public Task<List<Transaction>> GetAllTransactions();
        public Task<Transaction> CreateTransaction(CreateTransactionDto transactionDto);
        public Task<Transaction?> GetTransactionsById(int id);
        public Task<Transaction?> UpdateTransactionsById(int id, UpdateTransaction updateTransaction);
        public Task<Transaction?> DeleteTransactionsById(int id);
        public Task SaveAsync();
    }
}