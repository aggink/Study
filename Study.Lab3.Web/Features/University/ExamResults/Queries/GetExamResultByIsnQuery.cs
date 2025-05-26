/*using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.ExamResults.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.ExamResults.Queries;

/// <summary>
/// Получение результата экзамена по идентификатору
/// </summary>
public sealed class GetExamResultByIsnQuery : IRequest<ExamResultDto>
{
    /// <summary>
    /// Идентификатор результата
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnExamResult { get; init; }
}

public sealed class GetExamResultByIsnQueryHandler : IRequestHandler<GetExamResultByIsnQuery, ExamResultDto>
{
    private readonly DataContext _dataContext;

    public GetExamResultByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ExamResultDto> Handle(GetExamResultByIsnQuery request, CancellationToken cancellationToken)
    {
        var result = await _dataContext.ExamResults
                         .AsNoTracking()
                         .FirstOrDefaultAsync(x => x.IsnExamResult == request.IsnExamResult, cancellationToken)
                     ?? throw new BusinessLogicException($"Результат с идентификатором \"{request.IsnExamResult}\" не существует");

        return new ExamResultDto
        {
            IsnExamResult = result.IsnExamResult,
            IsnExamRegistration = result.IsnExamRegistration,
            Score = result.Score,
            IsPassed = result.IsPassed,
            Comments = result.Comments
        };
    }
}*/