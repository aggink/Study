using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Grades.DtoModels;
using Study.Lab3.Web.Features.University.Teachers.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Grades.Queries;

/// <summary>
/// Получить оценку с деталями
/// </summary>
public sealed class GetGradeWithDetailsQuery : IRequest<GradeWithDetailsDto>
{
    /// <summary>
    /// Идентификатор оценки
    /// </summary>
    [Required]
    public Guid IsnGrade { get; init; }
}

public sealed class GetGradeWithDetailsQueryHandler : IRequestHandler<GetGradeWithDetailsQuery, GradeWithDetailsDto>
{
    private readonly DataContext _dataContext;

    public GetGradeWithDetailsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<GradeWithDetailsDto> Handle(GetGradeWithDetailsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Grades
            .AsNoTracking()
            .Where(x => x.IsnGrade == request.IsnGrade)
            .Select(grade => new GradeWithDetailsDto
            {
                IsnGrade = grade.IsnGrade,
                IsnStudent = grade.IsnStudent,
                StudentFullName = $"{grade.Student.SurName} {grade.Student.Name} {grade.Student.PatronymicName}",
                IsnSubject = grade.IsnSubject,
                SubjectName = grade.Subject.Name,
                Value = grade.Value,
                GradeDate = grade.GradeDate,
                Teacher = grade.Subject.TeacherSubjects
                    .Select(ts => new TeacherInfoDto
                    {
                        IsnTeacher = ts.Teacher.IsnTeacher,
                        FullName = $"{ts.Teacher.SurName} {ts.Teacher.Name} {ts.Teacher.PatronymicName}"
                    })
                    .FirstOrDefault()
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}