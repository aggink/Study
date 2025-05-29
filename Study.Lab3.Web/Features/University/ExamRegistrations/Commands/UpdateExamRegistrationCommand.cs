using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.ExamRegistrations.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.ExamRegistrations.Commands;

/// <summary>
/// Обновление регистрации на экзамен
/// </summary>
public sealed class UpdateExamRegistrationCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные регистрации
    /// </summary>
    [Required]
    [FromBody]
    public UpdateExamRegistrationDto Registration { get; init; }
}

public sealed class UpdateExamRegistrationCommandHandler : IRequestHandler<UpdateExamRegistrationCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IExamRegistrationService _registrationService;

    public UpdateExamRegistrationCommandHandler(
        DataContext dataContext,
        IExamRegistrationService registrationService)
    {
        _dataContext = dataContext;
        _registrationService = registrationService;
    }

    public async Task<Guid> Handle(UpdateExamRegistrationCommand request, CancellationToken cancellationToken)
    {
        var registration = await _dataContext.ExamRegistrations
                               .FirstOrDefaultAsync(x => x.IsnExamRegistration == request.Registration.IsnExamRegistration, cancellationToken)
                           ?? throw new BusinessLogicException($"Регистрация с идентификатором \"{request.Registration.IsnExamRegistration}\" не существует");

        registration.Status = request.Registration.Status;

        await _registrationService.CreateOrUpdateRegistrationValidateAndThrowAsync(
            _dataContext, registration, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return registration.IsnExamRegistration;
    }
}