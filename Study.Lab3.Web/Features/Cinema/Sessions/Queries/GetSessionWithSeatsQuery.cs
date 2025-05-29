using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Enums.Cinema;
using Study.Lab3.Web.Features.Cinema.Sessions.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Sessions.Queries;

/// <summary>
/// Получение сеанса с информацией о местах
/// </summary>
public sealed class GetSessionWithSeatsQuery : IRequest<SessionWithSeatsDto>
{
    /// <summary>
    /// Идентификатор сеанса
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnSession { get; init; }
}

public sealed class GetSessionWithSeatsQueryHandler : IRequestHandler<GetSessionWithSeatsQuery, SessionWithSeatsDto>
{
    private readonly DataContext _dataContext;

    public GetSessionWithSeatsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<SessionWithSeatsDto> Handle(GetSessionWithSeatsQuery request, CancellationToken cancellationToken)
    {
        var session = await _dataContext.Sessions
                          .AsNoTracking()
                          .Include(x => x.Movie)
                          .Include(x => x.Hall)
                          .Include(x => x.Tickets)
                          .Include(x => x.Hall.Seats)
                          .FirstOrDefaultAsync(x => x.IsnSession == request.IsnSession, cancellationToken)
                      ?? throw new BusinessLogicException(
                          $"Сеанс с идентификатором \"{request.IsnSession}\" не существует");

        var activeTickets = session.Tickets
            .Where(t => t.Status != TicketStatus.Cancelled)
            .ToList();

        return new SessionWithSeatsDto
        {
            IsnSession = session.IsnSession,
            IsnMovie = session.IsnMovie,
            MovieTitle = session.Movie.Title,
            MovieDuration = session.Movie.Duration,
            IsnHall = session.IsnHall,
            HallName = session.Hall.Name,
            HallType = session.Hall.Type.ToString(),
            StartTime = session.StartTime,
            EndTime = session.EndTime,
            BasePrice = session.BasePrice,
            IsActive = session.IsActive,
            Seats = session.Hall.Seats
                .Select(s => new SessionSeatDto
                {
                    IsnSeat = s.IsnSeat,
                    Row = s.Row,
                    Number = s.Number,
                    Type = s.Type,
                    IsAvailable = s.IsActive && !activeTickets.Any(t => t.IsnSeat == s.IsnSeat),
                    IsnTicket = activeTickets.FirstOrDefault(t => t.IsnSeat == s.IsnSeat)?.IsnTicket
                })
                .OrderBy(s => s.Row)
                .ThenBy(s => s.Number)
                .ToArray(),
            AvailableSeatsCount = session.Hall.Seats.Count(s => s.IsActive) - activeTickets.Count,
            SoldSeatsCount = activeTickets.Count
        };
    }
}