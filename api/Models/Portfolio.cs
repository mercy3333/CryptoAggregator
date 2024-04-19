using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        public ICollection<CryptoTransaction> CryptoTransactions { get; set; } = [];
    }
}
