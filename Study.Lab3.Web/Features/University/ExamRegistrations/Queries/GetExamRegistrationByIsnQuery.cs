/*using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.ExamRegistrations.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.ExamRegistrations.Queries;

/// <summary>
/// Получение регистрации на экзамен по идентификатору
/// </summary>
public sealed class GetExamRegistrationByIsnQuery : IRequest<ExamRegistrationDto>
{
    /// <summary>
    /// Идентификатор регистрации
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnExamRegistration { get; init; }
}

public sealed class GetExamRegistrationByIsnQueryHandler : IRequestHandler<GetExamRegistrationByIsnQuery, ExamRegistrationDto>
{
    private readonly DataContext _dataContext;

    public GetExamRegistrationByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ExamRegistrationDto> Handle(GetExamRegistrationByIsnQuery request, CancellationToken cancellationToken)
    {
        var registration = await _dataContext.ExamRegistrations
                               .AsNoTracking()
                               .FirstOrDefaultAsync(x => x.IsnExamRegistration == request.IsnExamRegistration, cancellationToken)
                           ?? throw new BusinessLogicException($"Регистрация с идентификатором \"{request.IsnExamRegistration}\" не существует");

        return new ExamRegistrationDto
        {
            IsnExamRegistration = registration.IsnExamRegistration,
            IsnExam = registration.IsnExam,
            IsnStudent = registration.IsnStudent,
            RegistrationDate = registration.RegistrationDate,
            Status = registration.Status
        };
    }
}*/