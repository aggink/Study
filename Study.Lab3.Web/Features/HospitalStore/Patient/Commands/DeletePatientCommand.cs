using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.HospitalStore;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.HospitalStore.Patient.Commands;

/// <summary>
/// Удаление пациента
/// </summary>
public sealed class DeletePatientCommand : IRequest
{
    /// <summary>
    /// Идентификатор пациента
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnPatient { get; init; }
}

public sealed class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand>
{
    private readonly DataContext _dataContext;
    private readonly IPatientService _patientService;

    public DeletePatientCommandHandler(
        DataContext dataContext,
        IPatientService patientService)
    {
        _dataContext = dataContext;
        _patientService = patientService;
    }

    public async Task Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _dataContext.Patients
            .FirstOrDefaultAsync(x => x.IsnPatient == request.IsnPatient, cancellationToken)
                ?? throw new BusinessLogicException($"Пациент с идентификатором \"{request.IsnPatient}\" не существует");

        await _patientService.CanDeleteAndThrowAsync(
            _dataContext, patient, cancellationToken);

        _dataContext.Patients.Remove(patient);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}