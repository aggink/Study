using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.ExamRegistrations.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.ExamRegistrations.Queries;

/// <summary>
/// Получение регистрации на экзамен с детальной информацией
/// </summary>
public sealed class GetExamRegistrationWithDetailsQuery : IRequest<ExamRegistrationWithDetailsDto>
{
    /// <summary>
    /// Идентификатор регистрации
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnExamRegistration { get; init; }
}

public sealed class GetExamRegistrationWithDetailsQueryHandler : IRequestHandler<GetExamRegistrationWithDetailsQuery, ExamRegistrationWithDetailsDto>
{
    private readonly DataContext _dataContext;

    public GetExamRegistrationWithDetailsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ExamRegistrationWithDetailsDto> Handle(GetExamRegistrationWithDetailsQuery request, CancellationToken cancellationToken)
    {
        var examRegistration = await _dataContext.ExamRegistrations
            .AsNoTracking()
            .Include(x => x.Exam)
            .Include(x => x.Student)
            .Include(x => x.Result)
            .FirstOrDefaultAsync(x => x.IsnExamRegistration == request.IsnExamRegistration, cancellationToken);

        if (examRegistration == null)
        {
            throw new BusinessLogicException($"Регистрация с идентификатором \"{request.IsnExamRegistration}\" не существует");
        }

        return new ExamRegistrationWithDetailsDto
        {
            IsnExamRegistration = examRegistration.IsnExamRegistration,
            IsnExam = examRegistration.IsnExam,
            ExamName = examRegistration.Exam.Name,
            IsnStudent = examRegistration.IsnStudent,
            StudentFullName = $"{examRegistration.Student.SurName} {examRegistration.Student.Name} {examRegistration.Student.PatronymicName}",
            RegistrationDate = examRegistration.RegistrationDate,
            ExamDate = examRegistration.Exam.ExamDate,
            Status = examRegistration.Status,
            HasResult = examRegistration.Result != null
        };
    }
}