namespace api.Models
{
    public class CryptoTransaction
    {
        public int Id { get; set; }
        public int PortfolioId { get; set; }
        public Portfolio? Portfolio { get; set; }
        public int CryptoCurrenciesId { get; set; }
        public CryptoCurrency? CryptoCurrency { get; set; }
        decimal Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseTime { get; set; } = DateTime.Now;
    }
}
