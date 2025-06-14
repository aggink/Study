using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.ProjectActivities.DtoModels;

namespace Study.Lab3.Web.Features.University.ProjectActivities.Queries;

/// <summary>
/// ѕолучение списка количеств выступлений
/// </summary>
public sealed class GetListProjectActivitiesQuery : IRequest<ProjectActivitiesDto[]>
{
}

public sealed class GetListProjectActivitiesQueryHandler : IRequestHandler<GetListProjectActivitiesQuery, ProjectActivitiesDto[]>
{
    private readonly DataContext _dataContext;

    public GetListProjectActivitiesQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ProjectActivitiesDto[]> Handle(GetListProjectActivitiesQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.TheProjectActivities
            .AsNoTracking()
            .Select(x => new ProjectActivitiesDto
            {
                IsnProjectActivities = x.IsnProjectActivities,
                IsnStudent = x.IsnStudent,
                IsnSubject = x.IsnSubject,
                PerformancesCount = x.PerformancesCount,
                ProjectActivitiesDate = x.ProjectActivitiesDate
            })
            .OrderByDescending(x => x.ProjectActivitiesDate)
            .ToArrayAsync(cancellationToken);
    }
}