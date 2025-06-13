using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.GameStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.GameStore;
using Study.Lab3.Web.Features.GameStore.Games.DtoModels;

namespace Study.Lab3.Web.Features.GameStore.Games.Commands;

/// <summary>
/// Создание игры
/// </summary>
public sealed class CreateGameCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные игры
    /// </summary>
    [Required]
    [FromBody]
    public CreateGameDto Game { get; init; }
}

public sealed class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IGameService _gameService;

    public CreateGameCommandHandler(
        DataContext dataContext,
        IGameService gameService)
    {
        _dataContext = dataContext;
        _gameService = gameService;
    }

    public async Task<Guid> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        var game = new Game
        {
            IsnGame = Guid.NewGuid(),
            IsnDeveloper = request.Game.IsnDeveloper,
            Title = request.Game.Title,
            Description = request.Game.Description,
            Price = request.Game.Price,
            ReleaseDate = request.Game.ReleaseDate,
            Genre = request.Game.Genre,
            AgeRating = request.Game.AgeRating,
            IsActive = request.Game.IsActive
        };

        await _gameService.CreateOrUpdateGameValidateAndThrowAsync(
            _dataContext, game, cancellationToken);

        await _dataContext.Games.AddAsync(game, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return game.IsnGame;
    }
}