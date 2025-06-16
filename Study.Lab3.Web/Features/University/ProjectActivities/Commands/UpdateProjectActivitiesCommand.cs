using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.ProjectActivities.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.ProjectActivities.Commands;

/// <summary>
/// Редактирование проектной деятельности
/// </summary>
public sealed class UpdateProjectActivitiesCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные проектной деятельности
    /// </summary>
    [Required]
    [FromBody]
    public UpdateProjectActivitiesDto ProjectActivities { get; init; }
}

public sealed class UpdateProjectActivitiesCommandHandler : IRequestHandler<UpdateProjectActivitiesCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IProjectActivitiesService _projectactivitiesService;

    public UpdateProjectActivitiesCommandHandler(
        DataContext dataContext,
        IProjectActivitiesService projectactivitiesService)
    {
        _dataContext = dataContext;
        _projectactivitiesService = projectactivitiesService;
    }

    public async Task<Guid> Handle(UpdateProjectActivitiesCommand request, CancellationToken cancellationToken)
    {
        var projectactivities = await _dataContext.ProjectActivities
            .Include(x => x.Subject)
            .FirstOrDefaultAsync(x => x.IsnProjectActivities == request.ProjectActivities.IsnProjectActivities, cancellationToken)
                ?? throw new BusinessLogicException($"Выступлений с идентификатором \"{request.ProjectActivities.IsnProjectActivities}\" не существует");

        projectactivities.PerformancesCount = request.ProjectActivities.PerformancesCount;
        projectactivities.ProjectActivitiesDate = request.ProjectActivities.ProjectActivitiesDate;

        await _projectactivitiesService.CreateOrUpdateProjectActivitiesValidateAndThrowAsync(
            _dataContext, projectactivities, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return projectactivities.IsnProjectActivities;
    }
}