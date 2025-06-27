using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Pharmacy.Medications.DtoModels;

namespace Study.Lab3.Web.Features.Pharmacy.Medications.Queries;

/// <summary>
/// Получение медикамента по идентификатору
/// </summary>
public sealed class GetPharmacyMedicationByIdQuery : IRequest<PharmacyMedicationDto>
{
    /// <summary>
    /// Идентификатор медикамента
    /// </summary>
    public Guid Id { get; init; }
}

public sealed class GetPharmacyMedicationByIdQueryHandler : IRequestHandler<GetPharmacyMedicationByIdQuery, PharmacyMedicationDto>
{
    private readonly DataContext _dataContext;

    public GetPharmacyMedicationByIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PharmacyMedicationDto> Handle(GetPharmacyMedicationByIdQuery request, CancellationToken cancellationToken)
    {
        var medication = await _dataContext.PharmacyMedications
                             .AsNoTracking()
                             .FirstOrDefaultAsync(x => x.IsnMedication == request.Id, cancellationToken)
                         ?? throw new BusinessLogicException($"Медикамент с идентификатором {request.Id} не найден");

        return new PharmacyMedicationDto
        {
            IsnMedication = medication.IsnMedication,
            Name = medication.Name,
            Description = medication.Description,
            Manufacturer = medication.Manufacturer,
            Price = medication.Price,
            QuantityInStock = medication.QuantityInStock,
            RequiresPrescription = medication.RequiresPrescription,
            ExpirationDate = medication.ExpirationDate,
            ReceiptDate = medication.ReceiptDate
        };
    }
}