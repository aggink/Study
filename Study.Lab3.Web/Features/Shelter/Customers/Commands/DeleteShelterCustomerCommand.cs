using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.Shelter.Customers.Commands;

public sealed class DeleteShelterCustomerCommand : IRequest
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnCustomer { get; init; }
}

public sealed class DeleteCustomerCommandHandler : IRequestHandler<DeleteShelterCustomerCommand>
{
    private readonly DataContext _dataContext;

    public DeleteCustomerCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(DeleteShelterCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _dataContext.ShelterCustomers
            .FirstOrDefaultAsync(c => c.IsnCustomer == request.IsnCustomer, cancellationToken)
            ?? throw new BusinessLogicException($"Клиент с идентификатором \"{request.IsnCustomer}\" не существует");

        _dataContext.ShelterCustomers.Remove(customer);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}