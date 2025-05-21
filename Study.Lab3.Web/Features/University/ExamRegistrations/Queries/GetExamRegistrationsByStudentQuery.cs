using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.ExamRegistrations.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.ExamRegistrations.Queries;

/// <summary>
/// Получение регистраций по студенту
/// </summary>
public sealed class GetExamRegistrationsByStudentQuery : IRequest<ExamRegistrationWithDetailsDto[]>
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnStudent { get; init; }
}

public sealed class GetExamRegistrationsByStudentQueryHandler : IRequestHandler<GetExamRegistrationsByStudentQuery, ExamRegistrationWithDetailsDto[]>
{
    private readonly DataContext _dataContext;

    public GetExamRegistrationsByStudentQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ExamRegistrationWithDetailsDto[]> Handle(GetExamRegistrationsByStudentQuery request, CancellationToken cancellationToken)
    {
        if (!await _dataContext.Students.AnyAsync(x => x.IsnStudent == request.IsnStudent, cancellationToken))
            throw new BusinessLogicException($"Студент с идентификатором \"{request.IsnStudent}\" не существует");

        return await _dataContext.ExamRegistrations
            .AsNoTracking()
            .Where(x => x.IsnStudent == request.IsnStudent)
            .Select(x => new ExamRegistrationWithDetailsDto
            {
                IsnExamRegistration = x.IsnExamRegistration,
                IsnExam = x.IsnExam,
                ExamName = x.Exam.Name,
                IsnStudent = x.IsnStudent,
                StudentFullName = $"{x.Student.SurName} {x.Student.Name} {x.Student.PatronymicName}",
                RegistrationDate = x.RegistrationDate,
                ExamDate = x.Exam.ExamDate,
                Status = x.Status,
                HasResult = x.Result != null
            })
            .OrderBy(x => x.ExamDate)
            .ToArrayAsync(cancellationToken);
    }
}