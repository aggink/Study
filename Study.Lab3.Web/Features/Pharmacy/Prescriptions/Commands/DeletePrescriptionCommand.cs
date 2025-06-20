using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Pharmacy;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.Pharmacy.Prescriptions.Commands;

/// <summary>
/// Удаление рецепта
/// </summary>
public sealed class DeletePrescriptionCommand : IRequest
{
    /// <summary>
    /// Идентификатор рецепта
    /// </summary>
    [Required]
    public Guid IsnPrescription { get; init; }
}

public sealed class DeletePrescriptionCommandHandler : IRequestHandler<DeletePrescriptionCommand>
{
    private readonly DataContext _dataContext;
    private readonly IPrescriptionService _prescriptionService;

    public DeletePrescriptionCommandHandler(
        DataContext dataContext,
        IPrescriptionService prescriptionService)
    {
        _dataContext = dataContext;
        _prescriptionService = prescriptionService;
    }

    public async Task Handle(DeletePrescriptionCommand request, CancellationToken cancellationToken)
    {
        var prescription = await _dataContext.Prescriptions
                               .FirstOrDefaultAsync(x => x.IsnPrescription == request.IsnPrescription, cancellationToken)
                           ?? throw new BusinessLogicException($"Рецепт с идентификатором {request.IsnPrescription} не найден");

        await _prescriptionService.CanDeleteAndThrowAsync(_dataContext, prescription, cancellationToken);

        _dataContext.Prescriptions.Remove(prescription);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}