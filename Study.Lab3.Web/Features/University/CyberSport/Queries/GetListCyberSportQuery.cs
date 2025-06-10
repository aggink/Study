using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.CyberSport.DtoModels;

namespace Study.Lab3.Web.Features.University.CyberSport.Queries;

/// <summary>
/// получение списка количеств участников
/// </summary>
public sealed class GetListCyberSportQuery : IRequest<CyberSportDto[]>
{
}

public sealed class GetListCyberSportQueryHandler : IRequestHandler<GetListCyberSportQuery, CyberSportDto[]>
{
    private readonly DataContext _dataContext;

    public GetListCyberSportQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<CyberSportDto[]> Handle(GetListCyberSportQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.CyberSport
            .AsNoTracking()
            .Select(x => new CyberSportDto
            {
                IsnCyberSport = x.IsnCyberSport,
                IsnStudent = x.IsnStudent,
                IsnSubject = x.IsnSubject,
                PointsCount = x.PointsCount,
                CyberSportDate = x.CyberSportDate
            })
            .OrderByDescending(x => x.CyberSportDate)
            .ToArrayAsync(cancellationToken);
    }
}