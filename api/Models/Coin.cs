using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Coins")]
    public class Coin
    {
        public int Id { get; set; }
        public decimal Price { get; set; } = 0;
        public decimal MarketCap { get; set; } = 0;
        public decimal Volume24 { get; set; } = 0;
        [Required] public string Name { get; set; } = string.Empty;
        [Required] public string Symbol { get; set; } = string.Empty;
    }
}
