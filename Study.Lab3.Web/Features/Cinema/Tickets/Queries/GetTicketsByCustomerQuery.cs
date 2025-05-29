using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Cinema.Tickets.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Tickets.Queries;

/// <summary>
/// Получение билетов клиента
/// </summary>
public sealed class GetTicketsByCustomerQuery : IRequest<TicketDto[]>
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnCustomer { get; init; }
}

public sealed class GetTicketsByCustomerQueryHandler : IRequestHandler<GetTicketsByCustomerQuery, TicketDto[]>
{
    private readonly DataContext _dataContext;

    public GetTicketsByCustomerQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<TicketDto[]> Handle(GetTicketsByCustomerQuery request, CancellationToken cancellationToken)
    {
        if (!await _dataContext.Customers.AnyAsync(c => c.IsnCustomer == request.IsnCustomer, cancellationToken))
            throw new BusinessLogicException($"Клиент с идентификатором \"{request.IsnCustomer}\" не существует");

        return await _dataContext.Tickets
            .AsNoTracking()
            .Include(t => t.Session)
            .Where(t => t.IsnCustomer == request.IsnCustomer)
            .OrderByDescending(t => t.Session.StartTime)
            .Select(t => new TicketDto
            {
                IsnTicket = t.IsnTicket,
                IsnSession = t.IsnSession,
                IsnSeat = t.IsnSeat,
                IsnCustomer = t.IsnCustomer,
                Price = t.Price,
                PurchaseDate = t.PurchaseDate,
                Status = t.Status,
                TicketCode = t.TicketCode
            })
            .ToArrayAsync(cancellationToken);
    }
}