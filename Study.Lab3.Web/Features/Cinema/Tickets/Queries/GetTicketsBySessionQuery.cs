using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Cinema.Tickets.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Tickets.Queries;

/// <summary>
/// Получение билетов на сеанс
/// </summary>
public sealed class GetTicketsBySessionQuery : IRequest<TicketDto[]>
{
    /// <summary>
    /// Идентификатор сеанса
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnSession { get; init; }
}

public sealed class GetTicketsBySessionQueryHandler : IRequestHandler<GetTicketsBySessionQuery, TicketDto[]>
{
    private readonly DataContext _dataContext;

    public GetTicketsBySessionQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<TicketDto[]> Handle(GetTicketsBySessionQuery request, CancellationToken cancellationToken)
    {
        if (!await _dataContext.Sessions.AnyAsync(s => s.IsnSession == request.IsnSession, cancellationToken))
            throw new BusinessLogicException($"Сеанс с идентификатором \"{request.IsnSession}\" не существует");

        return await _dataContext.Tickets
            .AsNoTracking()
            .Where(t => t.IsnSession == request.IsnSession)
            .OrderBy(t => t.Seat.Row)
            .ThenBy(t => t.Seat.Number)
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