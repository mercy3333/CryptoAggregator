using api.Dtos.Cryptocurrencies;
using api.Models;

namespace api.Dtos.CryptoTransactions
{
    public record CryptoTransactionDto(
     CryptoCurrencyDto? CryptoCurrency ,
     decimal Quantity ,
     decimal PurchasePrice ,
     DateTime PurchaseTime);
}
