using System.ComponentModel.DataAnnotations;

namespace api.Dto.CoinDto
{
    public record CreateCoinDto(
        [Required] string Name,
        [Required] string Symbol);
}
