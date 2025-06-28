using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CarDealership;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CarDealership.Customers.DtoModels;

namespace Study.Lab3.Web.Features.CarDealership.Customers.Commands;

/// <summary>
/// Обновление клиента автосалона
/// </summary>
public sealed class UpdateCarDealershipCustomerCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные клиента
    /// </summary>
    [Required]
    [FromBody]
    public UpdateCarDealershipCustomerDto Customer { get; init; }
}
public class UpdateCarDealershipCustomerCommandHandler : IRequestHandler<UpdateCarDealershipCustomerCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ICarDealershipCustomerService _customerService;

    public UpdateCarDealershipCustomerCommandHandler(
        DataContext dataContext,
        ICarDealershipCustomerService customerService)
    {
        _dataContext = dataContext;
        _customerService = customerService;
    }

    public async Task<Guid> Handle(UpdateCarDealershipCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _dataContext.CarDealershipCustomers
            .FirstOrDefaultAsync(x => x.IsnCustomer == request.Customer.IsnCustomer, cancellationToken);

        if (customer == null)
            throw new InvalidOperationException($"Клиент с идентификатором {request.Customer.IsnCustomer} не найден");

        customer.FirstName = request.Customer.FirstName;
        customer.LastName = request.Customer.LastName;
        customer.Email = request.Customer.Email;
        customer.Phone = request.Customer.Phone;
        customer.Address = request.Customer.Address;
        customer.PassportNumber = request.Customer.PassportNumber;
        customer.BirthDate = request.Customer.BirthDate;

        await _customerService.CreateOrUpdateCustomerValidateAndThrowAsync(_dataContext, customer, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return customer.IsnCustomer;
    }
}