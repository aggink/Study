using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Cinema;

namespace Study.Lab3.Logic.Interfaces.Services.Cinema;

public interface ITicketService
{
    /// <summary>
    /// Проверка модели билета на возможность создания
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="ticket">Билет</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateTicketValidateAndThrowAsync(
        DataContext dataContext,
        Ticket ticket,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности отмены билета
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="ticket">Билет</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanCancelAndThrowAsync(
        DataContext dataContext,
        Ticket ticket,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Расчет цены билета с учетом типа места
    /// </summary>
    /// <param name="basePrice">Базовая цена</param>
    /// <param name="seat">Место</param>
    /// <returns>Итоговая цена</returns>
    decimal CalculateTicketPrice(decimal basePrice, Seat seat);

    /// <summary>
    /// Генерация уникального кода билета
    /// </summary>
    /// <returns>Код билета</returns>
    string GenerateTicketCode();
}