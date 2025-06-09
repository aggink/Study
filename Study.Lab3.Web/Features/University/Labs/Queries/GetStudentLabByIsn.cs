using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Labs.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Labs.Queries;

/// <summary>
/// Получить группу по идентификатору
/// </summary>
public sealed class GetStudentLabByIsnQuery : IRequest<StudentLabDto>
{
    /// <summary>
    /// Идентификатор группы
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnStudentLab { get; init; }
}

public sealed class GetStudentLabByIsnQueryHandler : IRequestHandler<GetStudentLabByIsnQuery, StudentLabDto>
{
    private readonly DataContext _dataContext;

    public GetStudentLabByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<StudentLabDto> Handle(GetStudentLabByIsnQuery request, CancellationToken cancellationToken)
    {
        var studentlab = await _dataContext.StudentLab
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnStudentLab == request.IsnStudentLab, cancellationToken)
                ?? throw new BusinessLogicException($"Группы с идентификатором \"{request.IsnStudentLab}\" не существует");

        return new StudentLabDto
        {
            IsnLab = studentlab.IsnLab,
            IsnStudent = studentlab.IsnStudent,
            IsnStudentLab = studentlab.IsnStudentLab,
            Value = studentlab.Value
        };
    }
}
