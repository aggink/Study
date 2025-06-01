using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Enums.Cinema;
using Study.Lab3.Storage.Models.Cinema;
using Study.Lab3.Web.Features.Cinema.Tickets.DtoModels;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace Study.Lab3.Web.Features.Cinema.Tickets.Commands;

/// <summary>
/// Покупка билета
/// </summary>
public sealed class BuyTicketCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные для покупки билета
    /// </summary>
    [Required]
    [FromBody]
    public BuyTicketDto Ticket { get; init; }
}

public sealed class BuyTicketCommandHandler : IRequestHandler<BuyTicketCommand, Guid>
{
    private readonly DataContext _dataContext;

    public BuyTicketCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(BuyTicketCommand request, CancellationToken cancellationToken)
    {
        // Проверка существования сеанса
        var session = await _dataContext.Sessions
                          .Include(s => s.Hall)
                          .FirstOrDefaultAsync(s => s.IsnSession == request.Ticket.IsnSession, cancellationToken)
                      ?? throw new BusinessLogicException(
                          $"Сеанс с идентификатором \"{request.Ticket.IsnSession}\" не существует");

        // Проверка существования места
        var seat = await _dataContext.Seats
                       .FirstOrDefaultAsync(s => s.IsnSeat == request.Ticket.IsnSeat, cancellationToken)
                   ?? throw new BusinessLogicException(
                       $"Место с идентификатором \"{request.Ticket.IsnSeat}\" не существует");

        // Проверка существования клиента
        var customer = await _dataContext.Customers
                           .FirstOrDefaultAsync(c => c.IsnCustomer == request.Ticket.IsnCustomer, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Клиент с идентификатором \"{request.Ticket.IsnCustomer}\" не существует");

        // Проверка, что место принадлежит залу этого сеанса
        if (seat.IsnHall != session.IsnHall)
            throw new BusinessLogicException("Выбранное место не принадлежит залу этого сеанса");

        // Проверка, что место активно
        if (!seat.IsActive)
            throw new BusinessLogicException("Выбранное место не активно");

        // Проверка, что сеанс активен и не начался
        if (!session.IsActive)
            throw new BusinessLogicException("Сеанс не активен");

        if (session.StartTime <= DateTime.UtcNow)
            throw new BusinessLogicException("Сеанс уже начался");

        // Проверка, что клиент активен
        if (!customer.IsActive)
            throw new BusinessLogicException("Клиент не активен");

        // Проверка, что место не занято
        var existingTicket = await _dataContext.Tickets
            .FirstOrDefaultAsync(
                t => t.IsnSession == request.Ticket.IsnSession && 
                     t.IsnSeat == request.Ticket.IsnSeat && 
                     t.Status == TicketStatus.Active, 
                cancellationToken);

        if (existingTicket != null)
            throw new BusinessLogicException("Это место уже занято");

        // Создание уникального кода билета
        string ticketCode = GenerateTicketCode(request.Ticket.IsnSession, request.Ticket.IsnSeat, request.Ticket.IsnCustomer);

        // Вычисление цены с учетом типа места
        decimal finalPrice = CalculateFinalPrice(session.BasePrice, seat.Type);

        // Создание билета
        var ticket = new Ticket
        {
            IsnTicket = Guid.NewGuid(),
            IsnSession = request.Ticket.IsnSession,
            IsnSeat = request.Ticket.IsnSeat,
            IsnCustomer = request.Ticket.IsnCustomer,
            Price = finalPrice,
            PurchaseDate = DateTime.UtcNow,
            Status = TicketStatus.Active,
            TicketCode = ticketCode
        };

        await _dataContext.Tickets.AddAsync(ticket, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
        
        return ticket.IsnTicket;
    }

    private string GenerateTicketCode(Guid sessionId, Guid seatId, Guid customerId)
    {
        string input = $"{sessionId}-{seatId}-{customerId}-{DateTime.UtcNow.Ticks}";
        using var md5 = MD5.Create();
        byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
        
        // Преобразуем байты в строку и берем первые 10 символов
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++)
        {
            sb.Append(hashBytes[i].ToString("X2"));
        }
        
        return sb.ToString().Substring(0, 10);
    }

    private decimal CalculateFinalPrice(decimal basePrice, SeatType seatType)
    {
        // Применяем наценку в зависимости от типа места
        return seatType switch
        {
            SeatType.Standard => basePrice,
            SeatType.VIP => basePrice * 1.5m,
            _ => basePrice
        };
    }
}