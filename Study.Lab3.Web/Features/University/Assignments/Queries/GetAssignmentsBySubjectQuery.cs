using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Assignments.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Assignments.Queries;

/// <summary>
/// Получение заданий по предмету
/// </summary>
public sealed class GetAssignmentsBySubjectQuery : IRequest<AssignmentDto[]>
{
    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnSubject { get; init; }
}

public sealed class GetAssignmentsBySubjectQueryHandler : IRequestHandler<GetAssignmentsBySubjectQuery, AssignmentDto[]>
{
    private readonly DataContext _dataContext;

    public GetAssignmentsBySubjectQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<AssignmentDto[]> Handle(GetAssignmentsBySubjectQuery request, CancellationToken cancellationToken)
    {
        if (!await _dataContext.Subjects.AnyAsync(x => x.IsnSubject == request.IsnSubject, cancellationToken))
            throw new BusinessLogicException($"Предмет с идентификатором \"{request.IsnSubject}\" не существует");

        return await _dataContext.Assignments
            .AsNoTracking()
            .Where(x => x.IsnSubject == request.IsnSubject)
            .Select(x => new AssignmentDto
            {
                IsnAssignment = x.IsnAssignment,
                IsnSubject = x.IsnSubject,
                Title = x.Title,
                Description = x.Description,
                PublishDate = x.PublishDate,
                Deadline = x.Deadline,
                MaxScore = x.MaxScore
            })
            .OrderByDescending(x => x.PublishDate)
            .ToArrayAsync(cancellationToken);
    }
}