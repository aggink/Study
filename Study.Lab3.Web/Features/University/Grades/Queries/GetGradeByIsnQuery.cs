using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Grades.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Grades.Queries;
//Запрос получения оценки студента
/// <summary>
/// Получить оценку по идентификатору
/// </summary>
public sealed class GetGradeByIsnQuery : IRequest<GradeDto>
{
    /// <summary>
    /// Идентификатор оценки
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnGrade { get; init; }
}

public sealed class GetGradeByIsnQueryHandler : IRequestHandler<GetGradeByIsnQuery, GradeDto>
{
    private readonly DataContext _dataContext;

    public GetGradeByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<GradeDto> Handle(GetGradeByIsnQuery request, CancellationToken cancellationToken)
    {
        var grade = await _dataContext.Grades
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnGrade == request.IsnGrade, cancellationToken)
                ?? throw new BusinessLogicException($"Оценки с идентификатором \"{request.IsnGrade}\" не существует");

        return new GradeDto
        {
            IsnGrade = grade.IsnGrade,
            IsnStudent = grade.IsnStudent,
            IsnSubject = grade.IsnSubject,
            Value = grade.Value,
            GradeDate = grade.GradeDate
        };
    }
}