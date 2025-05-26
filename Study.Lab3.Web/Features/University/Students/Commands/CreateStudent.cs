using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.Students.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Students.Commands;
//Создание студента
/// <summary>
/// Создание студента
/// </summary>
public sealed class CreateStudentCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные студента
    /// </summary>
    [Required]
    [FromBody]
    public CreateStudentDto Student { get; init; }
}

public sealed class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Guid>
{
    private readonly DataContext _dataContext;

    public CreateStudentCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var group = await _dataContext.Groups.FirstOrDefaultAsync(x => x.IsnGroup == request.Student.IsnGroup, cancellationToken)
           ?? throw new BusinessLogicException($"Группы с идентификатором \"{request.Student.IsnGroup}\" не существует");

        var student = new Student
        {
            IsnStudent = Guid.NewGuid(),
            IsnGroup = request.Student.IsnGroup,
            SurName = request.Student.SurName,
            Name = request.Student.Name,
            PatronymicName = request.Student.PatronymicName,
            Sex = request.Student.Sex,
            Age = request.Student.Age,
            Group = group
        };

        await _dataContext.Students.AddAsync(student, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return student.IsnStudent;
    }
}
