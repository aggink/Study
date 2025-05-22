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
/// Получение результатов по экзамену
/// </summary>
public sealed class GetExamResultsByExamQuery : IRequest<ExamResultWithDetailsDto[]>
{
    /// <summary>
    /// Идентификатор экзамена
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnExam { get; init; }
}

public sealed class GetExamResultsByExamQueryHandler : IRequestHandler<GetExamResultsByExamQuery, ExamResultWithDetailsDto[]>
{
    private readonly DataContext _dataContext;

    public GetExamResultsByExamQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ExamResultWithDetailsDto[]> Handle(GetExamResultsByExamQuery request, CancellationToken cancellationToken)
    {
        if (!await _dataContext.Exams.AnyAsync(x => x.IsnExam == request.IsnExam, cancellationToken))
            throw new BusinessLogicException($"Экзамен с идентификатором \"{request.IsnExam}\" не существует");

        return await _dataContext.ExamResults
            .AsNoTracking()
            .Where(x => x.Registration.IsnExam == request.IsnExam)
            .Select(x => new ExamResultWithDetailsDto
            {
                IsnExamResult = x.IsnExamResult,
                IsnExamRegistration = x.IsnExamRegistration,
                IsnExam = x.Registration.IsnExam,
                ExamName = x.Registration.Exam.Name,
                IsnStudent = x.Registration.IsnStudent,
                StudentFullName = x.Registration.Student.GetFio(),
                ExamDate = x.Registration.Exam.ExamDate,
                MaxScore = x.Registration.Exam.MaxScore,
                PassingScore = x.Registration.Exam.PassingScore,
                Score = x.Score,
                IsPassed = x.IsPassed,
                Comments = x.Comments
            })
            .OrderByDescending(x => x.Score)
            .ToArrayAsync(cancellationToken);
    }
}