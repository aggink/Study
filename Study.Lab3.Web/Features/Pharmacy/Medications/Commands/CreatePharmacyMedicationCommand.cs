using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Pharmacy;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Pharmacy;
using Study.Lab3.Web.Features.Pharmacy.Medications.DtoModels;

namespace Study.Lab3.Web.Features.Pharmacy.Medications.Commands;

/// <summary>
/// Создание медикамента
/// </summary>
public sealed class CreatePharmacyMedicationCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные медикамента
    /// </summary>
    [Required]
    [FromBody]
    public CreatePharmacyMedicationDto Medication { get; init; }
}

public sealed class CreatePharmacyMedicationCommandHandler : IRequestHandler<CreatePharmacyMedicationCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPharmacyMedicationService _medicationService;

    public CreatePharmacyMedicationCommandHandler(
        DataContext dataContext,
        IPharmacyMedicationService medicationService)
    {
        _dataContext = dataContext;
        _medicationService = medicationService;
    }

    public async Task<Guid> Handle(CreatePharmacyMedicationCommand request, CancellationToken cancellationToken)
    {
        var medication = new PharmacyMedication
        {
            IsnMedication = Guid.NewGuid(),
            Name = request.Medication.Name,
            Description = request.Medication.Description,
            Manufacturer = request.Medication.Manufacturer,
            Price = request.Medication.Price,
            QuantityInStock = request.Medication.QuantityInStock,
            RequiresPrescription = request.Medication.RequiresPrescription,
            ExpirationDate = request.Medication.ExpirationDate,
            ReceiptDate = DateTime.UtcNow
        };

        await _medicationService.CreateOrUpdateMedicationValidateAndThrowAsync(
            _dataContext, medication, cancellationToken);

        _dataContext.PharmacyMedications.Add(medication);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return medication.IsnMedication;
    }
}