/*using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Assignments.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Assignments.Commands;

/// <summary>
/// Обновление задания
/// </summary>
public sealed class UpdateAssignmentCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные задания
    /// </summary>
    [Required]
    [FromBody]
    public UpdateAssignmentDto Assignment { get; init; }
}

public sealed class UpdateAssignmentCommandHandler : IRequestHandler<UpdateAssignmentCommand, Guid>
{
    private readonly IAssignmentService _assignmentService;
    private readonly DataContext _dataContext;

    public UpdateAssignmentCommandHandler(
        DataContext dataContext,
        IAssignmentService assignmentService)
    {
        _dataContext = dataContext;
        _assignmentService = assignmentService;
    }

    public async Task<Guid> Handle(UpdateAssignmentCommand request, CancellationToken cancellationToken)
    {
        var assignment = await _dataContext.Assignments
                             .FirstOrDefaultAsync(
                                 x => x.IsnAssignment == request.Assignment.IsnAssignment,
                                 cancellationToken)
                         ?? throw new BusinessLogicException(
                             $"Задание с идентификатором \"{request.Assignment.IsnAssignment}\" не существует");

        assignment.Title = request.Assignment.Title;
        assignment.Description = request.Assignment.Description;
        assignment.Deadline = request.Assignment.Deadline;
        assignment.MaxScore = request.Assignment.MaxScore;

        await _assignmentService.CreateOrUpdateAssignmentValidateAndThrowAsync(
            _dataContext, assignment, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return assignment.IsnAssignment;
    }
}*/