using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Enums.Cinema;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Tickets.Commands;

/// <summary>
/// Использование билета (отметка о посещении)
/// </summary>
public sealed class UseTicketCommand : IRequest
{
    /// <summary>
    /// Код билета
    /// </summary>
    [Required]
    [FromQuery]
    public string TicketCode { get; init; }
}

public sealed class UseTicketCommandHandler : IRequestHandler<UseTicketCommand>
{
    private readonly DataContext _dataContext;

    public UseTicketCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(UseTicketCommand request, CancellationToken cancellationToken)
    {
        // Поиск билета по коду
        var ticket = await _dataContext.Tickets
                         .Include(t => t.Session)
                         .FirstOrDefaultAsync(t => t.TicketCode == request.TicketCode, cancellationToken)
                     ?? throw new BusinessLogicException(
                         $"Билет с кодом \"{request.TicketCode}\" не существует");

        // Проверка, что билет активен
        if (ticket.Status != TicketStatus.Active)
            throw new BusinessLogicException("Можно использовать только активный билет");

        // Проверка, что сеанс не закончился
        if (ticket.Session.EndTime < DateTime.UtcNow)
            throw new BusinessLogicException("Сеанс уже закончился");

        // Отметка билета как использованного
        ticket.Status = TicketStatus.Used;

        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}