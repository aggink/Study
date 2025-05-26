using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TeacherSubjects.Commands;
//Команда удаления связи преподаватель-предмет
/// <summary>
/// Удаление связи учитель-предмет
/// </summary>
public sealed class DeleteTeacherSubjectCommand : IRequest
{
    /// <summary>
    /// Идентификатор учителя
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnTeacher { get; init; }

    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnSubject { get; init; }
}

public sealed class DeleteTeacherSubjectCommandHandler : IRequestHandler<DeleteTeacherSubjectCommand>
{
    private readonly DataContext _dataContext;
    private readonly ITeacherSubjectService _teacherSubjectService;

    public DeleteTeacherSubjectCommandHandler(
        DataContext dataContext,
        ITeacherSubjectService teacherSubjectService)
    {
        _dataContext = dataContext;
        _teacherSubjectService = teacherSubjectService;
    }

    public async Task Handle(DeleteTeacherSubjectCommand request, CancellationToken cancellationToken)
    {
        var teacherSubject = await _dataContext.TeacherSubjects
            .FirstOrDefaultAsync(x =>
                x.IsnTeacher == request.IsnTeacher &&
                x.IsnSubject == request.IsnSubject,
                cancellationToken)
                    ?? throw new BusinessLogicException("Связь учитель-предмет не существует");

        await _teacherSubjectService.CanDeleteAndThrowAsync(
            _dataContext, teacherSubject, cancellationToken);

        _dataContext.TeacherSubjects.Remove(teacherSubject);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}