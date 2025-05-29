using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Teachers.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Teachers.Queries;

/// <summary>
/// Получить учителя по идентификатору
/// </summary>
public sealed class GetTeacherByIsnQuery : IRequest<TeacherDto>
{
    /// <summary>
    /// Идентификатор учителя
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnTeacher { get; init; }
}

public sealed class GetTeacherByIsnQueryHandler : IRequestHandler<GetTeacherByIsnQuery, TeacherDto>
{
    private readonly DataContext _dataContext;

    public GetTeacherByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<TeacherDto> Handle(GetTeacherByIsnQuery request, CancellationToken cancellationToken)
    {
        var teacher = await _dataContext.Teachers
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnTeacher == request.IsnTeacher, cancellationToken)
                ?? throw new BusinessLogicException($"Учителя с идентификатором \"{request.IsnTeacher}\" не существует");

        return new TeacherDto
        {
            IsnTeacher = teacher.IsnTeacher,
            Name = teacher.Name,
            SurName = teacher.SurName,
            PatronymicName = teacher.PatronymicName,
            Sex = teacher.Sex
        };
    }
}