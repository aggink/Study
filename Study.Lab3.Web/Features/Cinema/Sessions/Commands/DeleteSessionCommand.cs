using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Enums.Cinema;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Sessions.Commands;

/// <summary>
/// Удаление сеанса
/// </summary>
public sealed class DeleteSessionCommand : IRequest
{
    /// <summary>
    /// Идентификатор сеанса
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnSession { get; init; }
}

public sealed class DeleteSessionCommandHandler : IRequestHandler<DeleteSessionCommand>
{
    private readonly DataContext _dataContext;

    public DeleteSessionCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(DeleteSessionCommand request, CancellationToken cancellationToken)
    {
        // Получение сеанса
        var session = await _dataContext.Sessions
                          .Include(x => x.Tickets)
                          .FirstOrDefaultAsync(x => x.IsnSession == request.IsnSession, cancellationToken)
                      ?? throw new BusinessLogicException(
                          $"Сеанс с идентификатором \"{request.IsnSession}\" не существует");

        // Проверка, что у сеанса нет проданных билетов
        if (session.Tickets.Any(t => t.Status != TicketStatus.Cancelled))
            throw new BusinessLogicException("Нельзя удалить сеанс, на который уже проданы билеты");

        // Проверка, что сеанс не начался
        if (session.StartTime <= DateTime.UtcNow)
            throw new BusinessLogicException("Нельзя удалить начавшийся сеанс");

        // Удаление всех билетов на сеанс
        _dataContext.Tickets.RemoveRange(session.Tickets);

        // Удаление сеанса
        _dataContext.Sessions.Remove(session);

        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}