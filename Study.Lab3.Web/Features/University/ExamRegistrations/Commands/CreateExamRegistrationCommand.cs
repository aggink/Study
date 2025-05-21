using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.ExamRegistrations.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.ExamRegistrations.Commands;

/// <summary>
/// Создание регистрации на экзамен
/// </summary>
public sealed class CreateExamRegistrationCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные регистрации
    /// </summary>
    [Required]
    [FromBody]
    public CreateExamRegistrationDto Registration { get; init; }
}

public sealed class CreateExamRegistrationCommandHandler : IRequestHandler<CreateExamRegistrationCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IExamRegistrationService _registrationService;

    public CreateExamRegistrationCommandHandler(
        DataContext dataContext,
        IExamRegistrationService registrationService)
    {
        _dataContext = dataContext;
        _registrationService = registrationService;
    }

    public async Task<Guid> Handle(CreateExamRegistrationCommand request, CancellationToken cancellationToken)
    {
        var registration = new ExamRegistration
        {
            IsnExamRegistration = Guid.NewGuid(),
            IsnExam = request.Registration.IsnExam,
            IsnStudent = request.Registration.IsnStudent,
            RegistrationDate = request.Registration.RegistrationDate,
            Status = request.Registration.Status
        };

        await _registrationService.CreateOrUpdateRegistrationValidateAndThrowAsync(
            _dataContext, registration, cancellationToken);

        await _dataContext.ExamRegistrations.AddAsync(registration, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return registration.IsnExamRegistration;
    }
}