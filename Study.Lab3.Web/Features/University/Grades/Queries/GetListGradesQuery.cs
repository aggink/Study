using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Grades.DtoModels;

namespace Study.Lab3.Web.Features.University.Grades.Queries;

/// <summary>
/// Получение списка оценок
/// </summary>
public sealed class GetListGradesQuery : IRequest<GradeDto[]>
{
}

public sealed class GetListGradesQueryHandler : IRequestHandler<GetListGradesQuery, GradeDto[]>
{
    private readonly DataContext _dataContext;

    public GetListGradesQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<GradeDto[]> Handle(GetListGradesQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Grades
            .AsNoTracking()
            .Select(x => new GradeDto
            {
                IsnGrade = x.IsnGrade,
                IsnStudent = x.IsnStudent,
                IsnSubject = x.IsnSubject,
                Value = x.Value,
                GradeDate = x.GradeDate
            })
            .OrderByDescending(x => x.GradeDate)
            .ToArrayAsync(cancellationToken);
    }
}