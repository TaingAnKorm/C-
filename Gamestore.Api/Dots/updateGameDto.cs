namespace Gamestore.Api.Dtos
{
    public record updateGameDto(
        string Name,
        string Genre,
        decimal Price,
        DateOnly ReleaseDate
    );
}