using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Formula1.Teams.DtoModels;

namespace Study.Lab3.Web.Features.Formula1.Teams.Queries;

/// <summary>
/// Получить список комнад
/// </summary>
public class GetListTeamsQuery : IRequest<TeamItemDto[]>
{ }

public class GetListTeamsQueryHandler : IRequestHandler<GetListTeamsQuery, TeamItemDto[]>
{
    private readonly DataContext _dataContext;

    public GetListTeamsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<TeamItemDto[]> Handle(GetListTeamsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Teams
            .AsNoTracking()
            .OrderBy(x => x.Name)
            .Select(x => new TeamItemDto
            {
                IsnTeam = x.IsnTeam,
                Name = x.Name,
                YearOfCreation = x.YearOfCreation,
                EngineSupplier = x.EngineSupplier
            })
            .ToArrayAsync(cancellationToken);
    }
}