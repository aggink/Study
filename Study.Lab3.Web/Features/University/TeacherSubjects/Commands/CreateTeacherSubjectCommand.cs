using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.TeacherSubjects.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.TeacherSubjects.Commands;
//Команда создания связи преподаватель-предмет
/// <summary>
/// Создание связи учитель-предмет
/// </summary>
public sealed class CreateTeacherSubjectCommand : IRequest
{
    /// <summary>
    /// Данные связи
    /// </summary>
    [Required]
    [FromBody]
    public CreateTeacherSubjectDto TeacherSubject { get; init; }
}

public sealed class CreateTeacherSubjectCommandHandler : IRequestHandler<CreateTeacherSubjectCommand>
{
    private readonly DataContext _dataContext;
    private readonly ITeacherSubjectService _teacherSubjectService;

    public CreateTeacherSubjectCommandHandler(
        DataContext dataContext,
        ITeacherSubjectService teacherSubjectService)
    {
        _dataContext = dataContext;
        _teacherSubjectService = teacherSubjectService;
    }

    public async Task Handle(CreateTeacherSubjectCommand request, CancellationToken cancellationToken)
    {
        var teacherSubject = new TeacherSubject
        {
            IsnTeacher = request.TeacherSubject.IsnTeacher,
            IsnSubject = request.TeacherSubject.IsnSubject
        };

        await _teacherSubjectService.CreateTeacherSubjectValidateAndThrowAsync(
            _dataContext, teacherSubject, cancellationToken);

        await _dataContext.TeacherSubjects.AddAsync(teacherSubject, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}