using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Exams.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Exams.Queries;

/// <summary>
/// Получение экзаменов по предмету
/// </summary>
public sealed class GetExamsBySubjectQuery : IRequest<ExamDto[]>
{
    /// <summary>
    /// Идентификатор предмета
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnSubject { get; init; }
}

public sealed class GetExamsBySubjectQueryHandler : IRequestHandler<GetExamsBySubjectQuery, ExamDto[]>
{
    private readonly DataContext _dataContext;

    public GetExamsBySubjectQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ExamDto[]> Handle(GetExamsBySubjectQuery request, CancellationToken cancellationToken)
    {
        if (!await _dataContext.Subjects.AnyAsync(x => x.IsnSubject == request.IsnSubject, cancellationToken))
            throw new BusinessLogicException($"Предмет с идентификатором \"{request.IsnSubject}\" не существует");

        return await _dataContext.Exams
            .AsNoTracking()
            .Where(x => x.IsnSubject == request.IsnSubject)
            .Select(x => new ExamDto
            {
                IsnExam = x.IsnExam,
                IsnSubject = x.IsnSubject,
                Name = x.Name,
                Description = x.Description,
                ExamDate = x.ExamDate,
                Duration = x.Duration,
                MaxScore = x.MaxScore,
                PassingScore = x.PassingScore
            })
            .OrderBy(x => x.ExamDate)
            .ToArrayAsync(cancellationToken);
    }
}