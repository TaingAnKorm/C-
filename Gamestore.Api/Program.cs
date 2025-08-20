using Gamestore.Api.Dtos;

namespace Gamestore.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();
        const string GetGameEndpoint = "GetGame";
        //Create a List of Games
        List<GameDto> games = [
            new (
                1,
                "Street Fighter II",
                "Fighting",
                19.99M,
                new DateOnly(1992, 7, 15)),
            new (
                2,
                "Final Fantasy XIV",
                "Roleplaying",
                59.99M,
                new DateOnly(2010, 9, 30)),
            new (
                3,
                "FIFA 23",
                "Sports",
                69.99M,
                new DateOnly(2022, 9, 27)),
        ];
        //GET /games
        app.MapGet("games", () => games);
        //app.MapGet("/games", () => games);

        //GET /games/1
        app.MapGet("games/{id:int}", (int id)
            => games.Find(game => game.Id == id)).WithName(GetGameEndpoint);



        app.MapPost("games", (createGameDto newGame) =>
        {
            GameDto game = new(
                games.Count + 1, newGame.Name, newGame.Genre,
                newGame.Price, newGame.ReleaseDate);
            games.Add(game);
            return Results.CreatedAtRoute(GetGameEndpoint, new { id = game.Id }, game);
            // return Results.NoContent();
        });

        app.MapPut("games/{id}", (int id, updateGameDto updatedGame) =>
        {
            var index = games.Find(game => game.Id == id);
            games[index] = new GameDto(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.ReleaseDate
                );
            return Results.NoContent();
        });



        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}
