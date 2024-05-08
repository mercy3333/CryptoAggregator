using api.Data;
using api.Dto.CoinDto;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CoinRepository : ICoinRepository
    {
        private readonly ApplicationDbContext context;

        public CoinRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<CreateCoinDto> CreateCoinAsync(CreateCoinDto coinDto)
        {
            await context.Coins.AddAsync(new Coin { Name = coinDto.Name, Symbol = coinDto.Symbol });
            await SaveAsync();
            return coinDto;
        }

        public async Task<Coin?> DeleteCoinByIdAsync(int id)
        {
            var coin = await context.Coins.FindAsync(id);

            if (coin == null)
            {
                return null;
            }
            context.Coins.Remove(coin);
            await SaveAsync();
            return coin;
        }

        public async Task<List<Coin>> GetAllCoinsAsync()
        {
            //var allCoinsDto = await context.Coins.Select(s =>
            //                               new GetCoinDto(s.Price,
            //                                                   s.MarketCap,
            //                                                   s.Volume24,
            //                                                   s.Name,
            //                                                   s.Symbol)).ToListAsync();

            var allCoins = await context.Coins.ToListAsync();
            return allCoins;
        }

        public async Task<Coin?> GetCoinByIdAsync(int id)
        {
            var coin = await context.Coins.FindAsync(id);
            return coin;
        }

        public async Task<Coin?> GetCoinByNameAsync(string name)
        {
            var coin = await context.Coins.FirstOrDefaultAsync(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            return coin;
        }


        public async Task<UpdateCoin?> UpdateCoinAsync(int id, UpdateCoin updateCoin)
        {
            var coin = await context.Coins.FindAsync(id);

            if (coin == null)
            { 
                return null; 
            }

            coin.Name = updateCoin.Name;
            coin.Symbol = updateCoin.Symbol;
            coin.Price = updateCoin.Price;
            coin.MarketCap = updateCoin.MarketCap;
            coin.Volume24 = updateCoin.Volume24;

            await SaveAsync();

            return updateCoin;
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

    }
}
