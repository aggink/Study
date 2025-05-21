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
        return await _dataContext.ExamRegistrations
            .AsNoTracking()
            .Where(x => x.IsnExamRegistration == request.IsnExamRegistration)
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
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new BusinessLogicException($"Регистрация с идентификатором \"{request.IsnExamRegistration}\" не существует");
    }
}