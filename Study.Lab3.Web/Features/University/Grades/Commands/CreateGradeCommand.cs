using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.Grades.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Grades.Commands;
//Команда создания оценки студента
/// <summary>
/// Создание оценки
/// </summary>
public sealed class CreateGradeCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные оценки
    /// </summary>
    [Required]
    [FromBody]
    public CreateGradeDto Grade { get; init; }
}

public sealed class CreateGradeCommandHandler : IRequestHandler<CreateGradeCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IGradeService _gradeService;

    public CreateGradeCommandHandler(
        DataContext dataContext,
        IGradeService gradeService)
    {
        _dataContext = dataContext;
        _gradeService = gradeService;
    }

    public async Task<Guid> Handle(CreateGradeCommand request, CancellationToken cancellationToken)
    {
        var teacherSubject = await _dataContext.TeacherSubjects
            .FirstOrDefaultAsync(x => x.IsnSubject == request.Grade.IsnSubject, cancellationToken)
            ?? throw new BusinessLogicException($"Предмет с идентификатором \"{request.Grade.IsnSubject}\" не закреплен ни за одним преподавателем");

        var grade = new Grade
        {
            IsnGrade = Guid.NewGuid(),
            IsnStudent = request.Grade.IsnStudent,
            IsnSubject = request.Grade.IsnSubject,
            Value = request.Grade.Value,
            GradeDate = request.Grade.GradeDate
        };

        await _gradeService.CreateOrUpdateGradeValidateAndThrowAsync(
            _dataContext, grade, teacherSubject.IsnTeacher, cancellationToken);

        await _dataContext.Grades.AddAsync(grade, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return grade.IsnGrade;
    }
}