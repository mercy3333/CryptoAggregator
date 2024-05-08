using api.Data;
using api.Dto.CoinDto;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using api.Interfaces;

namespace api.Controllers
{
    [ApiController]
    [Route("api/coins")]
    public class CoinsController : ControllerBase
    {
        private readonly ICoinRepository coinRepository;

        public CoinsController(ICoinRepository coinRepository)
        {
            this.coinRepository = coinRepository;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCoins()
        {
            var allCoinsDto = await coinRepository.GetAllCoinsAsync();
            return Ok(allCoinsDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCoin([FromBody] CreateCoinDto coinDto)
        {
            await coinRepository.CreateCoinAsync(coinDto);
            return Ok(coinDto);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetCoinById([FromRoute] int id)
        {
            var coin = await coinRepository.GetCoinByIdAsync(id);

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

        [HttpGet("{name}")]
        public async Task<IActionResult> GetCoinByName([FromRoute] string name)
        {
            var coin = await coinRepository.GetCoinByNameAsync(name);

            if (coin == null)
            {
                return NotFound("There is no coin with provided name");
            }

            return Ok(new GetCoinDto(coin.Price,
                                            coin.MarketCap,
                                            coin.Volume24,
                                            coin.Name,
                                            coin.Symbol));
        }




        [HttpPut("id/{id}")]
        public async Task<IActionResult> UpdateCoin([FromRoute] int id, [FromBody] UpdateCoin updateCoin)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var coin = await coinRepository.UpdateCoinAsync(id, updateCoin);

            if (coin == null)
            {
                return NotFound("There is no coin with provided id");
            }

            return Ok(updateCoin);
        }

        [HttpPatch("id/{id}")]
        public async Task<IActionResult> PatchCoin([FromRoute] int id, JsonPatchDocument<UpdateCoin> updateCoin)
        {
            var coin = await coinRepository.GetCoinByIdAsync(id);

            if (coin == null)
            {
                return NotFound("There is no coin with provided id");
            }

            UpdateCoin _updateCoin = new UpdateCoin
            {
                Name = coin.Name,
                MarketCap = coin.MarketCap,
                Symbol = coin.Symbol,
                Price = coin.Price,
                Volume24 = coin.Volume24
            };

            updateCoin.ApplyTo(_updateCoin, ModelState);

            if (!TryValidateModel(_updateCoin))
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            coin.Name = _updateCoin.Name;
            coin.Symbol = _updateCoin.Symbol;
            coin.Price = _updateCoin.Price;
            coin.MarketCap = _updateCoin.MarketCap;
            coin.Volume24 = _updateCoin.Volume24;

            await coinRepository.SaveAsync();

            return Ok(coin);
        }
        [HttpDelete("id/{id}")]
        public async Task<IActionResult> DeleteCoinById([FromRoute] int id)
        {
            var coin = await coinRepository.DeleteCoinByIdAsync(id);

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


    }
}
