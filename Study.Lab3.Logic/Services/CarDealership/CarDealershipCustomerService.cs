using System.Text.RegularExpressions;
using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CarDealership;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.CarDealership;

namespace Study.Lab3.Logic.Services.CarDealership;

/// <summary>
/// Сервис для работы с клиентами автосалона
/// </summary>
public sealed class CarDealershipCustomerService : ICarDealershipCustomerService
{
    public async Task CreateOrUpdateCustomerValidateAndThrowAsync(
        DataContext dataContext,
        CarDealershipCustomer customer,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(customer.FirstName))
            throw new BusinessLogicException("Имя клиента не может быть пустым");

        if (string.IsNullOrWhiteSpace(customer.LastName))
            throw new BusinessLogicException("Фамилия клиента не может быть пустой");

        if (string.IsNullOrWhiteSpace(customer.Email))
            throw new BusinessLogicException("Email не может быть пустым");

        // Проверка формата email
        if (!IsValidEmail(customer.Email))
            throw new BusinessLogicException("Неверный формат email");

        // Проверка на уникальность email
        if (await dataContext.CarDealershipCustomers.AnyAsync(
            x => x.Email == customer.Email && x.IsnCustomer != customer.IsnCustomer,
            cancellationToken))
        {
            throw new BusinessLogicException($"Клиент с email \"{customer.Email}\" уже существует");
        }

        // Проверка телефона
        if (!string.IsNullOrWhiteSpace(customer.Phone))
        {
            var phoneRegex = new Regex(@"^[\+]?[(]?[0-9]{1,3}[)]?[-\s\.]?[(]?[0-9]{1,3}[)]?[-\s\.]?[0-9]{4,6}$");
            if (!phoneRegex.IsMatch(customer.Phone))
                throw new BusinessLogicException("Неверный формат телефона");
        }

        // Проверка номера паспорта
        if (string.IsNullOrWhiteSpace(customer.PassportNumber))
            throw new BusinessLogicException("Номер паспорта не может быть пустым");

        // Проверка на уникальность номера паспорта
        if (await dataContext.CarDealershipCustomers.AnyAsync(
            x => x.PassportNumber == customer.PassportNumber && x.IsnCustomer != customer.IsnCustomer,
            cancellationToken))
        {
            throw new BusinessLogicException($"Клиент с номером паспорта \"{customer.PassportNumber}\" уже существует");
        }

        // Проверка даты рождения
        if (customer.BirthDate.HasValue)
        {
            if (customer.BirthDate.Value > DateTime.Today)
                throw new BusinessLogicException("Дата рождения не может быть в будущем");

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            if (customer.BirthDate.Value.Date > DateTime.Today.AddYears(-age))
                age--;

            if (age > 120)
                throw new BusinessLogicException("Некорректная дата рождения");
            
            if (age < 18)
                throw new BusinessLogicException("Возраст клиента должен быть не менее 18 лет");
        }

        // Установка даты регистрации для новых клиентов
        if (customer.IsnCustomer == Guid.Empty)
        {
            customer.RegistrationDate = DateTime.UtcNow;
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        CarDealershipCustomer customer,
        CancellationToken cancellationToken = default)
    {
        if (await dataContext.CarDealershipSales.AnyAsync(x => x.IsnCustomer == customer.IsnCustomer, cancellationToken))
            throw new BusinessLogicException("Нельзя удалить клиента, который имеет связанные продажи");
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}