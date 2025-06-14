using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.GameStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.GameStore;

namespace Study.Lab3.Logic.Services.GameStore;

public sealed class GameService : IGameService
{
    public async Task CreateOrUpdateGameValidateAndThrowAsync(
        DataContext dataContext,
        Game game,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(game.Title))
            throw new BusinessLogicException("Название игры не может быть пустым");
        
        if (game.Title.Length > 200)
            throw new BusinessLogicException("Название игры не может превышать 200 символов");
        
        if (game.Price < 0)
            throw new BusinessLogicException("Цена игры не может быть отрицательной");
        
        if (game.Price > 99999.99)
            throw new BusinessLogicException("Цена игры не может превышать 99999.99");
        
        if (string.IsNullOrWhiteSpace(game.Genre))
            throw new BusinessLogicException("Жанр игры не может быть пустым");
        
        if (string.IsNullOrWhiteSpace(game.AgeRating))
            throw new BusinessLogicException("Возрастной рейтинг не может быть пустым");
        
        var validRatings = new[] { "E", "E10+", "T", "M", "AO", "RP" };
        
        if (!validRatings.Contains(game.AgeRating))
            throw new BusinessLogicException("Недопустимый возрастной рейтинг. Доступные: E, E10+, T, M, AO, RP");
        
        if (game.ReleaseDate > DateTime.UtcNow.AddYears(10))
            throw new BusinessLogicException("Дата выхода игры не может быть более чем через 10 лет");
        
        if (game.IsnDeveloper.HasValue)
        {
            if (!await dataContext.Developers.AnyAsync(x => x.IsnDeveloper == game.IsnDeveloper.Value, cancellationToken))
                throw new BusinessLogicException($"Разработчик с идентификатором \"{game.IsnDeveloper}\" не существует");
        }
        
        var existingGame = await dataContext.Games
            .FirstOrDefaultAsync(x => x.Title == game.Title && x.IsnGame != game.IsnGame, cancellationToken);
        
        if (existingGame != null)
            throw new BusinessLogicException($"Игра с названием \"{game.Title}\" уже существует");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Game game,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Games.AnyAsync(x => x.IsnGame == game.IsnGame, cancellationToken))
            throw new BusinessLogicException($"Игра с идентификатором \"{game.IsnGame}\" не существует");
    }
}
