using Study.Lab3.Storage.Models.Cinema;
using Study.Lab3.Storage.Enums.Cinema;

namespace Study.Lab3.Logic.Extensions.Cinema;

/// <summary>
/// Расширения для модели <see cref="Customer"/>
/// </summary>
public static class CustomerExtensions
{
    /// <summary>
    /// Получить полное имя клиента
    /// </summary>
    /// <param name="customer">Клиент</param>
    /// <returns>Полное имя клиента</returns>
    public static string GetFullName(this Customer customer)
    {
        return $"{customer.FirstName} {customer.LastName}".Trim();
    }

    /// <summary>
    /// Получить возраст клиента
    /// </summary>
    /// <param name="customer">Клиент</param>
    /// <returns>Возраст или null, если дата рождения не указана</returns>
    public static int? GetAge(this Customer customer)
    {
        if (!customer.BirthDate.HasValue)
            return null;

        var today = DateTime.Today;
        var age = today.Year - customer.BirthDate.Value.Year;
        
        if (customer.BirthDate.Value.Date > today.AddYears(-age))
            age--;

        return age;
    }

    /// <summary>
    /// Проверить, может ли клиент смотреть фильм с учетом возрастного рейтинга
    /// </summary>
    /// <param name="customer">Клиент</param>
    /// <param name="ageRating">Возрастной рейтинг фильма</param>
    /// <returns>True, если клиент может смотреть фильм</returns>
    public static bool CanWatchMovie(this Customer customer, int ageRating)
    {
        var age = customer.GetAge();
        
        // Если возраст не указан, предполагаем, что это взрослый
        if (!age.HasValue)
            return true;

        return age.Value >= ageRating;
    }

    /// <summary>
    /// Получить количество активных билетов клиента
    /// </summary>
    /// <param name="customer">Клиент</param>
    /// <returns>Количество активных билетов</returns>
    public static int GetActiveTicketsCount(this Customer customer)
    {
        if (customer.Tickets == null)
            return 0;

        return customer.Tickets.Count(t => t.Status == TicketStatus.Active);
    }

    /// <summary>
    /// Получить общую сумму покупок клиента
    /// </summary>
    /// <param name="customer">Клиент</param>
    /// <returns>Общая сумма покупок</returns>
    public static decimal GetTotalPurchaseAmount(this Customer customer)
    {
        if (customer.Tickets == null)
            return 0;

        return customer.Tickets
            .Where(t => t.Status != TicketStatus.Cancelled)
            .Sum(t => t.Price);
    }
}