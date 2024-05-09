using api.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace api.Dto.TransactionDto
{
    public record CreateTransactionDto(
        [Required] int PortfolioId,
        [Required] int CoinId,
        [Required] decimal Quantity,
        [Required] decimal Price,
        [Required][EnumDataType(typeof(TransactionType))] TransactionType TransactionType
        );
}
