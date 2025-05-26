using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.Teachers.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Teachers.Commands;
//Команда создания преподавателя
/// <summary>
/// Создание учителя
/// </summary>
public sealed class CreateTeacherCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные учителя
    /// </summary>
    [Required]
    [FromBody]
    public CreateTeacherDto Teacher { get; init; }
}

public sealed class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ITeacherService _teacherService;

    public CreateTeacherCommandHandler(
        DataContext dataContext,
        ITeacherService teacherService)
    {
        _dataContext = dataContext;
        _teacherService = teacherService;
    }

    public async Task<Guid> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
    {
        var teacher = new Teacher
        {
            IsnTeacher = Guid.NewGuid(),
            SurName = request.Teacher.SurName,
            Name = request.Teacher.Name,
            PatronymicName = request.Teacher.PatronymicName,
            Sex = request.Teacher.Sex
        };

        await _teacherService.CreateOrUpdateTeacherValidateAndThrowAsync(
            _dataContext, teacher, cancellationToken);

        await _dataContext.Teachers.AddAsync(teacher);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return teacher.IsnTeacher;
    }
}