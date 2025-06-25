using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Pharmacy;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Pharmacy.Customers.DtoModels;

namespace Study.Lab3.Web.Features.Pharmacy.Customers.Commands;

/// <summary>
/// Обновление клиента аптеки
/// </summary>
public sealed class UpdatePharmacyCustomerCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные клиента
    /// </summary>
    [Required]
    [FromBody]
    public UpdatePharmacyCustomerDto Customer { get; init; }
}

public sealed class UpdatePharmacyCustomerCommandHandler : IRequestHandler<UpdatePharmacyCustomerCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPharmacyCustomerService _customerService;

    public UpdatePharmacyCustomerCommandHandler(
        DataContext dataContext,
        IPharmacyCustomerService customerService)
    {
        _dataContext = dataContext;
        _customerService = customerService;
    }

    public async Task<Guid> Handle(UpdatePharmacyCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _dataContext.PharmacyCustomers
                           .FirstOrDefaultAsync(x => x.IsnCustomer == request.Customer.IsnCustomer, cancellationToken)
                       ?? throw new BusinessLogicException($"Клиент с идентификатором {request.Customer.IsnCustomer} не найден");

        customer.FirstName = request.Customer.FirstName;
        customer.LastName = request.Customer.LastName;
        customer.Phone = request.Customer.Phone;
        customer.Email = request.Customer.Email;
        customer.Address = request.Customer.Address;
        customer.DateOfBirth = request.Customer.DateOfBirth;
        customer.HasInsurance = request.Customer.HasInsurance;

        await _customerService.CreateOrUpdateCustomerValidateAndThrowAsync(_dataContext, customer, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return customer.IsnCustomer;
    }
}