using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.GameStore.Games.DtoModels;

namespace Study.Lab3.Web.Features.GameStore.Games.Queries;

/// <summary>
/// Получение списка игр
/// </summary>
public sealed class GetListGamesQuery : IRequest<GameDto[]>
{
}

public sealed class GetListGamesQueryHandler : IRequestHandler<GetListGamesQuery, GameDto[]>
{
    private readonly DataContext _dataContext;

    public GetListGamesQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<GameDto[]> Handle(GetListGamesQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Games
            .AsNoTracking()
            .Select(x => new GameDto
            {
                IsnGame = x.IsnGame,
                IsnDeveloper = x.IsnDeveloper,
                Title = x.Title,
                Description = x.Description,
                Price = x.Price,
                ReleaseDate = x.ReleaseDate,
                Genre = x.Genre,
                AgeRating = x.AgeRating,
                IsActive = x.IsActive
            })
            .OrderBy(x => x.Title)
            .ToArrayAsync(cancellationToken);
    }
}