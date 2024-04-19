namespace api.Models
{
    public class CryptoCurrency
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal MarketCap { get; set; }
        public decimal Volume24 { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public string ERC20_ContractAdress { get; set; } = string.Empty;
        public string BSC20_ContractAdress { get; set; } = string.Empty;
        public List<CryptoTransaction> CryptoTransactions { get; set; } = [];
    }
}
