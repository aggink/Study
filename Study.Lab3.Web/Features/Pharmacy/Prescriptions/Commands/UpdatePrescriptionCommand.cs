using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Pharmacy;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Pharmacy.Prescriptions.DtoModels;

namespace Study.Lab3.Web.Features.Pharmacy.Prescriptions.Commands;

/// <summary>
/// Обновление рецепта
/// </summary>
public sealed class UpdatePrescriptionCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные рецепта
    /// </summary>
    [Required]
    [FromBody]
    public UpdatePrescriptionDto Prescription { get; init; }
}

public sealed class UpdatePrescriptionCommandHandler : IRequestHandler<UpdatePrescriptionCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPrescriptionService _prescriptionService;

    public UpdatePrescriptionCommandHandler(
        DataContext dataContext,
        IPrescriptionService prescriptionService)
    {
        _dataContext = dataContext;
        _prescriptionService = prescriptionService;
    }

    public async Task<Guid> Handle(UpdatePrescriptionCommand request, CancellationToken cancellationToken)
    {
        var prescription = await _dataContext.Prescriptions
                               .FirstOrDefaultAsync(x => x.IsnPrescription == request.Prescription.IsnPrescription, cancellationToken)
                           ?? throw new BusinessLogicException($"Рецепт с идентификатором {request.Prescription.IsnPrescription} не найден");

        prescription.IsnCustomer = request.Prescription.IsnCustomer;
        prescription.IsnMedication = request.Prescription.IsnMedication;
        prescription.PrescriptionNumber = request.Prescription.PrescriptionNumber;
        prescription.DoctorName = request.Prescription.DoctorName;
        prescription.Dosage = request.Prescription.Dosage;
        prescription.Instructions = request.Prescription.Instructions;
        prescription.IssueDate = request.Prescription.IssueDate;
        prescription.ExpiryDate = request.Prescription.ExpiryDate;
        prescription.IsUsed = request.Prescription.IsUsed;

        await _prescriptionService.CreateOrUpdatePrescriptionValidateAndThrowAsync(_dataContext, prescription, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return prescription.IsnPrescription;
    }
}