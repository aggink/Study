using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.GameStore.Games.DtoModels;

namespace Study.Lab3.Web.Features.GameStore.Games.Queries;

/// <summary>
/// Получение игры по идентификатору
/// </summary>
public sealed class GetGameByIsnQuery : IRequest<GameDto>
{
    /// <summary>
    /// Идентификатор игры
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnGame { get; init; }
}

public sealed class GetGameByIsnQueryHandler : IRequestHandler<GetGameByIsnQuery, GameDto>
{
    private readonly DataContext _dataContext;

    public GetGameByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<GameDto> Handle(GetGameByIsnQuery request, CancellationToken cancellationToken)
    {
        var game = await _dataContext.Games
                       .AsNoTracking()
                       .FirstOrDefaultAsync(x => x.IsnGame == request.IsnGame, cancellationToken)
                   ?? throw new BusinessLogicException(
                       $"Игра с идентификатором \"{request.IsnGame}\" не существует");

        return new GameDto
        {
            IsnGame = game.IsnGame,
            IsnDeveloper = game.IsnDeveloper,
            Title = game.Title,
            Description = game.Description,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
            Genre = game.Genre,
            AgeRating = game.AgeRating,
            IsActive = game.IsActive
        };
    }
}