using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Cinema;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Cinema;

namespace Study.Lab3.Logic.Services.Cinema;

public sealed class SessionService : ISessionService
{
    public async Task CreateOrUpdateSessionValidateAndThrowAsync(
        DataContext dataContext,
        Session session,
        CancellationToken cancellationToken = default)
    {
        // Проверка существования фильма
        var movie = await dataContext.Movies
            .FirstOrDefaultAsync(x => x.IsnMovie == session.IsnMovie, cancellationToken)
            ?? throw new BusinessLogicException(
                $"Фильм с идентификатором \"{session.IsnMovie}\" не существует");

        // Проверка существования зала
        if (!await dataContext.Halls.AnyAsync(x => x.IsnHall == session.IsnHall, cancellationToken))
            throw new BusinessLogicException(
                $"Зал с идентификатором \"{session.IsnHall}\" не существует");

        // Проверка времени сеанса
        if (session.StartTime < DateTime.UtcNow)
            throw new BusinessLogicException("Нельзя создать сеанс в прошлом");

        // Расчет времени окончания сеанса
        session.EndTime = session.StartTime.AddMinutes(movie.Duration + 15); // +15 минут на рекламу и уборку

        // Проверка базовой цены
        if (session.BasePrice <= 0)
            throw new BusinessLogicException("Базовая цена билета должна быть больше нуля");

        // Проверка на пересечение сеансов
        if (await CheckSessionOverlapAsync(dataContext, session, cancellationToken))
            throw new BusinessLogicException(
                "В это время в данном зале уже запланирован другой сеанс");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Session session,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Sessions.AnyAsync(x => x.IsnSession == session.IsnSession, cancellationToken))
            throw new BusinessLogicException(
                $"Сеанс с идентификатором \"{session.IsnSession}\" не существует");

        // Нельзя удалить прошедший сеанс
        if (session.StartTime < DateTime.UtcNow)
            throw new BusinessLogicException("Невозможно удалить прошедший сеанс");

        // Проверка на наличие проданных билетов
        if (await dataContext.Tickets.AnyAsync(x => x.IsnSession == session.IsnSession, cancellationToken))
            throw new BusinessLogicException(
                "Невозможно удалить сеанс, так как на него проданы билеты");
    }

    public async Task<bool> CheckSessionOverlapAsync(
        DataContext dataContext,
        Session session,
        CancellationToken cancellationToken = default)
    {
        return await dataContext.Sessions
            .AnyAsync(x => x.IsnHall == session.IsnHall &&
                          x.IsnSession != session.IsnSession &&
                          x.IsActive &&
                          ((x.StartTime <= session.StartTime && x.EndTime > session.StartTime) ||
                           (x.StartTime < session.EndTime && x.EndTime >= session.EndTime) ||
                           (x.StartTime >= session.StartTime && x.EndTime <= session.EndTime)),
                      cancellationToken);
    }
}