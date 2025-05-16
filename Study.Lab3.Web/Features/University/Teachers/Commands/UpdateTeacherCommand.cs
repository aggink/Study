using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Teachers.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Teachers.Commands;

/// <summary>
/// Редактирование данных учителя
/// </summary>
public sealed class UpdateTeacherCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные учителя
    /// </summary>
    [Required]
    [FromBody]
    public UpdateTeacherDto Teacher { get; init; }
}

public sealed class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ITeacherService _teacherService;

    public UpdateTeacherCommandHandler(
        DataContext dataContext,
        ITeacherService teacherService)
    {
        _dataContext = dataContext;
        _teacherService = teacherService;
    }

    public async Task<Guid> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
    {
        var teacher = await _dataContext.Teachers.FirstOrDefaultAsync(x => x.IsnTeacher == request.Teacher.IsnTeacher, cancellationToken)
            ?? throw new BusinessLogicException($"Учителя с идентификатором \"{request.Teacher.IsnTeacher}\" не существует");

        teacher.SurName = request.Teacher.SurName;
        teacher.Name = request.Teacher.Name;
        teacher.PatronymicName = request.Teacher.PatronymicName;
        teacher.Sex = request.Teacher.Sex;

        await _teacherService.CreateOrUpdateTeacherValidateAndThrowAsync(
            _dataContext, teacher, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return teacher.IsnTeacher;
    }
}