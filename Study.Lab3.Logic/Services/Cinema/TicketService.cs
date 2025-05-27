using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Extensions.Cinema;
using Study.Lab3.Logic.Interfaces.Services.Cinema;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Enums.Cinema;
using Study.Lab3.Storage.Models.Cinema;

namespace Study.Lab3.Logic.Services.Cinema;

public sealed class TicketService : ITicketService
{
    public async Task CreateTicketValidateAndThrowAsync(
        DataContext dataContext,
        Ticket ticket,
        CancellationToken cancellationToken = default)
    {
        // Проверка существования сеанса
        var session = await dataContext.Sessions
            .Include(x => x.Movie)
            .FirstOrDefaultAsync(x => x.IsnSession == ticket.IsnSession, cancellationToken)
            ?? throw new BusinessLogicException(
                $"Сеанс с идентификатором \"{ticket.IsnSession}\" не существует");

        // Проверка существования места
        var seat = await dataContext.Seats
            .FirstOrDefaultAsync(x => x.IsnSeat == ticket.IsnSeat, cancellationToken)
            ?? throw new BusinessLogicException(
                $"Место с идентификатором \"{ticket.IsnSeat}\" не существует");

        // Проверка существования клиента
        var customer = await dataContext.Customers
            .FirstOrDefaultAsync(x => x.IsnCustomer == ticket.IsnCustomer, cancellationToken)
            ?? throw new BusinessLogicException(
                $"Клиент с идентификатором \"{ticket.IsnCustomer}\" не существует");

        // Проверка, что место принадлежит залу сеанса
        if (seat.IsnHall != session.IsnHall)
            throw new BusinessLogicException("Выбранное место не принадлежит залу данного сеанса");

        // Проверка активности места
        if (!seat.IsActive)
            throw new BusinessLogicException("Выбранное место недоступно");

        // Проверка времени сеанса
        if (session.StartTime < DateTime.UtcNow)
            throw new BusinessLogicException("Невозможно купить билет на прошедший сеанс");

        // Проверка возрастного ограничения
        if (!customer.CanWatchMovie(session.Movie.AgeRating))
            throw new BusinessLogicException(
                $"Клиент не может посмотреть этот фильм из-за возрастного ограничения {session.Movie.AgeRating}+");

        // Проверка, что место не занято
        var seatTaken = await dataContext.Tickets
            .AnyAsync(x => x.IsnSession == ticket.IsnSession && 
                          x.IsnSeat == ticket.IsnSeat &&
                          x.Status != TicketStatus.Cancelled,
                      cancellationToken);

        if (seatTaken)
            throw new BusinessLogicException("Это место уже занято");

        // Расчет цены билета
        ticket.Price = CalculateTicketPrice(session.BasePrice, seat);
        
        // Генерация кода билета
        ticket.TicketCode = GenerateTicketCode();
        
        // Установка даты покупки и статуса
        ticket.PurchaseDate = DateTime.UtcNow;
        ticket.Status = TicketStatus.Active;
    }

    public async Task CanCancelAndThrowAsync(
        DataContext dataContext,
        Ticket ticket,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Tickets.AnyAsync(x => x.IsnTicket == ticket.IsnTicket, cancellationToken))
            throw new BusinessLogicException(
                $"Билет с идентификатором \"{ticket.IsnTicket}\" не существует");

        if (ticket.Status == TicketStatus.Cancelled)
            throw new BusinessLogicException("Билет уже отменен");

        if (ticket.Status == TicketStatus.Used)
            throw new BusinessLogicException("Невозможно отменить использованный билет");

        var session = await dataContext.Sessions
            .FirstOrDefaultAsync(x => x.IsnSession == ticket.IsnSession, cancellationToken);

        if (session != null)
        {
            // Нельзя отменить билет менее чем за час до сеанса
            if (session.StartTime <= DateTime.UtcNow.AddHours(1))
                throw new BusinessLogicException(
                    "Невозможно отменить билет менее чем за час до начала сеанса");
        }
    }

    public decimal CalculateTicketPrice(decimal basePrice, Seat seat)
    {
        var multiplier = seat.Type switch
        {
            SeatType.VIP => 1.5m,
            SeatType.Couple => 1.8m,
            SeatType.Wheelchair => 0.8m, // Скидка для инвалидов
            _ => 1.0m
        };

        return Math.Round(basePrice * multiplier, 2);
    }

    public string GenerateTicketCode()
    {
        var random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 8)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}