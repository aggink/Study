using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Pharmacy;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.Pharmacy.Medications.Commands;

/// <summary>
/// Удаление медикамента
/// </summary>
public sealed class DeletePharmacyMedicationCommand : IRequest
{
    /// <summary>
    /// Идентификатор медикамента
    /// </summary>
    [Required]
    public Guid IsnMedication { get; init; }
}

public sealed class DeletePharmacyMedicationCommandHandler : IRequestHandler<DeletePharmacyMedicationCommand>
{
    private readonly DataContext _dataContext;
    private readonly IPharmacyMedicationService _medicationService;

    public DeletePharmacyMedicationCommandHandler(
        DataContext dataContext,
        IPharmacyMedicationService medicationService)
    {
        _dataContext = dataContext;
        _medicationService = medicationService;
    }

    public async Task Handle(DeletePharmacyMedicationCommand request, CancellationToken cancellationToken)
    {
        var medication = await _dataContext.PharmacyMedications
                             .FirstOrDefaultAsync(x => x.IsnMedication == request.IsnMedication, cancellationToken)
                         ?? throw new BusinessLogicException($"Медикамент с идентификатором {request.IsnMedication} не найден");

        await _medicationService.CanDeleteAndThrowAsync(_dataContext, medication, cancellationToken);

        _dataContext.PharmacyMedications.Remove(medication);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}