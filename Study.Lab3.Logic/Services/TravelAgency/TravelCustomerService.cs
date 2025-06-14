using System.Text.RegularExpressions;
using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.TravelAgency;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.TravelAgency;

namespace Study.Lab3.Logic.Services.TravelAgency;

public sealed class TravelCustomerService : ITravelCustomerService
{
    public async Task CreateOrUpdateCustomerValidateAndThrowAsync(
        DataContext dataContext,
        TravelCustomer customer,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(customer.SurName))
            throw new BusinessLogicException("Фамилия не может быть пустой");

        if (string.IsNullOrWhiteSpace(customer.Name))
            throw new BusinessLogicException("Имя не может быть пустым");

        if (string.IsNullOrWhiteSpace(customer.PassportNumber))
            throw new BusinessLogicException("Номер паспорта не может быть пустым");

        if (string.IsNullOrWhiteSpace(customer.Phone))
            throw new BusinessLogicException("Телефон не может быть пустым");

        if (string.IsNullOrWhiteSpace(customer.Email))
            throw new BusinessLogicException("Email не может быть пустым");

        if (customer.DateOfBirth >= DateTime.Today)
            throw new BusinessLogicException("Дата рождения не может быть в будущем или сегодня");

        var age = DateTime.Today.Year - customer.DateOfBirth.Year;
        if (customer.DateOfBirth.Date > DateTime.Today.AddYears(-age)) age--;

        if (age < 18)
            throw new BusinessLogicException("Клиент должен быть совершеннолетним (не менее 18 лет)");

        if (age > 120)
            throw new BusinessLogicException("Некорректная дата рождения");

        if (!IsValidEmail(customer.Email))
            throw new BusinessLogicException("Некорректный формат email");

        if (!IsValidPhone(customer.Phone))
            throw new BusinessLogicException("Некорректный формат телефона");

        if (await dataContext.TravelCustomers.AnyAsync(
            x => x.PassportNumber == customer.PassportNumber &&
                 x.IsnCustomer != customer.IsnCustomer,
            cancellationToken))
            throw new BusinessLogicException("Клиент с таким номером паспорта уже существует");

        if (await dataContext.TravelCustomers.AnyAsync(
            x => x.Email == customer.Email &&
                 x.IsnCustomer != customer.IsnCustomer,
            cancellationToken))
            throw new BusinessLogicException("Клиент с таким email уже существует");

        if (await dataContext.TravelCustomers.AnyAsync(
            x => x.Phone == customer.Phone &&
                 x.IsnCustomer != customer.IsnCustomer,
            cancellationToken))
            throw new BusinessLogicException("Клиент с таким телефоном уже существует");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        TravelCustomer customer,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.TravelCustomers.AnyAsync(x => x.IsnCustomer == customer.IsnCustomer, cancellationToken))
            throw new BusinessLogicException($"Клиент с идентификатором \"{customer.IsnCustomer}\" не существует");
    }

    private static bool IsValidEmail(string email)
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

    private static bool IsValidPhone(string phone)
    {
        return Regex.IsMatch(phone, @"^[\d\s\(\)\-\+]+$");
    }
}
