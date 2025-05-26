using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.TeacherSubjects.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TeacherSubjects.Queries;
//Запрос на получение преподавателя по предмету
/// <summary>
/// Получение списка учителей по предмету
/// </summary>
public sealed class GetTeachersBySubjectQuery : IRequest<TeacherSubjectWithDetailsDto[]>
{
    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnSubject { get; init; }
}

public sealed class GetTeachersBySubjectQueryHandler
    : IRequestHandler<GetTeachersBySubjectQuery, TeacherSubjectWithDetailsDto[]>
{
    private readonly DataContext _dataContext;

    public GetTeachersBySubjectQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<TeacherSubjectWithDetailsDto[]> Handle(
        GetTeachersBySubjectQuery request,
        CancellationToken cancellationToken)
    {
        var subject = await _dataContext.Subjects
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnSubject == request.IsnSubject, cancellationToken)
                ?? throw new BusinessLogicException($"Предмет с идентификатором \"{request.IsnSubject}\" не существует");

        return await _dataContext.TeacherSubjects
            .AsNoTracking()
            .Where(x => x.IsnSubject == request.IsnSubject)
            .Select(ts => new TeacherSubjectWithDetailsDto
            {
                IsnTeacher = ts.IsnTeacher,
                TeacherFullName = $"{ts.Teacher.SurName} {ts.Teacher.Name} {ts.Teacher.PatronymicName}",
                IsnSubject = ts.IsnSubject,
                SubjectName = subject.Name,
                StudentsCount = subject.Grades.Select(g => g.IsnStudent).Distinct().Count(),
                AverageGrade = subject.Grades.Any()
                    ? subject.Grades.Average(g => g.Value)
                    : 0
            })
            .OrderBy(x => x.TeacherFullName)
            .ToArrayAsync(cancellationToken);
    }
}