using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Enums.Cinema;
using Study.Lab3.Web.Features.Cinema.Sessions.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Sessions.Commands;

/// <summary>
/// Обновление сеанса
/// </summary>
public sealed class UpdateSessionCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные сеанса
    /// </summary>
    [Required]
    [FromBody]
    public UpdateSessionDto Session { get; init; }
}

public sealed class UpdateSessionCommandHandler : IRequestHandler<UpdateSessionCommand, Guid>
{
    private readonly DataContext _dataContext;

    public UpdateSessionCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(UpdateSessionCommand request, CancellationToken cancellationToken)
    {
        // Получение сеанса
        var session = await _dataContext.Sessions
                          .Include(x => x.Movie)
                          .Include(x => x.Tickets)
                          .FirstOrDefaultAsync(x => x.IsnSession == request.Session.IsnSession, cancellationToken)
                      ?? throw new BusinessLogicException(
                          $"Сеанс с идентификатором \"{request.Session.IsnSession}\" не существует");

        // Проверка, что у сеанса нет проданных билетов
        if (session.Tickets.Any(t => t.Status != TicketStatus.Cancelled))
            throw new BusinessLogicException("Нельзя изменить сеанс, на который уже проданы билеты");

        // Проверка, что сеанс не начался
        if (session.StartTime <= DateTime.UtcNow)
            throw new BusinessLogicException("Нельзя изменить начавшийся сеанс");

        // Вычисление времени окончания сеанса
        var endTime = request.Session.StartTime.AddMinutes(session.Movie.Duration);

        // Проверка, что сеанс не пересекается с другими сеансами в этом зале
        var overlappingSessions = await _dataContext.Sessions
            .Where(s => s.IsnHall == session.IsnHall && s.IsnSession != session.IsnSession)
            .Where(s => 
                (s.StartTime <= request.Session.StartTime && s.EndTime > request.Session.StartTime) ||
                (s.StartTime < endTime && s.EndTime >= endTime) ||
                (s.StartTime >= request.Session.StartTime && s.EndTime <= endTime))
            .ToListAsync(cancellationToken);

        if (overlappingSessions.Any())
            throw new BusinessLogicException("Сеанс пересекается с другими сеансами в этом зале");

        // Обновление сеанса
        session.StartTime = request.Session.StartTime;
        session.EndTime = endTime;
        session.BasePrice = request.Session.BasePrice;
        session.IsActive = request.Session.IsActive;

        await _dataContext.SaveChangesAsync(cancellationToken);
        return session.IsnSession;
    }
}