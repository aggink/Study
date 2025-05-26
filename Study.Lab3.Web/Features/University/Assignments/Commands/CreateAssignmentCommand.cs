/*using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.Assignments.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Assignments.Commands;

/// <summary>
/// Создание задания
/// </summary>
public sealed class CreateAssignmentCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные задания
    /// </summary>
    [Required]
    [FromBody]
    public CreateAssignmentDto Assignment { get; init; }
}

public sealed class CreateAssignmentCommandHandler : IRequestHandler<CreateAssignmentCommand, Guid>
{
    private readonly IAssignmentService _assignmentService;
    private readonly DataContext _dataContext;

    public CreateAssignmentCommandHandler(
        DataContext dataContext,
        IAssignmentService assignmentService)
    {
        _dataContext = dataContext;
        _assignmentService = assignmentService;
    }

    public async Task<Guid> Handle(CreateAssignmentCommand request, CancellationToken cancellationToken)
    {
        var assignment = new Assignment
        {
            IsnAssignment = Guid.NewGuid(),
            IsnSubject = request.Assignment.IsnSubject,
            Title = request.Assignment.Title,
            Description = request.Assignment.Description,
            PublishDate = request.Assignment.PublishDate,
            Deadline = request.Assignment.Deadline,
            MaxScore = request.Assignment.MaxScore
        };

        await _assignmentService.CreateOrUpdateAssignmentValidateAndThrowAsync(
            _dataContext, assignment, cancellationToken);

        await _dataContext.Assignments.AddAsync(assignment, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return assignment.IsnAssignment;
    }
}*/