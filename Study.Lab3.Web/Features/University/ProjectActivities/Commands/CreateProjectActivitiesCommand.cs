using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.ProjectActivities.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.ProjectActivities.Commands;

/// <summary>
/// Создание проектной деятельности
/// </summary>
public sealed class CreateProjectActivitiesCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные проектной деятельности
    /// </summary>
    [Required]
    [FromBody]
    public CreateProjectActivitiesDto ProjectActivities { get; init; }
}

public sealed class CreateProjectActivitiesCommandHandler : IRequestHandler<CreateProjectActivitiesCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IProjectActivitiesService _projectactivitiesService;

    public CreateProjectActivitiesCommandHandler(
        DataContext dataContext,
        IProjectActivitiesService projectactivitiesService)
    {
        _dataContext = dataContext;
        _projectactivitiesService = projectactivitiesService;
    }

    public async Task<Guid> Handle(CreateProjectActivitiesCommand request, CancellationToken cancellationToken)
    {
        var projectactivities = new Storage.Models.University.ProjectActivities
        {
            IsnProjectActivities = Guid.NewGuid(),
            IsnStudent = request.ProjectActivities.IsnStudent,
            IsnSubject = request.ProjectActivities.IsnSubject,
            PerformancesCount = request.ProjectActivities.ParticipantsCount,
            ProjectActivitiesDate = request.ProjectActivities.ProjectActivitiesDate
        };

        await _projectactivitiesService.CreateOrUpdateProjectActivitiesValidateAndThrowAsync(
            _dataContext, projectactivities, cancellationToken);

        await _dataContext.TheProjectActivities.AddAsync(projectactivities, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return projectactivities.IsnProjectActivities;
    }
}