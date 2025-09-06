using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Pharmacy;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.Pharmacy.Customers.Commands;

/// <summary>
/// Удаление клиента аптеки
/// </summary>
public sealed class DeletePharmacyCustomerCommand : IRequest
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Required]
    public Guid IsnCustomer { get; init; }
}

public sealed class DeletePharmacyCustomerCommandHandler : IRequestHandler<DeletePharmacyCustomerCommand>
{
    private readonly DataContext _dataContext;
    private readonly IPharmacyCustomerService _customerService;

    public DeletePharmacyCustomerCommandHandler(
        DataContext dataContext,
        IPharmacyCustomerService customerService)
    {
        _dataContext = dataContext;
        _customerService = customerService;
    }

    public async Task Handle(DeletePharmacyCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _dataContext.PharmacyCustomers
                           .FirstOrDefaultAsync(x => x.IsnCustomer == request.IsnCustomer, cancellationToken)
                       ?? throw new BusinessLogicException($"Клиент с идентификатором {request.IsnCustomer} не найден");

        await _customerService.CanDeleteAndThrowAsync(_dataContext, customer, cancellationToken);

        _dataContext.PharmacyCustomers.Remove(customer);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}