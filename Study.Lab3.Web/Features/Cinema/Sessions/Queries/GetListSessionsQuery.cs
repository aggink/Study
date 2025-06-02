using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Cinema.Sessions.DtoModels;

namespace Study.Lab3.Web.Features.Cinema.Sessions.Queries;

/// <summary>
/// Получение списка сеансов
/// </summary>
public sealed class GetListSessionsQuery : IRequest<SessionDto[]>
{
}

public sealed class GetListSessionsQueryHandler : IRequestHandler<GetListSessionsQuery, SessionDto[]>
{
    private readonly DataContext _dataContext;

    public GetListSessionsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<SessionDto[]> Handle(GetListSessionsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Sessions
            .AsNoTracking()
            .Include(x => x.Movie)
            .Include(x => x.Hall)
            .Where(x => x.StartTime >= DateTime.UtcNow)
            .OrderBy(x => x.StartTime)
            .Select(x => new SessionDto
            {
                IsnSession = x.IsnSession,
                IsnMovie = x.IsnMovie,
                MovieTitle = x.Movie.Title,
                IsnHall = x.IsnHall,
                HallName = x.Hall.Name,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                BasePrice = x.BasePrice,
                IsActive = x.IsActive
            })
            .ToArrayAsync(cancellationToken);
    }
}