using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Pharmacy.Medications.DtoModels;

namespace Study.Lab3.Web.Features.Pharmacy.Medications.Queries;

/// <summary>
/// Получение списка медикаментов
/// </summary>
public sealed class GetPharmacyMedicationsListQuery : IRequest<PharmacyMedicationDto[]>
{
}

public sealed class GetPharmacyMedicationsListQueryHandler : IRequestHandler<GetPharmacyMedicationsListQuery, PharmacyMedicationDto[]>
{
    private readonly DataContext _dataContext;

    public GetPharmacyMedicationsListQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PharmacyMedicationDto[]> Handle(GetPharmacyMedicationsListQuery request, CancellationToken cancellationToken)
    {
        var medications = await _dataContext.PharmacyMedications
            .AsNoTracking()
            .Select(medication => new PharmacyMedicationDto
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
            })
            .ToArrayAsync(cancellationToken);

        return medications;
    }
}