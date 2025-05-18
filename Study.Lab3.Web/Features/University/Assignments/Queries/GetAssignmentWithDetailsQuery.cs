using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Assignments.DtoModels;

namespace Study.Lab3.Web.Features.University.Assignments.Queries;

/// <summary>
/// Получить задание с детальной информацией
/// </summary>
public sealed class GetAssignmentWithDetailsQuery : IRequest<AssignmentWithDetailsDto>
{
    /// <summary>
    /// Идентификатор задания
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnAssignment { get; init; }
}

public sealed class
    GetAssignmentWithDetailsQueryHandler : IRequestHandler<GetAssignmentWithDetailsQuery, AssignmentWithDetailsDto>
{
    private readonly DataContext _dataContext;

    public GetAssignmentWithDetailsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<AssignmentWithDetailsDto> Handle(GetAssignmentWithDetailsQuery request,
        CancellationToken cancellationToken)
    {
        return await _dataContext.Assignments
                                 .AsNoTracking()
                                 .Where(x => x.IsnAssignment == request.IsnAssignment)
                                 .Select(x => new AssignmentWithDetailsDto
                                 {
                                     IsnAssignment = x.IsnAssignment,
                                     IsnSubject = x.IsnSubject,
                                     SubjectName = x.Subject.Name,
                                     Title = x.Title,
                                     Description = x.Description,
                                     PublishDate = x.PublishDate,
                                     Deadline = x.Deadline,
                                     MaxScore = x.MaxScore
                                 })
                                 .FirstOrDefaultAsync(cancellationToken)
               ?? throw new BusinessLogicException(
                   $"Задание с идентификатором \"{request.IsnAssignment}\" не существует");
    }
}