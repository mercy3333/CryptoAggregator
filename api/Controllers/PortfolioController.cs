using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("/portfolio")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly IPortfolioRepository portfolioRepository;

        public PortfolioController(IPortfolioRepository portfolioRepository)
        {
            this.portfolioRepository = portfolioRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPortfolioById([FromRoute] int id)
        {
            var portfolio = await portfolioRepository.GetPortfolioById(id);

            if (portfolio == null)
            {
                return NotFound("There is no portfolio with provided id");
            }

            return Ok(portfolio);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePortfolio()
        {
            var portfolio = await portfolioRepository.CreatePortfolio();
            return Ok(portfolio);
        }

        [HttpDelete("{id}/transactions")]
        public async Task<IActionResult> ClearPortfolioTransactions([FromRoute] int id)
        {
            var portfolio = await portfolioRepository.ClearPortfolioTransactions(id);

            if (portfolio == null)
            {
                return NotFound("There is no portfolio with provided id");
            }
            return Ok(portfolio);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePortfolioById([FromRoute] int id)
        {
            var portfolio = await portfolioRepository.DeletePortfolioById(id);

            if (portfolio == null)
            {
                return NotFound("There is no portfolio with provided id");
            }
            return Ok(portfolio);
        }




    }
}
