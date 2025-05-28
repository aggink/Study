using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Cinema;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Cinema;
using System.Text.RegularExpressions;

namespace Study.Lab3.Logic.Services.Cinema;

public sealed class CustomerService : ICustomerService
{
    public async Task CreateOrUpdateCustomerValidateAndThrowAsync(
        DataContext dataContext,
        Customer customer,
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
        if (await dataContext.Customers.AnyAsync(
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
        }

        // Установка даты регистрации для новых клиентов
        if (customer.IsnCustomer == Guid.Empty)
        {
            customer.RegistrationDate = DateTime.UtcNow;
            customer.IsActive = true;
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Customer customer,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Customers.AnyAsync(x => x.IsnCustomer == customer.IsnCustomer, cancellationToken))
            throw new BusinessLogicException(
                $"Клиент с идентификатором \"{customer.IsnCustomer}\" не существует");

        // Проверка на наличие билетов
        if (await dataContext.Tickets.AnyAsync(x => x.IsnCustomer == customer.IsnCustomer, cancellationToken))
            throw new BusinessLogicException(
                "Невозможно удалить клиента, так как у него есть история покупок");
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