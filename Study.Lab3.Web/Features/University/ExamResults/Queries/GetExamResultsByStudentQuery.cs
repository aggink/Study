/*using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.ExamResults.DtoModels;
using System.ComponentModel.DataAnnotations;
using Study.Lab3.Logic.Extensions.University;

namespace Study.Lab3.Web.Features.University.ExamResults.Queries;

/// <summary>
/// Получение результатов по студенту
/// </summary>
public sealed class GetExamResultsByStudentQuery : IRequest<ExamResultWithDetailsDto[]>
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnStudent { get; init; }
}

public sealed class GetExamResultsByStudentQueryHandler : IRequestHandler<GetExamResultsByStudentQuery, ExamResultWithDetailsDto[]>
{
    private readonly DataContext _dataContext;

    public GetExamResultsByStudentQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ExamResultWithDetailsDto[]> Handle(GetExamResultsByStudentQuery request, CancellationToken cancellationToken)
    {
        if (!await _dataContext.Students.AnyAsync(x => x.IsnStudent == request.IsnStudent, cancellationToken))
            throw new BusinessLogicException($"Студент с идентификатором \"{request.IsnStudent}\" не существует");

        return await _dataContext.ExamResults
            .AsNoTracking()
            .Where(x => x.Registration.IsnStudent == request.IsnStudent)
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
            .OrderByDescending(x => x.ExamDate)
            .ToArrayAsync(cancellationToken);
    }
}*/