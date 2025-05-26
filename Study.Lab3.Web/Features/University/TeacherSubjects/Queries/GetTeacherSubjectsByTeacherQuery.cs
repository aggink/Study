using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.TeacherSubjects.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TeacherSubjects.Queries;
//Запрос на получение предметов по преподавателю
/// <summary>
/// Получение списка предметов учителя
/// </summary>
public sealed class GetTeacherSubjectsByTeacherQuery : IRequest<TeacherSubjectWithDetailsDto[]>
{
    /// <summary>
    /// Идентификатор учителя
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnTeacher { get; init; }
}

public sealed class GetTeacherSubjectsByTeacherQueryHandler
    : IRequestHandler<GetTeacherSubjectsByTeacherQuery, TeacherSubjectWithDetailsDto[]>
{
    private readonly DataContext _dataContext;

    public GetTeacherSubjectsByTeacherQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<TeacherSubjectWithDetailsDto[]> Handle(
        GetTeacherSubjectsByTeacherQuery request,
        CancellationToken cancellationToken)
    {
        var teacher = await _dataContext.Teachers
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnTeacher == request.IsnTeacher, cancellationToken)
                ?? throw new BusinessLogicException($"Учитель с идентификатором \"{request.IsnTeacher}\" не существует");

        return await _dataContext.TeacherSubjects
            .AsNoTracking()
            .Where(x => x.IsnTeacher == request.IsnTeacher)
            .Select(ts => new TeacherSubjectWithDetailsDto
            {
                IsnTeacher = ts.IsnTeacher,
                TeacherFullName = $"{teacher.SurName} {teacher.Name} {teacher.PatronymicName}",
                IsnSubject = ts.IsnSubject,
                SubjectName = ts.Subject.Name,
                StudentsCount = ts.Subject.Grades.Select(g => g.IsnStudent).Distinct().Count(),
                AverageGrade = ts.Subject.Grades.Any()
                    ? ts.Subject.Grades.Average(g => g.Value)
                    : 0
            })
            .OrderBy(x => x.SubjectName)
            .ToArrayAsync(cancellationToken);
    }
}