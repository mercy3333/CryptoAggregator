using api.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace api.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        public int Id { get; set; }
        [Required]
        public int PortfolioId { get; set; }
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [EnumDataType(typeof(TransactionType))]
        public TransactionType TransactionType { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow.Date;
        [Required]
        public int CoinId { get; set; }
        public Coin Coin { get; set; } = null!;
    }
}
