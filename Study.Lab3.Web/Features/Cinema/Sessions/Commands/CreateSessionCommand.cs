using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Cinema;
using Study.Lab3.Web.Features.Cinema.Sessions.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Cinema.Sessions.Commands;

/// <summary>
/// Создание сеанса
/// </summary>
public sealed class CreateSessionCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные сеанса
    /// </summary>
    [Required]
    [FromBody]
    public CreateSessionDto Session { get; init; }
}

public sealed class CreateSessionCommandHandler : IRequestHandler<CreateSessionCommand, Guid>
{
    private readonly DataContext _dataContext;

    public CreateSessionCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
    {
        // Проверка существования фильма
        var movie = await _dataContext.Movies
                        .FirstOrDefaultAsync(x => x.IsnMovie == request.Session.IsnMovie, cancellationToken)
                    ?? throw new BusinessLogicException(
                        $"Фильм с идентификатором \"{request.Session.IsnMovie}\" не существует");

        // Проверка существования зала
        var hall = await _dataContext.Halls
                       .FirstOrDefaultAsync(x => x.IsnHall == request.Session.IsnHall, cancellationToken)
                   ?? throw new BusinessLogicException(
                       $"Зал с идентификатором \"{request.Session.IsnHall}\" не существует");

        // Проверка активности фильма и зала
        if (!movie.IsActive)
            throw new BusinessLogicException("Нельзя создать сеанс для неактивного фильма");

        if (!hall.IsActive)
            throw new BusinessLogicException("Нельзя создать сеанс для неактивного зала");

        // Вычисление времени окончания сеанса
        var endTime = request.Session.StartTime.AddMinutes(movie.Duration);

        // Проверка, что сеанс не пересекается с другими сеансами в этом зале
        var overlappingSessions = await _dataContext.Sessions
            .Where(s => s.IsnHall == request.Session.IsnHall)
            .Where(s => 
                (s.StartTime <= request.Session.StartTime && s.EndTime > request.Session.StartTime) ||
                (s.StartTime < endTime && s.EndTime >= endTime) ||
                (s.StartTime >= request.Session.StartTime && s.EndTime <= endTime))
            .ToListAsync(cancellationToken);

        if (overlappingSessions.Any())
            throw new BusinessLogicException("Сеанс пересекается с другими сеансами в этом зале");

        // Проверка, что время начала сеанса не в прошлом
        if (request.Session.StartTime < DateTime.UtcNow)
            throw new BusinessLogicException("Нельзя создать сеанс в прошлом");

        // Создание сеанса
        var session = new Session
        {
            IsnSession = Guid.NewGuid(),
            IsnMovie = request.Session.IsnMovie,
            IsnHall = request.Session.IsnHall,
            StartTime = request.Session.StartTime,
            EndTime = endTime,
            BasePrice = request.Session.BasePrice,
            IsActive = true,
            Tickets = new List<Ticket>()
        };

        await _dataContext.Sessions.AddAsync(session, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return session.IsnSession;
    }
}