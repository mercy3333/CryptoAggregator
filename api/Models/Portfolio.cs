using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("Portfolios")]
    public class Portfolio
    {
        public int Id { get; set; }
        public decimal NetWorth { get; set; } = 0;
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
