using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.ExamRegistrations.DtoModels;
using System.ComponentModel.DataAnnotations;
using Study.Lab3.Logic.Extensions.University;

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
            .Include(x => x.Exam)
            .Include(x => x.Student)
            .Include(x => x.Result)
            .Where(x => x.IsnStudent == request.IsnStudent)
            .OrderBy(x => x.Exam.ExamDate)
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
}