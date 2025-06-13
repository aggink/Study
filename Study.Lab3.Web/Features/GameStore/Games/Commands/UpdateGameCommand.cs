using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.GameStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.GameStore.Games.DtoModels;

namespace Study.Lab3.Web.Features.GameStore.Games.Commands;

/// <summary>
/// Обновление игры
/// </summary>
public sealed class UpdateGameCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные игры
    /// </summary>
    [Required]
    [FromBody]
    public UpdateGameDto Game { get; init; }
}

public sealed class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IGameService _gameService;

    public UpdateGameCommandHandler(
        DataContext dataContext,
        IGameService gameService)
    {
        _dataContext = dataContext;
        _gameService = gameService;
    }

    public async Task<Guid> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
    {
        var game = await _dataContext.Games
                       .FirstOrDefaultAsync(x => x.IsnGame == request.Game.IsnGame, cancellationToken)
                   ?? throw new BusinessLogicException(
                       $"Игра с идентификатором \"{request.Game.IsnGame}\" не существует");

        game.IsnDeveloper = request.Game.IsnDeveloper;
        game.Title = request.Game.Title;
        game.Description = request.Game.Description;
        game.Price = request.Game.Price;
        game.ReleaseDate = request.Game.ReleaseDate;
        game.Genre = request.Game.Genre;
        game.AgeRating = request.Game.AgeRating;
        game.IsActive = request.Game.IsActive;

        await _gameService.CreateOrUpdateGameValidateAndThrowAsync(
            _dataContext, game, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return game.IsnGame;
    }
}