using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.ProjectActivities.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.ProjectActivities.Queries;

/// <summary>
/// Получить количество выступлений с деталями
/// </summary>
public sealed class GetProjectActivitiesWithDetailsQuery : IRequest<ProjectActivitiesWithDetailsDto>
{
    /// <summary>
    /// Идентификатор количества выступлений
    /// </summary>
    [Required]
    public Guid IsnProjectActivities { get; init; }
}

public sealed class GetProjectActivitiesWithDetailsQueryHandler : IRequestHandler<GetProjectActivitiesWithDetailsQuery, ProjectActivitiesWithDetailsDto>
{
    private readonly DataContext _dataContext;

    public GetProjectActivitiesWithDetailsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ProjectActivitiesWithDetailsDto> Handle(GetProjectActivitiesWithDetailsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.ProjectActivities
            .AsNoTracking()
            .Where(x => x.IsnProjectActivities == request.IsnProjectActivities)
            .Select(projectactivities => new ProjectActivitiesWithDetailsDto
            {
                IsnProjectActivities = projectactivities.IsnProjectActivities,
                IsnStudent = projectactivities.IsnStudent,
                StudentFullName = $"{projectactivities.Student.SurName} {projectactivities.Student.Name} {projectactivities.Student.PatronymicName}",
                IsnSubject = projectactivities.IsnSubject,
                SubjectName = projectactivities.Subject.Name,
                PerformancesCount = projectactivities.PerformancesCount,
                ProjectActivitiesDate = projectactivities.ProjectActivitiesDate,
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}