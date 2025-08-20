namespace Gamestore.Api.Dtos
{
    public record createGameDto(
        string Name,
        string Genre,
        decimal Price,
        DateOnly ReleaseDate
    );
}