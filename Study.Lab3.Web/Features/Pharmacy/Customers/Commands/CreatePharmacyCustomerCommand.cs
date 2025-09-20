using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Pharmacy;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Pharmacy;
using Study.Lab3.Web.Features.Pharmacy.Customers.DtoModels;

namespace Study.Lab3.Web.Features.Pharmacy.Customers.Commands;

/// <summary>
/// Создание клиента аптеки
/// </summary>
public sealed class CreatePharmacyCustomerCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные клиента
    /// </summary>
    [Required]
    [FromBody]
    public CreatePharmacyCustomerDto Customer { get; init; }
}

public sealed class CreatePharmacyCustomerCommandHandler : IRequestHandler<CreatePharmacyCustomerCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPharmacyCustomerService _customerService;

    public CreatePharmacyCustomerCommandHandler(
        DataContext dataContext,
        IPharmacyCustomerService customerService)
    {
        _dataContext = dataContext;
        _customerService = customerService;
    }

    public async Task<Guid> Handle(CreatePharmacyCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new PharmacyCustomer
        {
            IsnCustomer = Guid.NewGuid(),
            FirstName = request.Customer.FirstName,
            LastName = request.Customer.LastName,
            Phone = request.Customer.Phone,
            Email = request.Customer.Email,
            Address = request.Customer.Address,
            DateOfBirth = request.Customer.DateOfBirth,
            HasInsurance = request.Customer.HasInsurance,
            RegistrationDate = DateTime.UtcNow
        };

        await _customerService.CreateOrUpdateCustomerValidateAndThrowAsync(
            _dataContext, customer, cancellationToken);

        _dataContext.PharmacyCustomers.Add(customer);
        await _dataContext.SaveChangesAsync(cancellationToken);
        
        return customer.IsnCustomer;
    }
}