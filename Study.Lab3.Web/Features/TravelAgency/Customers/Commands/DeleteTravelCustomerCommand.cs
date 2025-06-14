using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.TravelAgency;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.TravelAgency.Customers.Commands;

/// <summary>
/// Удаление клиента
/// </summary>
public sealed class DeleteTravelCustomerCommand : IRequest
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnCustomer { get; init; }
}

public sealed class DeleteCustomerCommandHandler : IRequestHandler<DeleteTravelCustomerCommand>
{
    private readonly DataContext _dataContext;
    private readonly ITravelCustomerService _customerService;

    public DeleteCustomerCommandHandler(
        DataContext dataContext,
        ITravelCustomerService customerService)
    {
        _dataContext = dataContext;
        _customerService = customerService;
    }

    public async Task Handle(DeleteTravelCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _dataContext.TravelCustomers
                           .FirstOrDefaultAsync(x => x.IsnCustomer == request.IsnCustomer, cancellationToken)
                       ?? throw new BusinessLogicException($"Клиент с идентификатором \"{request.IsnCustomer}\" не существует");

        await _customerService.CanDeleteAndThrowAsync(_dataContext, customer, cancellationToken);

        _dataContext.TravelCustomers.Remove(customer);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}