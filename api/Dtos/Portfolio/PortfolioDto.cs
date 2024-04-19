using api.Models;

namespace api.Dtos.Portfolio
{
    public record PortfolioDto(List<CryptoTransaction> CryptoTransactions
    );
}
