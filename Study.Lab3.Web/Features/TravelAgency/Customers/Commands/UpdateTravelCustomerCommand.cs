using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.TravelAgency;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.TravelAgency.Customers.DtoModels;

namespace Study.Lab3.Web.Features.TravelAgency.Customers.Commands;

/// <summary>
/// Обновление клиента
/// </summary>
public sealed class UpdateTravelCustomerCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные клиента
    /// </summary>
    [Required]
    [FromBody]
    public UpdateTravelCustomerDto TravelCustomer { get; init; }
}

public sealed class UpdateCustomerCommandHandler : IRequestHandler<UpdateTravelCustomerCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ITravelCustomerService _customerService;

    public UpdateCustomerCommandHandler(
        DataContext dataContext,
        ITravelCustomerService customerService)
    {
        _dataContext = dataContext;
        _customerService = customerService;
    }

    public async Task<Guid> Handle(UpdateTravelCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _dataContext.TravelCustomers
                           .FirstOrDefaultAsync(x => x.IsnCustomer == request.TravelCustomer.IsnCustomer, cancellationToken)
                       ?? throw new BusinessLogicException($"Клиент с идентификатором \"{request.TravelCustomer.IsnCustomer}\" не существует");

        customer.SurName = request.TravelCustomer.SurName;
        customer.Name = request.TravelCustomer.Name;
        customer.PatronymicName = request.TravelCustomer.PatronymicName;
        customer.DateOfBirth = request.TravelCustomer.DateOfBirth;
        customer.PassportNumber = request.TravelCustomer.PassportNumber;
        customer.Phone = request.TravelCustomer.Phone;
        customer.Email = request.TravelCustomer.Email;
        customer.Address = request.TravelCustomer.Address;
        customer.IsVip = request.TravelCustomer.IsVip;

        await _customerService.CreateOrUpdateCustomerValidateAndThrowAsync(
            _dataContext, customer, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return customer.IsnCustomer;
    }
}
