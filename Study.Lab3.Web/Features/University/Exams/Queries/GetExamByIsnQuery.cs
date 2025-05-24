using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Exams.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Exams.Queries;

/// <summary>
/// Получение экзамена по идентификатору
/// </summary>
public sealed class GetExamByIsnQuery : IRequest<ExamDto>
{
    /// <summary>
    /// Идентификатор экзамена
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnExam { get; init; }
}

public sealed class GetExamByIsnQueryHandler : IRequestHandler<GetExamByIsnQuery, ExamDto>
{
    private readonly DataContext _dataContext;

    public GetExamByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ExamDto> Handle(GetExamByIsnQuery request, CancellationToken cancellationToken)
    {
        var exam = await _dataContext.Exams
                       .AsNoTracking()
                       .FirstOrDefaultAsync(x => x.IsnExam == request.IsnExam, cancellationToken)
                   ?? throw new BusinessLogicException($"Экзамен с идентификатором \"{request.IsnExam}\" не существует");

        return new ExamDto
        {
            IsnExam = exam.IsnExam,
            IsnSubject = exam.IsnSubject,
            Name = exam.Name,
            Description = exam.Description,
            ExamDate = exam.ExamDate,
            Duration = exam.Duration,
            MaxScore = exam.MaxScore,
            PassingScore = exam.PassingScore
        };
    }
}