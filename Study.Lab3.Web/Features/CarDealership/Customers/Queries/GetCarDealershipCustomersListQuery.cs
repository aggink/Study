using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CarDealership.Customers.DtoModels;

namespace Study.Lab3.Web.Features.CarDealership.Customers.Queries;

public sealed class GetCarDealershipCustomersListQuery : IRequest<CarDealershipCustomerDto[]>
{
}
public class GetCarDealershipCustomersListQueryHandler : IRequestHandler<GetCarDealershipCustomersListQuery, CarDealershipCustomerDto[]>
{
    private readonly DataContext _dataContext;

    public GetCarDealershipCustomersListQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<CarDealershipCustomerDto[]> Handle(GetCarDealershipCustomersListQuery request, CancellationToken cancellationToken)
    {
        var customers = await _dataContext.CarDealershipCustomers
            .Select(customer => new CarDealershipCustomerDto
            {
                IsnCustomer = customer.IsnCustomer,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Phone = customer.Phone,
                Address = customer.Address,
                PassportNumber = customer.PassportNumber,
                BirthDate = customer.BirthDate,
                RegistrationDate = customer.RegistrationDate
            })
            .ToArrayAsync(cancellationToken);

        return customers;
    }
}