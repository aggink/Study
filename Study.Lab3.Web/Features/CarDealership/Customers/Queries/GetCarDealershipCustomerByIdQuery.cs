using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CarDealership.Customers.DtoModels;

namespace Study.Lab3.Web.Features.CarDealership.Customers.Queries;

/// <summary>
/// Получение клиента автосалона по идентификатору
/// </summary>
public sealed class GetCarDealershipCustomerByIdQuery : IRequest<CarDealershipCustomerDto>
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public Guid Id { get; init; }
}
public class GetCarDealershipCustomerByIdQueryHandler : IRequestHandler<GetCarDealershipCustomerByIdQuery, CarDealershipCustomerDto>
{
    private readonly DataContext _dataContext;

    public GetCarDealershipCustomerByIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<CarDealershipCustomerDto> Handle(GetCarDealershipCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _dataContext.CarDealershipCustomers
            .FirstOrDefaultAsync(x => x.IsnCustomer == request.Id, cancellationToken);

        if (customer == null)
            throw new InvalidOperationException($"Клиент с идентификатором {request.Id} не найден");

        return new CarDealershipCustomerDto
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
        };
    }
}