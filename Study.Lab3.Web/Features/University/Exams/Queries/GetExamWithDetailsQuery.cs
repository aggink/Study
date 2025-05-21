using CoreLib.Common.Extensions;
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
        return await _dataContext.Exams
                   .AsNoTracking()
                   .Where(x => x.IsnExam == request.IsnExam)
                   .Select(x => new ExamWithDetailsDto
                   {
                       IsnExam = x.IsnExam,
                       IsnSubject = x.IsnSubject,
                       SubjectName = x.Subject.Name,
                       Name = x.Name,
                       Description = x.Description,
                       ExamDate = x.ExamDate,
                       Duration = x.Duration,
                       MaxScore = x.MaxScore,
                       PassingScore = x.PassingScore,
                       RegisteredStudentsCount = x.Registrations.Count
                   })
                   .FirstOrDefaultAsync(cancellationToken)
               ?? throw new BusinessLogicException($"Экзамен с идентификатором \"{request.IsnExam}\" не существует");
    }
}