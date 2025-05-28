using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Cinema.Customers.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Customers.Queries;

/// <summary>
/// Получение клиента по идентификатору
/// </summary>
public sealed class GetCustomerByIdQuery : IRequest<CustomerDto>
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnCustomer { get; init; }
}

public sealed class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
{
    private readonly DataContext _dataContext;

    public GetCustomerByIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _dataContext.Customers
                           .AsNoTracking()
                           .FirstOrDefaultAsync(c => c.IsnCustomer == request.IsnCustomer, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Клиент с идентификатором \"{request.IsnCustomer}\" не существует");

        return new CustomerDto
        {
            IsnCustomer = customer.IsnCustomer,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            Phone = customer.Phone,
            BirthDate = customer.BirthDate,
            RegistrationDate = customer.RegistrationDate,
            IsActive = customer.IsActive
        };
    }
}