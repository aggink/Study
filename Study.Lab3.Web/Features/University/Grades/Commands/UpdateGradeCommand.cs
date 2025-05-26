using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Grades.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Grades.Commands;
//Обновление команды оценки студента
/// <summary>
/// Редактирование оценки
/// </summary>
public sealed class UpdateGradeCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные оценки
    /// </summary>
    [Required]
    [FromBody]
    public UpdateGradeDto Grade { get; init; }
}

public sealed class UpdateGradeCommandHandler : IRequestHandler<UpdateGradeCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IGradeService _gradeService;

    public UpdateGradeCommandHandler(
        DataContext dataContext,
        IGradeService gradeService)
    {
        _dataContext = dataContext;
        _gradeService = gradeService;
    }

    public async Task<Guid> Handle(UpdateGradeCommand request, CancellationToken cancellationToken)
    {
        var grade = await _dataContext.Grades
            .Include(x => x.Subject)
            .ThenInclude(x => x.TeacherSubjects)
            .FirstOrDefaultAsync(x => x.IsnGrade == request.Grade.IsnGrade, cancellationToken)
                ?? throw new BusinessLogicException($"Оценки с идентификатором \"{request.Grade.IsnGrade}\" не существует");

        var teacherSubject = grade.Subject.TeacherSubjects.FirstOrDefault()
            ?? throw new BusinessLogicException($"Предмет с идентификатором \"{grade.IsnSubject}\" не закреплен ни за одним преподавателем");

        grade.Value = request.Grade.Value;
        grade.GradeDate = request.Grade.GradeDate;

        await _gradeService.CreateOrUpdateGradeValidateAndThrowAsync(
            _dataContext, grade, teacherSubject.IsnTeacher, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return grade.IsnGrade;
    }
}