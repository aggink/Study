using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Subjects.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Subjects.Queries;
//Запрос на получение данных по предмету
/// <summary>
/// Получить данные предмета
/// </summary>
public sealed class GetSubjectByIsnQuery : IRequest<SubjectDto>
{
    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnSubject { get; init; }
}

public sealed class GetSubjectByIsnQueryHandler : IRequestHandler<GetSubjectByIsnQuery, SubjectDto>
{
    private readonly DataContext _dataContext;

    public GetSubjectByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<SubjectDto> Handle(GetSubjectByIsnQuery request, CancellationToken cancellationToken)
    {
        var subject = await _dataContext.Subjects.FirstOrDefaultAsync(x => x.IsnSubject == request.IsnSubject, cancellationToken)
            ?? throw new BusinessLogicException($"Предмета с идентификатором \"{request.IsnSubject}\" не существует");

        return new SubjectDto
        {
            IsnSubject = subject.IsnSubject,
            Name = subject.Name
        };
    }
}
