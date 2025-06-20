using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CarDealership;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.CarDealership.Customers.Commands;

/// <summary>
/// Удаление клиента автосалона
/// </summary>
public sealed class DeleteCarDealershipCustomerCommand : IRequest
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Required]
    public Guid IsnCustomer { get; init; }
}
public class DeleteCarDealershipCustomerCommandHandler : IRequestHandler<DeleteCarDealershipCustomerCommand>
{
    private readonly DataContext _dataContext;
    private readonly ICarDealershipCustomerService _customerService;

    public DeleteCarDealershipCustomerCommandHandler(
        DataContext dataContext,
        ICarDealershipCustomerService customerService)
    {
        _dataContext = dataContext;
        _customerService = customerService;
    }

    public async Task Handle(DeleteCarDealershipCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _dataContext.CarDealershipCustomers
            .FirstOrDefaultAsync(x => x.IsnCustomer == request.IsnCustomer, cancellationToken);

        if (customer == null)
            throw new InvalidOperationException($"Клиент с идентификатором {request.IsnCustomer} не найден");

        await _customerService.CanDeleteAndThrowAsync(_dataContext, customer, cancellationToken);

        _dataContext.CarDealershipCustomers.Remove(customer);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}