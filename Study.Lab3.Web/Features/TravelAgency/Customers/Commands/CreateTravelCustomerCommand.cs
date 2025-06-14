using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.TravelAgency;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.TravelAgency;
using Study.Lab3.Web.Features.TravelAgency.Customers.DtoModels;

namespace Study.Lab3.Web.Features.TravelAgency.Customers.Commands;

/// <summary>
/// Создание клиента
/// </summary>
public sealed class CreateTravelCustomerCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные клиента
    /// </summary>
    [Required]
    [FromBody]
    public CreateTravelCustomerDto TravelCustomer { get; init; }
}

public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateTravelCustomerCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ITravelCustomerService _customerService;

    public CreateCustomerCommandHandler(
        DataContext dataContext,
        ITravelCustomerService customerService)
    {
        _dataContext = dataContext;
        _customerService = customerService;
    }

    public async Task<Guid> Handle(CreateTravelCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new TravelCustomer
        {
            IsnCustomer = Guid.NewGuid(),
            SurName = request.TravelCustomer.SurName,
            Name = request.TravelCustomer.Name,
            PatronymicName = request.TravelCustomer.PatronymicName,
            DateOfBirth = request.TravelCustomer.DateOfBirth,
            PassportNumber = request.TravelCustomer.PassportNumber,
            Phone = request.TravelCustomer.Phone,
            Email = request.TravelCustomer.Email,
            Address = request.TravelCustomer.Address,
            RegistrationDate = DateTime.UtcNow,
            IsVip = request.TravelCustomer.IsVip
        };

        await _customerService.CreateOrUpdateCustomerValidateAndThrowAsync(
            _dataContext, customer, cancellationToken);

        await _dataContext.TravelCustomers.AddAsync(customer, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return customer.IsnCustomer;
    }
}