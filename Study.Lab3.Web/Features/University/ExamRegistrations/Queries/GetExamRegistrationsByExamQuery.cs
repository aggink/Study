/*using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.ExamRegistrations.DtoModels;
using System.ComponentModel.DataAnnotations;
using Study.Lab3.Logic.Extensions.University;

namespace Study.Lab3.Web.Features.University.ExamRegistrations.Queries;

/// <summary>
/// Получение регистраций по экзамену
/// </summary>
public sealed class GetExamRegistrationsByExamQuery : IRequest<ExamRegistrationWithDetailsDto[]>
{
    /// <summary>
    /// Идентификатор экзамена
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnExam { get; init; }
}

public sealed class GetExamRegistrationsByExamQueryHandler : IRequestHandler<GetExamRegistrationsByExamQuery, ExamRegistrationWithDetailsDto[]>
{
    private readonly DataContext _dataContext;

    public GetExamRegistrationsByExamQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ExamRegistrationWithDetailsDto[]> Handle(GetExamRegistrationsByExamQuery request, CancellationToken cancellationToken)
    {
        if (!await _dataContext.Exams.AnyAsync(x => x.IsnExam == request.IsnExam, cancellationToken))
            throw new BusinessLogicException($"Экзамен с идентификатором \"{request.IsnExam}\" не существует");

        return await _dataContext.ExamRegistrations
            .AsNoTracking()
            .Include(x => x.Exam)
            .Include(x => x.Student)
            .Include(x => x.Result)
            .Where(x => x.IsnExam == request.IsnExam)
            .OrderBy(x => x.Student.SurName)
                .ThenBy(x => x.Student.Name)
                    .ThenBy(x => x.Student.PatronymicName)
            .Select(x => new ExamRegistrationWithDetailsDto
            {
                IsnExamRegistration = x.IsnExamRegistration,
                IsnExam = x.IsnExam,
                ExamName = x.Exam.Name,
                IsnStudent = x.IsnStudent,
                StudentFullName = x.Student.GetFio(),
                RegistrationDate = x.RegistrationDate,
                ExamDate = x.Exam.ExamDate,
                Status = x.Status,
                HasResult = x.Result != null
            })
            .ToArrayAsync(cancellationToken);
    }
}*/