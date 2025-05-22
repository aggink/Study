using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.ExamResults.DtoModels;
using System.ComponentModel.DataAnnotations;
using Study.Lab3.Logic.Extensions.University;

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
        var examResult = await _dataContext.ExamResults
                             .AsNoTracking()
                             .Include(x => x.Registration)
                             .Include(x => x.Registration.Exam)
                             .Include(x => x.Registration.Student)
                             .FirstOrDefaultAsync(x => x.IsnExamResult == request.IsnExamResult, cancellationToken)
                         ?? throw new BusinessLogicException($"Результат с идентификатором \"{request.IsnExamResult}\" не существует");

        return new ExamResultWithDetailsDto
        {
            IsnExamResult = examResult.IsnExamResult,
            IsnExamRegistration = examResult.IsnExamRegistration,
            IsnExam = examResult.Registration.IsnExam,
            ExamName = examResult.Registration.Exam.Name,
            IsnStudent = examResult.Registration.IsnStudent,
            StudentFullName = examResult.Registration.Student.GetFio(),
            ExamDate = examResult.Registration.Exam.ExamDate,
            MaxScore = examResult.Registration.Exam.MaxScore,
            PassingScore = examResult.Registration.Exam.PassingScore,
            Score = examResult.Score,
            IsPassed = examResult.IsPassed,
            Comments = examResult.Comments
        };
    }
}