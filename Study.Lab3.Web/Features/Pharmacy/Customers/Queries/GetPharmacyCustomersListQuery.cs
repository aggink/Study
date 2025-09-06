using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Pharmacy.Customers.DtoModels;

namespace Study.Lab3.Web.Features.Pharmacy.Customers.Queries;

/// <summary>
/// Получение списка клиентов аптеки
/// </summary>
public sealed class GetPharmacyCustomersListQuery : IRequest<PharmacyCustomerDto[]>
{
}

public sealed class GetPharmacyCustomersListQueryHandler : IRequestHandler<GetPharmacyCustomersListQuery, PharmacyCustomerDto[]>
{
    private readonly DataContext _dataContext;

    public GetPharmacyCustomersListQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PharmacyCustomerDto[]> Handle(GetPharmacyCustomersListQuery request, CancellationToken cancellationToken)
    {
        var customers = await _dataContext.PharmacyCustomers
            .Select(customer => new PharmacyCustomerDto
            {
                IsnCustomer = customer.IsnCustomer,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Phone = customer.Phone,
                Email = customer.Email,
                Address = customer.Address,
                DateOfBirth = customer.DateOfBirth,
                RegistrationDate = customer.RegistrationDate,
                HasInsurance = customer.HasInsurance
            })
            .ToArrayAsync(cancellationToken);

        return customers;
    }
}