using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Pharmacy.Customers.DtoModels;

namespace Study.Lab3.Web.Features.Pharmacy.Customers.Queries;

/// <summary>
/// Получение клиента аптеки по идентификатору
/// </summary>
public sealed class GetPharmacyCustomerByIdQuery : IRequest<PharmacyCustomerDto>
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    public Guid Id { get; init; }
}

public sealed class GetPharmacyCustomerByIdQueryHandler : IRequestHandler<GetPharmacyCustomerByIdQuery, PharmacyCustomerDto>
{
    private readonly DataContext _dataContext;

    public GetPharmacyCustomerByIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PharmacyCustomerDto> Handle(GetPharmacyCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _dataContext.PharmacyCustomers
                           .FirstOrDefaultAsync(x => x.IsnCustomer == request.Id, cancellationToken)
                       ?? throw new BusinessLogicException($"Клиент с идентификатором {request.Id} не найден");

        return new PharmacyCustomerDto
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
        };
    }
}