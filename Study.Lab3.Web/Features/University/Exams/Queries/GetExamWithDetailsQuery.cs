/*using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Exams.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Exams.Queries;

/// <summary>
/// Получение экзамена с детальной информацией
/// </summary>
public sealed class GetExamWithDetailsQuery : IRequest<ExamWithDetailsDto>
{
    /// <summary>
    /// Идентификатор экзамена
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnExam { get; init; }
}

public sealed class GetExamWithDetailsQueryHandler : IRequestHandler<GetExamWithDetailsQuery, ExamWithDetailsDto>
{
    private readonly DataContext _dataContext;

    public GetExamWithDetailsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ExamWithDetailsDto> Handle(GetExamWithDetailsQuery request, CancellationToken cancellationToken)
    {
        var exam = await _dataContext.Exams
                       .AsNoTracking()
                       .Include(x => x.Subject)
                       .Include(x => x.Registrations)
                       .FirstOrDefaultAsync(x => x.IsnExam == request.IsnExam, cancellationToken)
                   ?? throw new BusinessLogicException($"Экзамен с идентификатором \"{request.IsnExam}\" не существует");

        return new ExamWithDetailsDto
        {
            IsnExam = exam.IsnExam,
            IsnSubject = exam.IsnSubject,
            SubjectName = exam.Subject.Name,
            Name = exam.Name,
            Description = exam.Description,
            ExamDate = exam.ExamDate,
            Duration = exam.Duration,
            MaxScore = exam.MaxScore,
            PassingScore = exam.PassingScore,
            RegisteredStudentsCount = exam.Registrations.Count
        };
    }
}*/