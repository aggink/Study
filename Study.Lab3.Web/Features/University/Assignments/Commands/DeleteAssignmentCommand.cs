using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.University.Assignments.Commands;

/// <summary>
/// Удаление задания
/// </summary>
public sealed class DeleteAssignmentCommand : IRequest
{
    /// <summary>
    /// Идентификатор задания
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnAssignment { get; init; }
}

public sealed class DeleteAssignmentCommandHandler : IRequestHandler<DeleteAssignmentCommand>
{
    private readonly IAssignmentService _assignmentService;
    private readonly DataContext        _dataContext;

    public DeleteAssignmentCommandHandler(
        DataContext dataContext,
        IAssignmentService assignmentService)
    {
        _dataContext = dataContext;
        _assignmentService = assignmentService;
    }

    public async Task Handle(DeleteAssignmentCommand request, CancellationToken cancellationToken)
    {
        var assignment = await _dataContext.Assignments
                                           .FirstOrDefaultAsync(x => x.IsnAssignment == request.IsnAssignment,
                                               cancellationToken)
                         ?? throw new BusinessLogicException(
                             $"Задание с идентификатором \"{request.IsnAssignment}\" не существует");

        await _assignmentService.CanDeleteAndThrowAsync(
            _dataContext, assignment, cancellationToken);

        _dataContext.Assignments.Remove(assignment);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}