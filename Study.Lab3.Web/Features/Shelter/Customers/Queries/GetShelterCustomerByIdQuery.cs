using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Shelter.Customers.DtoModels;

namespace Study.Lab3.Web.Features.Shelter.Customers.Queries;

/// <summary>
/// Получение клиента по идентификатору
/// </summary>
public sealed class GetShelterCustomerByIdQuery : IRequest<ShelterCustomerDto>
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnCustomer { get; init; }
}

public sealed class GetCustomerByIdQueryHandler : IRequestHandler<GetShelterCustomerByIdQuery, ShelterCustomerDto>
{
    private readonly DataContext _dataContext;

    public GetCustomerByIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ShelterCustomerDto> Handle(GetShelterCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _dataContext.ShelterCustomers
                           .AsNoTracking()
                           .FirstOrDefaultAsync(c => c.IsnCustomer == request.IsnCustomer, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Клиент с идентификатором \"{request.IsnCustomer}\" не существует");

        return new ShelterCustomerDto
        {
            IsnCustomer = customer.IsnCustomer,
            Name = customer.Name,
            LastName = customer.LastName,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
            Description = customer.Description,
            Address = customer.Address,
        };
    }
}