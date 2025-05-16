using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Teachers.Commands;

/// <summary>
/// Удаление учителя
/// </summary>
public sealed class DeleteTeacherCommand : IRequest
{
    /// <summary>
    /// Идентификатор учителя
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnTeacher { get; init; }
}

public sealed class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand>
{
    private readonly DataContext _dataContext;
    private readonly ITeacherService _teacherService;

    public DeleteTeacherCommandHandler(
        DataContext dataContext,
        ITeacherService teacherService)
    {
        _dataContext = dataContext;
        _teacherService = teacherService;
    }

    public async Task Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
    {
        var teacher = await _dataContext.Teachers.FirstOrDefaultAsync(x => x.IsnTeacher == request.IsnTeacher)
            ?? throw new BusinessLogicException($"Учителя с идентификатором \"{request.IsnTeacher}\" не существует");

        await _teacherService.CanDeleteAndThrowAsync(
            _dataContext, teacher, cancellationToken);

        _dataContext.Teachers.Remove(teacher);
        await _dataContext.SaveChangesAsync(cancellationToken);
        return;
    }
}