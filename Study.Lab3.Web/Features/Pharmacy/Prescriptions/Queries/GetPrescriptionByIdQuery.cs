using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Pharmacy.Prescriptions.DtoModels;

namespace Study.Lab3.Web.Features.Pharmacy.Prescriptions.Queries;

/// <summary>
/// Получение рецепта по идентификатору
/// </summary>
public sealed class GetPrescriptionByIdQuery : IRequest<PrescriptionDto>
{
    /// <summary>
    /// Идентификатор рецепта
    /// </summary>
    public Guid Id { get; init; }
}

public sealed class GetPrescriptionByIdQueryHandler : IRequestHandler<GetPrescriptionByIdQuery, PrescriptionDto>
{
    private readonly DataContext _dataContext;

    public GetPrescriptionByIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PrescriptionDto> Handle(GetPrescriptionByIdQuery request, CancellationToken cancellationToken)
    {
        var prescription = await _dataContext.Prescriptions
                               .FirstOrDefaultAsync(x => x.IsnPrescription == request.Id, cancellationToken)
                           ?? throw new BusinessLogicException($"Рецепт с идентификатором {request.Id} не найден");

        return new PrescriptionDto
        {
            IsnPrescription = prescription.IsnPrescription,
            IsnCustomer = prescription.IsnCustomer,
            IsnMedication = prescription.IsnMedication,
            PrescriptionNumber = prescription.PrescriptionNumber,
            DoctorName = prescription.DoctorName,
            Dosage = prescription.Dosage,
            Instructions = prescription.Instructions,
            IssueDate = prescription.IssueDate,
            ExpiryDate = prescription.ExpiryDate,
            IsUsed = prescription.IsUsed
        };
    }
}