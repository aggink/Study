using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Pharmacy;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Pharmacy.Medications.DtoModels;

namespace Study.Lab3.Web.Features.Pharmacy.Medications.Commands;

/// <summary>
/// Обновление медикамента
/// </summary>
public sealed class UpdatePharmacyMedicationCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные медикамента
    /// </summary>
    [Required]
    [FromBody]
    public UpdatePharmacyMedicationDto Medication { get; init; }
}

public sealed class UpdatePharmacyMedicationCommandHandler : IRequestHandler<UpdatePharmacyMedicationCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPharmacyMedicationService _medicationService;

    public UpdatePharmacyMedicationCommandHandler(
        DataContext dataContext,
        IPharmacyMedicationService medicationService)
    {
        _dataContext = dataContext;
        _medicationService = medicationService;
    }

    public async Task<Guid> Handle(UpdatePharmacyMedicationCommand request, CancellationToken cancellationToken)
    {
        var medication = await _dataContext.PharmacyMedications
                             .FirstOrDefaultAsync(x => x.IsnMedication == request.Medication.IsnMedication, cancellationToken)
                         ?? throw new BusinessLogicException($"Медикамент с идентификатором {request.Medication.IsnMedication} не найден");

        medication.Name = request.Medication.Name;
        medication.Description = request.Medication.Description;
        medication.Manufacturer = request.Medication.Manufacturer;
        medication.Price = request.Medication.Price;
        medication.QuantityInStock = request.Medication.QuantityInStock;
        medication.RequiresPrescription = request.Medication.RequiresPrescription;
        medication.ExpirationDate = request.Medication.ExpirationDate;

        await _medicationService.CreateOrUpdateMedicationValidateAndThrowAsync(
            _dataContext, medication, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);

        return medication.IsnMedication;
    }
}