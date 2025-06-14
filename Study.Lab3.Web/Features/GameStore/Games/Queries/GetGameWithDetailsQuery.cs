using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.GameStore.Games.DtoModels;

namespace Study.Lab3.Web.Features.GameStore.Games.Queries;

/// <summary>
/// Получение игры с деталями разработчика
/// </summary>
public sealed class GetGameWithDetailsQuery : IRequest<GameWithDetailsDto>
{
    /// <summary>
    /// Идентификатор игры
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnGame { get; init; }
}

public sealed class GetGameWithDetailsQueryHandler : IRequestHandler<GetGameWithDetailsQuery, GameWithDetailsDto>
{
    private readonly DataContext _dataContext;

    public GetGameWithDetailsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<GameWithDetailsDto> Handle(GetGameWithDetailsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Games
                   .AsNoTracking()
                   .Where(x => x.IsnGame == request.IsnGame)
                   .Select(x => new GameWithDetailsDto
                   {
                       IsnGame = x.IsnGame,
                       IsnDeveloper = x.IsnDeveloper,
                       DeveloperName = x.Developer != null ? x.Developer.CompanyName : null,
                       Title = x.Title,
                       Description = x.Description,
                       Price = x.Price,
                       ReleaseDate = x.ReleaseDate,
                       Genre = x.Genre,
                       AgeRating = x.AgeRating,
                       IsActive = x.IsActive
                   })
                   .FirstOrDefaultAsync(cancellationToken)
               ?? throw new BusinessLogicException(
                   $"Игра с идентификатором \"{request.IsnGame}\" не существует");
    }
}