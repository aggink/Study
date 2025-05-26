using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Teachers.Queries;
//Запрос на получение подробный данных о преподавателе
public sealed class GetTeacherWithDetailsQuery : IRequest<TeacherWithDetailsDto>
{
    /// <summary>
    /// Идентификатор учителя
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnTeacher { get; init; }
}

public sealed class GetTeacherWithDetailsQueryHandler
    : IRequestHandler<GetTeacherWithDetailsQuery, TeacherWithDetailsDto>
{
    private readonly DataContext _dataContext;

    public GetTeacherWithDetailsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<TeacherWithDetailsDto> Handle(
        GetTeacherWithDetailsQuery request,
        CancellationToken cancellationToken)
    {
        return await _dataContext.Teachers
            .AsNoTracking()
            .Where(x => x.IsnTeacher == request.IsnTeacher)
            .Select(x => new TeacherWithDetailsDto
            {
                IsnTeacher = x.IsnTeacher,
                Name = x.Name,
                SurName = x.SurName,
                PatronymicName = x.PatronymicName,
                Sex = x.Sex,
                SubjectsCount = x.TeacherSubjects.Count,
                StudentsCount = x.TeacherSubjects
                    .SelectMany(ts => ts.Subject.Grades)
                    .Select(g => g.IsnStudent)
                    .Distinct()
                    .Count(),
                AverageGrade = x.TeacherSubjects
                    .SelectMany(ts => ts.Subject.Grades)
                    .Any()
                    ? x.TeacherSubjects
                        .SelectMany(ts => ts.Subject.Grades)
                        .Average(g => g.Value)
                    : 0
            })
            .FirstOrDefaultAsync(cancellationToken)
                ?? throw new BusinessLogicException(
                    $"Учителя с идентификатором \"{request.IsnTeacher}\" не существует");
    }
}