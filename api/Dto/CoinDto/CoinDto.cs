using System.ComponentModel.DataAnnotations;

namespace api.Dto.CoinDto
{
    public record CoinDto(
        [Required] string Name,
        [Required] string Symbol);
}
