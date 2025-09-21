using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Museum;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Museum;

namespace Study.Lab3.Logic.Services.Museum;

public sealed class MuseumVisitorService : IMuseumVisitorService
{
    public async Task CreateOrUpdateVisitorValidateAndThrowAsync(
        DataContext dataContext,
        MuseumVisitor visitor,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(visitor.FirstName))
            throw new BusinessLogicException("Имя посетителя не может быть пустым");

        if (string.IsNullOrWhiteSpace(visitor.LastName))
            throw new BusinessLogicException("Фамилия посетителя не может быть пустой");

        if (string.IsNullOrWhiteSpace(visitor.TicketType))
            throw new BusinessLogicException("Тип билета не может быть пустым");

        // Проверка корректности типа билета
        var validTicketTypes = new[] { "Взрослый", "Детский", "Студенческий", "Пенсионный", "Групповой", "VIP" };
        if (!validTicketTypes.Contains(visitor.TicketType))
            throw new BusinessLogicException($"Недопустимый тип билета. Допустимые типы: {string.Join(", ", validTicketTypes)}");

        // Проверка стоимости билета
        if (visitor.TicketPrice < 0)
            throw new BusinessLogicException("Стоимость билета не может быть отрицательной");

        // Проверка даты рождения
        if (visitor.DateOfBirth.HasValue)
        {
            if (visitor.DateOfBirth.Value > DateTime.UtcNow)
                throw new BusinessLogicException("Дата рождения не может быть в будущем");

            var age = DateTime.UtcNow.Year - visitor.DateOfBirth.Value.Year;
            if (visitor.DateOfBirth.Value.Date > DateTime.UtcNow.AddYears(-age)) age--;

            if (age < 0 || age > 150)
                throw new BusinessLogicException("Некорректный возраст посетителя");

            // Проверка соответствия типа билета возрасту
            if (visitor.TicketType == "Детский" && age >= 18)
                throw new BusinessLogicException("Детский билет доступен только для лиц младше 18 лет");

            if (visitor.TicketType == "Пенсионный" && age < 60)
                throw new BusinessLogicException("Пенсионный билет доступен только для лиц старше 60 лет");
        }

        // Проверка даты посещения
        if (visitor.VisitDate.Date > DateTime.UtcNow.Date.AddDays(30))
            throw new BusinessLogicException("Дата посещения не может быть больше чем на 30 дней вперед");

        // Проверка членского билета
        if (visitor.IsMember && string.IsNullOrWhiteSpace(visitor.MembershipNumber))
            throw new BusinessLogicException("Для члена музея необходимо указать номер членского билета");

        if (!visitor.IsMember && !string.IsNullOrWhiteSpace(visitor.MembershipNumber))
            throw new BusinessLogicException("Номер членского билета может быть указан только для членов музея");

        // Проверка уникальности номера членского билета
        if (!string.IsNullOrWhiteSpace(visitor.MembershipNumber))
        {
            if (await dataContext.MuseumVisitors.AnyAsync(
                x => x.MembershipNumber == visitor.MembershipNumber && 
                     x.IsnMuseumVisitor != visitor.IsnMuseumVisitor,
                cancellationToken))
                throw new BusinessLogicException($"Членский билет с номером \"{visitor.MembershipNumber}\" уже зарегистрирован");
        }

        // Проверка email на уникальность для членов музея
        if (visitor.IsMember && !string.IsNullOrWhiteSpace(visitor.Email))
        {
            if (await dataContext.MuseumVisitors.AnyAsync(
                x => x.Email == visitor.Email && 
                     x.IsMember && 
                     x.IsnMuseumVisitor != visitor.IsnMuseumVisitor,
                cancellationToken))
                throw new BusinessLogicException($"Email \"{visitor.Email}\" уже используется другим членом музея");
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        MuseumVisitor visitor,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.MuseumVisitors.AnyAsync(x => x.IsnMuseumVisitor == visitor.IsnMuseumVisitor, cancellationToken))
            throw new BusinessLogicException($"Посетитель с идентификатором \"{visitor.IsnMuseumVisitor}\" не существует");

        // Проверка даты посещения - нельзя удалять записи о посещениях старше 3 лет (для отчетности)
        if (visitor.VisitDate < DateTime.UtcNow.AddYears(-3))
            throw new BusinessLogicException("Невозможно удалить запись о посещении старше 3 лет");

        // Нельзя удалять активных членов музея
        if (visitor.IsMember)
            throw new BusinessLogicException("Невозможно удалить запись активного члена музея");
    }
}
