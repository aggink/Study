using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Assignments.DtoModels;

namespace Study.Lab3.Web.Features.University.Assignments.Queries;

/// <summary>
/// Получение списка заданий
/// </summary>
public sealed class GetListAssignmentsQuery : IRequest<AssignmentDto[]>
{
}

public sealed class GetListAssignmentsQueryHandler : IRequestHandler<GetListAssignmentsQuery, AssignmentDto[]>
{
    private readonly DataContext _dataContext;

    public GetListAssignmentsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<AssignmentDto[]> Handle(GetListAssignmentsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Assignments
                                 .AsNoTracking()
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