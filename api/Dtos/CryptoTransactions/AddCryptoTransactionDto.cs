using api.Dtos.Cryptocurrencies;

namespace api.Dtos.CryptoTransactions
{
    public record AddCryptoTransactionDto(
     AddCryptoCurrencyDto? CryptoCurrency,
     decimal Quantity,
     decimal PurchasePrice);
}
