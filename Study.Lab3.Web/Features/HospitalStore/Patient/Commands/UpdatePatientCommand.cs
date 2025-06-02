using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.HospitalStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.HospitalStore.Patient.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.HospitalStore.Patient.Commands;

/// <summary>
/// Редактирование пациента
/// </summary>
public sealed class UpdatePatientCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные пациента
    /// </summary>
    [Required]
    [FromBody]
    public UpdatePatientDto Patient { get; init; }
}

public sealed class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPatientService _patientService;

    public UpdatePatientCommandHandler(
        DataContext dataContext,
        IPatientService patientService)
    {
        _dataContext = dataContext;
        _patientService = patientService;
    }

    public async Task<Guid> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _dataContext.Patients
            .FirstOrDefaultAsync(x => x.IsnPatient == request.Patient.IsnPatient, cancellationToken)
                ?? throw new BusinessLogicException($"Пациент с идентификатором \"{request.Patient.IsnPatient}\" не найден");

        patient.FullName = request.Patient.FullName;
        patient.MedicalCardId = request.Patient.MedicalCardId;
        patient.Phone = request.Patient.Phone;

        await _patientService.CreateOrUpdatePatientValidateAndThrowAsync(
            _dataContext, patient, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return patient.IsnPatient;
    }
}