using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Grades.Commands;
//Удаление команды оценки студента
/// <summary>
/// Удаление оценки
/// </summary>
public sealed class DeleteGradeCommand : IRequest
{
    /// <summary>
    /// Идентификатор оценки
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnGrade { get; init; }
}

public sealed class DeleteGradeCommandHandler : IRequestHandler<DeleteGradeCommand>
{
    private readonly DataContext _dataContext;
    private readonly IGradeService _gradeService;

    public DeleteGradeCommandHandler(
        DataContext dataContext,
        IGradeService gradeService)
    {
        _dataContext = dataContext;
        _gradeService = gradeService;
    }

    public async Task Handle(DeleteGradeCommand request, CancellationToken cancellationToken)
    {
        var grade = await _dataContext.Grades
            .Include(x => x.Subject)
            .ThenInclude(x => x.TeacherSubjects)
            .FirstOrDefaultAsync(x => x.IsnGrade == request.IsnGrade, cancellationToken)
                ?? throw new BusinessLogicException($"Оценки с идентификатором \"{request.IsnGrade}\" не существует");

        var teacherSubject = grade.Subject.TeacherSubjects.FirstOrDefault()
            ?? throw new BusinessLogicException($"Предмет с идентификатором \"{grade.IsnSubject}\" не закреплен ни за одним преподавателем");

        await _gradeService.CanDeleteAndThrowAsync(
            _dataContext, grade, teacherSubject.IsnTeacher, cancellationToken);

        _dataContext.Grades.Remove(grade);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}