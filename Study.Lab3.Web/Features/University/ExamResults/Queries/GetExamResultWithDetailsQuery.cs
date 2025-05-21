using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.ExamResults.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.ExamResults.Queries;

/// <summary>
/// Получение результата экзамена с детальной информацией
/// </summary>
public sealed class GetExamResultWithDetailsQuery : IRequest<ExamResultWithDetailsDto>
{
    /// <summary>
    /// Идентификатор результата
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnExamResult { get; init; }
}

public sealed class GetExamResultWithDetailsQueryHandler : IRequestHandler<GetExamResultWithDetailsQuery, ExamResultWithDetailsDto>
{
    private readonly DataContext _dataContext;

    public GetExamResultWithDetailsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ExamResultWithDetailsDto> Handle(GetExamResultWithDetailsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.ExamResults
            .AsNoTracking()
            .Where(x => x.IsnExamResult == request.IsnExamResult)
            .Select(x => new ExamResultWithDetailsDto
            {
                IsnExamResult = x.IsnExamResult,
                IsnExamRegistration = x.IsnExamRegistration,
                IsnExam = x.Registration.IsnExam,
                ExamName = x.Registration.Exam.Name,
                IsnStudent = x.Registration.IsnStudent,
                StudentFullName = $"{x.Registration.Student.SurName} {x.Registration.Student.Name} {x.Registration.Student.PatronymicName}",
                ExamDate = x.Registration.Exam.ExamDate,
                MaxScore = x.Registration.Exam.MaxScore,
                PassingScore = x.Registration.Exam.PassingScore,
                Score = x.Score,
                IsPassed = x.IsPassed,
                Comments = x.Comments
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new BusinessLogicException($"Результат с идентификатором \"{request.IsnExamResult}\" не существует");
    }
}