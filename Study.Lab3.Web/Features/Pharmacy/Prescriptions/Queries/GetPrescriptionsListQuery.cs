using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Pharmacy.Prescriptions.DtoModels;

namespace Study.Lab3.Web.Features.Pharmacy.Prescriptions.Queries;

/// <summary>
/// Получение списка рецептов
/// </summary>
public sealed class GetPrescriptionsListQuery : IRequest<PrescriptionDto[]>
{
}

public sealed class GetPrescriptionsListQueryHandler : IRequestHandler<GetPrescriptionsListQuery, PrescriptionDto[]>
{
    private readonly DataContext _dataContext;

    public GetPrescriptionsListQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PrescriptionDto[]> Handle(GetPrescriptionsListQuery request, CancellationToken cancellationToken)
    {
        var prescriptions = await _dataContext.Prescriptions
            .Select(prescription => new PrescriptionDto
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
            })
            .ToArrayAsync(cancellationToken);

        return prescriptions;
    }
}