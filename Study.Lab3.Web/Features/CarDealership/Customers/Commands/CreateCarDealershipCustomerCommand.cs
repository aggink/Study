using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.CarDealership;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.CarDealership;
using Study.Lab3.Web.Features.CarDealership.Customers.DtoModels;

namespace Study.Lab3.Web.Features.CarDealership.Customers.Commands;

/// <summary>
/// Создание клиента автосалона
/// </summary>
public sealed class CreateCarDealershipCustomerCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные клиента
    /// </summary>
    [Required]
    [FromBody]
    public CreateCarDealershipCustomerDto Customer { get; init; }
}

public class CreateCarDealershipCustomerCommandHandler : IRequestHandler<CreateCarDealershipCustomerCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ICarDealershipCustomerService _customerService;

    public CreateCarDealershipCustomerCommandHandler(
        DataContext dataContext,
        ICarDealershipCustomerService customerService)
    {
        _dataContext = dataContext;
        _customerService = customerService;
    }

    public async Task<Guid> Handle(CreateCarDealershipCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new CarDealershipCustomer
        {
            IsnCustomer = Guid.NewGuid(),
            FirstName = request.Customer.FirstName,
            LastName = request.Customer.LastName,
            Email = request.Customer.Email,
            Phone = request.Customer.Phone,
            Address = request.Customer.Address,
            PassportNumber = request.Customer.PassportNumber,
            BirthDate = request.Customer.BirthDate,
            RegistrationDate = DateTime.UtcNow
        };

        await _customerService.CreateOrUpdateCustomerValidateAndThrowAsync(_dataContext, customer, cancellationToken);

        _dataContext.CarDealershipCustomers.Add(customer);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return customer.IsnCustomer;
    }
}