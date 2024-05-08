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
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [EnumDataType(typeof(TransactionType))]
        public TransactionType TransactionType { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
         
        public int CoinId { get; set; }
        //[ForeignKey("CoinId")]
        public Coin Coin { get; set; }/* = null!;*/
    }
}
