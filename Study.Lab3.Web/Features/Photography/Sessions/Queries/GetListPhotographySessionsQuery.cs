using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Photography.Sessions.DtoModels;

namespace Study.Lab3.Web.Features.Photography.Sessions.Queries;

/// <summary>
/// Получение списка фотосессий
/// </summary>
public sealed class GetListPhotographySessionsQuery : IRequest<PhotographySessionDto[]>
{
}

public sealed class GetListPhotographySessionsQueryHandler : IRequestHandler<GetListPhotographySessionsQuery, PhotographySessionDto[]>
{
    private readonly DataContext _dataContext;

    public GetListPhotographySessionsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PhotographySessionDto[]> Handle(GetListPhotographySessionsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.PhotographySessions
            .AsNoTracking()
            .Select(x => new PhotographySessionDto
            {
                IsnPhotographySession = x.IsnPhotographySession,
                Title = x.Title,
                SessionDate = x.SessionDate,
                Duration = x.Duration,
                Location = x.Location,
                Price = x.Price,
                PhotographerName = x.PhotographerName,
                PhotographySessionType = x.PhotographySessionType,
                Status = x.Status,
                Description = x.Description,
                PhotoCount = x.PhotoCount
            })
            .OrderByDescending(x => x.SessionDate)
            .ToArrayAsync(cancellationToken);
    }
}