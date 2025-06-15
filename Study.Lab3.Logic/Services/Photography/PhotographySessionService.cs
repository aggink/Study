using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Photography;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Enums.Photography;
using Study.Lab3.Storage.Models.Photography;

namespace Study.Lab3.Logic.Services.Photography;

public sealed class PhotographySessionService : IPhotographySessionService
{
    public async Task CreateOrUpdateSessionValidateAndThrowAsync(
        DataContext dataContext,
        PhotographySession session,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(session.Title))
            throw new BusinessLogicException("Название фотосессии не может быть пустым");

        if (string.IsNullOrWhiteSpace(session.Location))
            throw new BusinessLogicException("Местоположение фотосессии не может быть пустым");

        if (string.IsNullOrWhiteSpace(session.PhotographerName))
            throw new BusinessLogicException("Имя фотографа не может быть пустым");

        // Проверка даты фотосессии
        if (session.SessionDate < DateTime.Now.AddMinutes(-30) && session.Status == PhotographySessionStatus.Scheduled)
            throw new BusinessLogicException("Нельзя запланировать фотосессию в прошлом времени");

        if (session.SessionDate > DateTime.Now.AddYears(2))
            throw new BusinessLogicException("Нельзя запланировать фотосессию более чем на 2 года вперед");

        // Проверка продолжительности
        if (session.Duration <= 0)
            throw new BusinessLogicException("Продолжительность фотосессии должна быть положительным числом");

        // Проверка стоимости
        if (session.Price <= 0)
            throw new BusinessLogicException("Стоимость фотосессии должна быть положительным числом");

        // Проверка количества фотографий
        if (session.PhotoCount.HasValue && session.PhotoCount.Value < 0)
            throw new BusinessLogicException("Количество фотографий не может быть отрицательным");

        // Проверка логичности статуса
        if (session.Status == PhotographySessionStatus.Completed && session.SessionDate > DateTime.Now)
            throw new BusinessLogicException("Нельзя отметить фотосессию как завершенную, если она еще не началась");

        if (session.Status == PhotographySessionStatus.InProgress && 
            (session.SessionDate > DateTime.Now.AddMinutes(30) || session.SessionDate.AddMinutes(session.Duration) < DateTime.Now.AddMinutes(-30)))
            throw new BusinessLogicException("Статус 'В процессе' можно установить только во время фотосессии");

        // Проверка уникальности фотографа в указанное время (фотограф не может проводить две фотосессии одновременно)
        var sessionEndTime = session.SessionDate.AddMinutes(session.Duration);
        if (await dataContext.PhotographySessions.AnyAsync(
                x => x.PhotographerName == session.PhotographerName &&
                     x.IsnPhotographySession != session.IsnPhotographySession &&
                     x.Status != PhotographySessionStatus.Cancelled &&
                     ((x.SessionDate <= session.SessionDate && x.SessionDate.AddMinutes(x.Duration) > session.SessionDate) ||
                      (x.SessionDate < sessionEndTime && x.SessionDate >= session.SessionDate)),
                cancellationToken))
            throw new BusinessLogicException($"Фотограф \"{session.PhotographerName}\" уже занят в указанное время");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        PhotographySession session,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.PhotographySessions.AnyAsync(
                x => x.IsnPhotographySession == session.IsnPhotographySession, cancellationToken))
            throw new BusinessLogicException(
                $"Фотосессия с идентификатором \"{session.IsnPhotographySession}\" не существует");

        // Проверка возможности удаления завершенных фотосессий
        if (session.Status == PhotographySessionStatus.Completed)
            throw new BusinessLogicException("Нельзя удалить завершенную фотосессию");

        // Проверка возможности удаления фотосессий в процессе
        if (session.Status == PhotographySessionStatus.InProgress)
            throw new BusinessLogicException("Нельзя удалить фотосессию, которая находится в процессе");
    }
}
