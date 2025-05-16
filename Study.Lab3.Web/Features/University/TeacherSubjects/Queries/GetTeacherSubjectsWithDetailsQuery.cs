using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.TeacherSubjects.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TeacherSubjects.Queries;

/// <summary>
/// Получение списка предметов учителя с детальной информацией
/// </summary>
public sealed class GetTeacherSubjectsWithDetailsQuery : IRequest<TeacherSubjectWithDetailsDto[]>
{
    /// <summary>
    /// Идентификатор учителя
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnTeacher { get; init; }
}

public sealed class GetTeacherSubjectsWithDetailsQueryHandler
    : IRequestHandler<GetTeacherSubjectsWithDetailsQuery, TeacherSubjectWithDetailsDto[]>
{
    private readonly DataContext _dataContext;

    public GetTeacherSubjectsWithDetailsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<TeacherSubjectWithDetailsDto[]> Handle(
        GetTeacherSubjectsWithDetailsQuery request,
        CancellationToken cancellationToken)
    {
        return await _dataContext.TeacherSubjects
            .AsNoTracking()
            .Where(x => x.IsnTeacher == request.IsnTeacher)
            .Select(ts => new TeacherSubjectWithDetailsDto
            {
                IsnTeacher = ts.IsnTeacher,
                TeacherFullName = $"{ts.Teacher.SurName} {ts.Teacher.Name} {ts.Teacher.PatronymicName}",
                IsnSubject = ts.IsnSubject,
                SubjectName = ts.Subject.Name,
                StudentsCount = ts.Subject.Grades.Select(g => g.IsnStudent).Distinct().Count(),
                AverageGrade = ts.Subject.Grades.Average(g => g.Value)
            })
            .ToArrayAsync(cancellationToken);
    }
}