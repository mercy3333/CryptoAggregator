using api.Data;
using api.Dto.CoinDto;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/coins")]
    public class CoinController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CoinController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoins()
        {
            var allCoinsDto = await context.Coins.Select(s =>
                                            new GetCoinDto(s.Price,
                                                                s.MarketCap,
                                                                s.Volume24,
                                                                s.Name,
                                                                s.Symbol)).ToListAsync();
            return Ok(allCoinsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoinById([FromRoute] int id)
        {
            var coin = await context.Coins.FindAsync(id);

            if (coin == null)
            {
                return NotFound("There is no coin with provided id");
            }

            return Ok(new GetCoinDto(coin.Price,
                                            coin.MarketCap,
                                            coin.Volume24,
                                            coin.Name,
                                            coin.Symbol));
        }



        [HttpPost]
        public async Task<IActionResult> AddCoin([FromBody] CoinDto coinDto)
        {
            await context.Coins.AddAsync(new Coin { Name = coinDto.Name, Symbol = coinDto.Symbol });
            await context.SaveChangesAsync();

            return Ok(coinDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCoin([FromRoute] int id, [FromBody] CoinDto coinDto)
        {
            var coin = await context.Coins.FindAsync(id);
            if (coin == null)
            {
                return NotFound("There is no coin with provided id");
            }
            coin.Name = coinDto.Name;
            coin.Symbol = coinDto.Symbol;
            await context.SaveChangesAsync();

            return Ok(coinDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoinById([FromRoute] int id)
        {
            var coin = await context.Coins.FindAsync(id);

            if (coin == null)
            {
                return NotFound("There is no coin with provided id");
            }
            context.Coins.Remove(coin);
            await context.SaveChangesAsync();

            return Ok(new GetCoinDto(coin.Price,
                                            coin.MarketCap,
                                            coin.Volume24,
                                            coin.Name,
                                            coin.Symbol));
        }


    }
}
