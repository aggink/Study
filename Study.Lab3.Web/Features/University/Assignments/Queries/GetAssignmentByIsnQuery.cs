using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Assignments.DtoModels;

namespace Study.Lab3.Web.Features.University.Assignments.Queries;

/// <summary>
/// Получить задание по идентификатору
/// </summary>
public sealed class GetAssignmentByIsnQuery : IRequest<AssignmentDto>
{
    /// <summary>
    /// Идентификатор задания
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnAssignment { get; init; }
}

public sealed class GetAssignmentByIsnQueryHandler : IRequestHandler<GetAssignmentByIsnQuery, AssignmentDto>
{
    private readonly DataContext _dataContext;

    public GetAssignmentByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<AssignmentDto> Handle(GetAssignmentByIsnQuery request, CancellationToken cancellationToken)
    {
        var assignment = await _dataContext.Assignments
                                           .AsNoTracking()
                                           .FirstOrDefaultAsync(x => x.IsnAssignment == request.IsnAssignment,
                                               cancellationToken)
                         ?? throw new BusinessLogicException(
                             $"Задание с идентификатором \"{request.IsnAssignment}\" не существует");

        return new AssignmentDto
        {
            IsnAssignment = assignment.IsnAssignment,
            IsnSubject = assignment.IsnSubject,
            Title = assignment.Title,
            Description = assignment.Description,
            PublishDate = assignment.PublishDate,
            Deadline = assignment.Deadline,
            MaxScore = assignment.MaxScore
        };
    }
}