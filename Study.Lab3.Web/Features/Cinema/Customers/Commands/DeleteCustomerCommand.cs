using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Enums.Cinema;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Customers.Commands;

/// <summary>
/// Удаление клиента
/// </summary>
public sealed class DeleteCustomerCommand : IRequest
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnCustomer { get; init; }
}

public sealed class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
{
    private readonly DataContext _dataContext;

    public DeleteCustomerCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _dataContext.Customers
                           .Include(c => c.Tickets)
                           .FirstOrDefaultAsync(c => c.IsnCustomer == request.IsnCustomer, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Клиент с идентификатором \"{request.IsnCustomer}\" не существует");

        // Проверка наличия активных билетов
        if (customer.Tickets.Any(t => t.Status == TicketStatus.Active))
            throw new BusinessLogicException("Нельзя удалить клиента с активными билетами");

        // Отметка всех неиспользованных билетов как отмененных
        foreach (var ticket in customer.Tickets.Where(t => t.Status == TicketStatus.Active))
        {
            ticket.Status = TicketStatus.Cancelled;
        }

        // Удаляем клиента
        _dataContext.Customers.Remove(customer);

        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}