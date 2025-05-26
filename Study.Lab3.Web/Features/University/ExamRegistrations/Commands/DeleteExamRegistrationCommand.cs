/*using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.ExamRegistrations.Commands;

/// <summary>
/// Удаление регистрации на экзамен
/// </summary>
public sealed class DeleteExamRegistrationCommand : IRequest
{
    /// <summary>
    /// Идентификатор регистрации
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnExamRegistration { get; init; }
}

public sealed class DeleteExamRegistrationCommandHandler : IRequestHandler<DeleteExamRegistrationCommand>
{
    private readonly DataContext _dataContext;
    private readonly IExamRegistrationService _registrationService;

    public DeleteExamRegistrationCommandHandler(
        DataContext dataContext,
        IExamRegistrationService registrationService)
    {
        _dataContext = dataContext;
        _registrationService = registrationService;
    }

    public async Task Handle(DeleteExamRegistrationCommand request, CancellationToken cancellationToken)
    {
        var registration = await _dataContext.ExamRegistrations
                               .FirstOrDefaultAsync(x => x.IsnExamRegistration == request.IsnExamRegistration, cancellationToken)
                           ?? throw new BusinessLogicException($"Регистрация с идентификатором \"{request.IsnExamRegistration}\" не существует");

        await _registrationService.CanDeleteAndThrowAsync(
            _dataContext, registration, cancellationToken);

        _dataContext.ExamRegistrations.Remove(registration);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}*/