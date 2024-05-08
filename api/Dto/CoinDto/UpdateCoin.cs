using System.ComponentModel.DataAnnotations;

namespace api.Dto.CoinDto
{
    public class UpdateCoin
    {
        public decimal Price { get; set; } = 0;
        public decimal MarketCap { get; set; } = 0;
        public decimal Volume24 { get; set; } = 0;
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Symbol { get; set; } = string.Empty;
    }
}
