using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Students.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Students.Queries;

/// <summary>
/// Получить данные студента
/// </summary>
public sealed class GetStudentByIsnQuery : IRequest<StudentDto>
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnStudent { get; init; }
}

public sealed class GetStudentByIsnQueryHandler : IRequestHandler<GetStudentByIsnQuery, StudentDto>
{
    private readonly DataContext _dataContext;

    public GetStudentByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<StudentDto> Handle(GetStudentByIsnQuery request, CancellationToken cancellationToken)
    {
        var student = await _dataContext.Students
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnStudent == request.IsnStudent)
                ?? throw new BusinessLogicException($"Студента с идентификатором \"{request.IsnStudent}\" не существует");

        return new StudentDto
        {
            IsnStudent = student.IsnStudent,
            IsnGroup = student.IsnGroup,
            SurName = student.SurName,
            Name = student.Name,
            PatronymicName = student.PatronymicName,
            Sex = student.Sex,
            Age = student.Age
        };
    }
}
