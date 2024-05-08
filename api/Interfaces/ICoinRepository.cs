using api.Dto.CoinDto;
using api.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces
{
    public interface ICoinRepository
    {
        public Task<CreateCoinDto> CreateCoinAsync(CreateCoinDto coinDto);
        public Task<List<Coin>> GetAllCoinsAsync();
        public Task<Coin?> GetCoinByIdAsync(int id);
        public Task<Coin?> GetCoinByNameAsync(string name);
        //public Task<UpdateCoin?> PatchCoinAsync(int id, JsonPatchDocument<UpdateCoin> updateCoin);
        public Task<UpdateCoin?> UpdateCoinAsync(int id, UpdateCoin updateCoin);
        public Task<Coin?> DeleteCoinByIdAsync(int id);
        public Task<bool> CoinExists(int id);
        public Task SaveAsync();
    }
}
