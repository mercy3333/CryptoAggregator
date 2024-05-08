using api.Data;
using api.Dto.CoinDto;
using api.Dto.TransactionDto;
using api.Interfaces;
using api.Models;
using api.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;


namespace api.Controllers
{
    [ApiController]
    [Route("/transactions")]
    public class TransactionsController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly ITransactionRepository transactionsRepository;
        private readonly ICoinRepository coinRepository;

        public TransactionsController(ApplicationDbContext context,ITransactionRepository transactionsRepository, ICoinRepository coinRepository)
        {
            this.context = context;
            this.transactionsRepository = transactionsRepository;
            this.coinRepository = coinRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            //context.Transactions.Include(coin => coin.Coin);

            return Ok(await transactionsRepository.GetAllTransactions());
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionDto transactionDto)
        {
            var coin = await coinRepository.GetCoinByIdAsync(transactionDto.CoinId);
            if (coin == null)
            {
                return NotFound("There is no coin with provided id");
            }

            return Ok(await transactionsRepository.CreateTransaction(transactionDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionsById([FromRoute] int id)
        {
            var transaction = await transactionsRepository.GetTransactionsById(id);

            if (transaction == null)
            {
                return NotFound("There is no transaction with provided id");
            }

            return Ok(transaction);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionsById([FromRoute] int id)
        {
            var transaction = await transactionsRepository.DeleteTransactionsById(id);

            if (transaction == null)
            {
                return NotFound("There is no transaction with provided id");
            }
            return Ok(transaction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransactionsById([FromRoute] int id, [FromBody] UpdateTransaction updateTransaction)
        {
            var transaction = await transactionsRepository.UpdateTransactionsById(id, updateTransaction);

            if (transaction == null)
            {
                return NotFound("There is no transaction with provided id");
            }
            return Ok(transaction);
        }
    }
}
