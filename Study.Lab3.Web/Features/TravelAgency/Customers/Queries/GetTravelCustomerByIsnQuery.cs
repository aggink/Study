using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.TravelAgency.Customers.DtoModels;

namespace Study.Lab3.Web.Features.TravelAgency.Customers.Queries;

/// <summary>
/// Получить клиента по идентификатору
/// </summary>
public sealed class GetTravelCustomerByIsnQuery : IRequest<TravelCustomerDto>
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnCustomer { get; init; }
}

public sealed class GetCustomerByIsnQueryHandler : IRequestHandler<GetTravelCustomerByIsnQuery, TravelCustomerDto>
{
    private readonly DataContext _dataContext;

    public GetCustomerByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<TravelCustomerDto> Handle(GetTravelCustomerByIsnQuery request, CancellationToken cancellationToken)
    {
        var customer = await _dataContext.TravelCustomers
                           .AsNoTracking()
                           .FirstOrDefaultAsync(x => x.IsnCustomer == request.IsnCustomer, cancellationToken)
                       ?? throw new BusinessLogicException($"Клиент с идентификатором \"{request.IsnCustomer}\" не существует");

        return new TravelCustomerDto
        {
            IsnCustomer = customer.IsnCustomer,
            SurName = customer.SurName,
            Name = customer.Name,
            PatronymicName = customer.PatronymicName,
            DateOfBirth = customer.DateOfBirth,
            PassportNumber = customer.PassportNumber,
            Phone = customer.Phone,
            Email = customer.Email,
            Address = customer.Address,
            RegistrationDate = customer.RegistrationDate,
            IsVip = customer.IsVip
        };
    }
}