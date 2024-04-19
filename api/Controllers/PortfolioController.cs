using api.Data;
using api.Dtos.CryptoTransactions;
using api.Dtos.Portfolio;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace api.Controllers
{
    [Route("api/portfolio")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        public PortfolioController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var portfolios = _context.Portfolios.ToList()
                .Select(x => new PortfolioDto(CryptoTransactions: x.CryptoTransactions.ToList()));

            return Ok(portfolios);
        }   


        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var portfolio = _context.Portfolios.Find(id);  

            if (portfolio == null)
            {
                return NotFound("There is no portfolio with provided id");
            }
            return Ok(new PortfolioDto(
                CryptoTransactions: portfolio.CryptoTransactions.ToList()));
        }

        [HttpPost]
        public IActionResult AddTransacrion([FromBody] AddCryptoTransactionDto cryptoTransaction)
        {
            //var sdasdas = JsonSerializer.Deserialize<CryptoTransaction>(Json);

            //var portfolio = _context.Portfolios.Find(id);

            //if (portfolio == null)
            //{
            //    return NotFound("There is no portfolio with provided id");
            //}
            //return Ok(new PortfolioDto(
            //    CryptoTransactions: portfolio.CryptoTransactions.ToList()));

            return Ok();
        }
    }
}
