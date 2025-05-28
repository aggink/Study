using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Extensions.Cinema;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Cinema.Tickets.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Tickets.Queries;

/// <summary>
/// Получение билета с подробной информацией
/// </summary>
public sealed class GetTicketWithDetailsQuery : IRequest<TicketWithDetailsDto>
{
    /// <summary>
    /// Идентификатор билета
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnTicket { get; init; }
}

public sealed class GetTicketWithDetailsQueryHandler : IRequestHandler<GetTicketWithDetailsQuery, TicketWithDetailsDto>
{
    private readonly DataContext _dataContext;

    public GetTicketWithDetailsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<TicketWithDetailsDto> Handle(GetTicketWithDetailsQuery request, CancellationToken cancellationToken)
    {
        var ticket = await _dataContext.Tickets
                         .AsNoTracking()
                         .Include(t => t.Session)
                             .ThenInclude(s => s.Movie)
                         .Include(t => t.Session)
                             .ThenInclude(s => s.Hall)
                         .Include(t => t.Seat)
                         .Include(t => t.Customer)
                         .FirstOrDefaultAsync(t => t.IsnTicket == request.IsnTicket, cancellationToken)
                     ?? throw new BusinessLogicException(
                         $"Билет с идентификатором \"{request.IsnTicket}\" не существует");

        return new TicketWithDetailsDto
        {
            IsnTicket = ticket.IsnTicket,
            IsnSession = ticket.IsnSession,
            MovieTitle = ticket.Session.Movie.Title,
            HallName = ticket.Session.Hall.Name,
            SessionStartTime = ticket.Session.StartTime,
            SessionEndTime = ticket.Session.EndTime,
            IsnSeat = ticket.IsnSeat,
            SeatRow = ticket.Seat.Row,
            SeatNumber = ticket.Seat.Number,
            SeatType = ticket.Seat.Type,
            IsnCustomer = ticket.IsnCustomer,
            CustomerName = ticket.Customer.GetFullName(),
            Price = ticket.Price,
            PurchaseDate = ticket.PurchaseDate,
            Status = ticket.Status,
            TicketCode = ticket.TicketCode
        };
    }
}