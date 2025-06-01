using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Enums.Cinema;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Tickets.Commands;

/// <summary>
/// Отмена билета
/// </summary>
public sealed class CancelTicketCommand : IRequest
{
    /// <summary>
    /// Идентификатор билета
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnTicket { get; init; }
}

public sealed class CancelTicketCommandHandler : IRequestHandler<CancelTicketCommand>
{
    private readonly DataContext _dataContext;

    public CancelTicketCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(CancelTicketCommand request, CancellationToken cancellationToken)
    {
        // Получение билета
        var ticket = await _dataContext.Tickets
                         .Include(t => t.Session)
                         .FirstOrDefaultAsync(t => t.IsnTicket == request.IsnTicket, cancellationToken)
                     ?? throw new BusinessLogicException(
                         $"Билет с идентификатором \"{request.IsnTicket}\" не существует");

        // Проверка, что билет активен
        if (ticket.Status != TicketStatus.Active)
            throw new BusinessLogicException("Можно отменить только активный билет");

        // Проверка, что сеанс не начался
        if (ticket.Session.StartTime <= DateTime.UtcNow)
            throw new BusinessLogicException("Нельзя отменить билет на начавшийся сеанс");

        // Отмена билета
        ticket.Status = TicketStatus.Cancelled;
        
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}