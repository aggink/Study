using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Students.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Students.Commands;

/// <summary>
/// Редактирование данных студента
/// </summary>
public sealed class UpdateStudentCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные студента
    /// </summary>
    [Required]
    [FromBody]
    public UpdateStudentDto Student { get; init; }
}

public sealed class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Guid>
{
    private readonly DataContext _dataContext;

    public UpdateStudentCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _dataContext.Students.FirstOrDefaultAsync(x => x.IsnStudent == request.Student.IsnStudent)
            ?? throw new BusinessLogicException($"Студента с идентификатором \"{request.Student.IsnStudent}\" не существует");

        if (student.IsnGroup != request.Student.IsnGroup && !await _dataContext.Groups.AnyAsync(x => x.IsnGroup == request.Student.IsnGroup, cancellationToken))
            throw new BusinessLogicException($"Группы с идентификатором \"{request.Student.IsnGroup}\" не существует");

        student.IsnGroup = request.Student.IsnGroup;
        student.SurName = request.Student.SurName;
        student.Name = request.Student.Name;
        student.PatronymicName = request.Student.PatronymicName;
        student.Sex = request.Student.Sex;
        student.Age = request.Student.Age;

        await _dataContext.SaveChangesAsync(cancellationToken);
        return student.IsnStudent;
    }
}
