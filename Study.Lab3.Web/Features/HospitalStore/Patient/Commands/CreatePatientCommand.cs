using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.HospitalStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.HospitalStore.Patient.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.HospitalStore.Patient.Commands;

/// <summary>
/// Создание пациента
/// </summary>
public sealed class CreatePatientCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные пациента
    /// </summary>
    [Required]
    [FromBody]
    public CreatePatientDto Patient { get; init; }
}

public sealed class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPatientService _patientService;

    public CreatePatientCommandHandler(
        DataContext dataContext,
        IPatientService patientService)
    {
        _dataContext = dataContext;
        _patientService = patientService;
    }

    public async Task<Guid> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = new Storage.Models.HospitalStore.Patient
        {
            IsnPatient = Guid.NewGuid(),
            FullName = request.Patient.FullName,
            MedicalCardId = request.Patient.MedicalCardId,
            Phone = request.Patient.Phone
        };

        await _patientService.CreateOrUpdatePatientValidateAndThrowAsync(
            _dataContext, patient, cancellationToken);

        await _dataContext.Patients.AddAsync(patient, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return patient.IsnPatient;
    }
}
