namespace api.Dto.CoinDto
{
    public record GetCoinDto(decimal Price,
    decimal MarketCap,
    decimal Volume24,
    string Name,
    string Symbol);
}
