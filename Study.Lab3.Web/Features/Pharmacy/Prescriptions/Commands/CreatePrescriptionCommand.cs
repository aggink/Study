using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Pharmacy;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Pharmacy;
using Study.Lab3.Web.Features.Pharmacy.Prescriptions.DtoModels;

namespace Study.Lab3.Web.Features.Pharmacy.Prescriptions.Commands;

/// <summary>
/// Создание рецепта
/// </summary>
public sealed class CreatePrescriptionCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные рецепта
    /// </summary>
    [Required]
    [FromBody]
    public CreatePrescriptionDto Prescription { get; init; }
}

public sealed class CreatePrescriptionCommandHandler : IRequestHandler<CreatePrescriptionCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPrescriptionService _prescriptionService;

    public CreatePrescriptionCommandHandler(
        DataContext dataContext,
        IPrescriptionService prescriptionService)
    {
        _dataContext = dataContext;
        _prescriptionService = prescriptionService;
    }

    public async Task<Guid> Handle(CreatePrescriptionCommand request, CancellationToken cancellationToken)
    {
        var prescription = new Prescription
        {
            IsnPrescription = Guid.NewGuid(),
            IsnCustomer = request.Prescription.IsnCustomer,
            IsnMedication = request.Prescription.IsnMedication,
            PrescriptionNumber = request.Prescription.PrescriptionNumber,
            DoctorName = request.Prescription.DoctorName,
            Dosage = request.Prescription.Dosage,
            Instructions = request.Prescription.Instructions,
            IssueDate = request.Prescription.IssueDate,
            ExpiryDate = request.Prescription.ExpiryDate,
            IsUsed = request.Prescription.IsUsed
        };

        await _prescriptionService.CreateOrUpdatePrescriptionValidateAndThrowAsync(_dataContext, prescription, cancellationToken);

        _dataContext.Prescriptions.Add(prescription);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return prescription.IsnPrescription;
    }
}