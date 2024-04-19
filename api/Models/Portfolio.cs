using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Portfolios")]
    public class Portfolio
    {
        public int Id { get; set; }
        public ICollection<CryptoTransaction> CryptoTransactions { get; set; } = [];
        public string UserId { get; set; }
        public User? User { get; set; }
    }
}
