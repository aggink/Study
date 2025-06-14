using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.ProjectActivities.Commands;

/// <summary>
/// Удаление проектной деятельности
/// </summary>
public sealed class DeleteProjectActivitiesCommand : IRequest
{
    /// <summary>
    /// Идентификатор проектной деятельности
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnProjectActivities { get; init; }
}

public sealed class DeleteProjectActivitiesCommandHandler : IRequestHandler<DeleteProjectActivitiesCommand>
{
    private readonly DataContext _dataContext;
    private readonly IProjectActivitiesService _projectactivitiesService;

    public DeleteProjectActivitiesCommandHandler(
        DataContext dataContext,
        IProjectActivitiesService projectactivitiesService)
    {
        _dataContext = dataContext;
        _projectactivitiesService = projectactivitiesService;
    }

    public async Task Handle(DeleteProjectActivitiesCommand request, CancellationToken cancellationToken)
    {
        var projectactivities = await _dataContext.TheProjectActivities
            .Include(x => x.Subject)
            .FirstOrDefaultAsync(x => x.IsnProjectActivities == request.IsnProjectActivities, cancellationToken)
                ?? throw new BusinessLogicException($"Выступлений с идентификатором \"{request.IsnProjectActivities}\" не существует");

        await _projectactivitiesService.CanDeleteAndThrowAsync(
            _dataContext, projectactivities, cancellationToken);

        _dataContext.TheProjectActivities.Remove(projectactivities);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}