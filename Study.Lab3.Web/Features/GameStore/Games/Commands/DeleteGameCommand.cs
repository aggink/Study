using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.GameStore;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.GameStore.Games.Commands;

/// <summary>
/// Удаление игры
/// </summary>
public sealed class DeleteGameCommand : IRequest
{
    /// <summary>
    /// Идентификатор игры
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnGame { get; init; }
}

public sealed class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand>
{
    private readonly DataContext _dataContext;
    private readonly IGameService _gameService;

    public DeleteGameCommandHandler(
        DataContext dataContext,
        IGameService gameService)
    {
        _dataContext = dataContext;
        _gameService = gameService;
    }

    public async Task Handle(DeleteGameCommand request, CancellationToken cancellationToken)
    {
        var game = await _dataContext.Games
                       .FirstOrDefaultAsync(x => x.IsnGame == request.IsnGame, cancellationToken)
                   ?? throw new BusinessLogicException(
                       $"Игра с идентификатором \"{request.IsnGame}\" не существует");

        await _gameService.CanDeleteAndThrowAsync(_dataContext, game, cancellationToken);

        _dataContext.Games.Remove(game);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}