using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Cinema.Tickets.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Tickets.Queries;

/// <summary>
/// Получение билета по идентификатору
/// </summary>
public sealed class GetTicketByIdQuery : IRequest<TicketDto>
{
    /// <summary>
    /// Идентификатор билета
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnTicket { get; init; }
}

public sealed class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, TicketDto>
{
    private readonly DataContext _dataContext;

    public GetTicketByIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<TicketDto> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        var ticket = await _dataContext.Tickets
                         .AsNoTracking()
                         .FirstOrDefaultAsync(t => t.IsnTicket == request.IsnTicket, cancellationToken)
                     ?? throw new BusinessLogicException(
                         $"Билет с идентификатором \"{request.IsnTicket}\" не существует");

        return new TicketDto
        {
            IsnTicket = ticket.IsnTicket,
            IsnSession = ticket.IsnSession,
            IsnSeat = ticket.IsnSeat,
            IsnCustomer = ticket.IsnCustomer,
            Price = ticket.Price,
            PurchaseDate = ticket.PurchaseDate,
            Status = ticket.Status,
            TicketCode = ticket.TicketCode
        };
    }
}