using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.TheProjectActivities.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TheProjectActivities.Queries;

/// <summary>
/// Получить количество выступлений по идентификатору
/// </summary>
public sealed class GetProjectActivitiesByIsnQuery : IRequest<ProjectActivitiesDto>
{
    /// <summary>
    /// Идентификатор количества выступлений
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnProjectActivities { get; init; }
}

public sealed class GetProjectActivitiesByIsnQueryHandler : IRequestHandler<GetProjectActivitiesByIsnQuery, ProjectActivitiesDto>
{
    private readonly DataContext _dataContext;

    public GetProjectActivitiesByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ProjectActivitiesDto> Handle(GetProjectActivitiesByIsnQuery request, CancellationToken cancellationToken)
    {
        var projectactivities = await _dataContext.TheProjectActivities
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnProjectActivities == request.IsnProjectActivities, cancellationToken)
                ?? throw new BusinessLogicException($"Количества участников с идентификатором \"{request.IsnProjectActivities}\" не существует");

        return new ProjectActivitiesDto
        {
            IsnProjectActivities = projectactivities.IsnProjectActivities,
            IsnStudent = projectactivities.IsnStudent,
            IsnSubject = projectactivities.IsnSubject,
            PerformancesCount = projectactivities.PerformancesCount,
            ProjectActivitiesDate = projectactivities.ProjectActivitiesDate
        };
    }
}