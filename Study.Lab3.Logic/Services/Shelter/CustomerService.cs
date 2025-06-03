using System.Text.RegularExpressions;
using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Shelter;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Shelter;

namespace Study.Lab3.Logic.Services.Shelter;

public sealed class CustomerService : ICustomerService
{
    public async Task CreateOrUpdateCustomerValidateAndThrowAsync(
        DataContext dataContext,
        Customer customer,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(customer.Name))
            throw new BusinessLogicException("Имя клиента не может быть пустым");

        if (string.IsNullOrWhiteSpace(customer.LastName))
            throw new BusinessLogicException("Фамилия клиента не может быть пустой");

        if (string.IsNullOrWhiteSpace(customer.Email))
            throw new BusinessLogicException("Email не может быть пустым");

        // Проверка формата email
        if (!IsValidEmail(customer.Email))
            throw new BusinessLogicException("Неверный формат email");

        // Проверка на уникальность email
        if (await dataContext.ShelterCustomers.AnyAsync(
            x => x.Email == customer.Email && x.IsnCustomer != customer.IsnCustomer,
            cancellationToken))
        {
            throw new BusinessLogicException($"Клиент с email \"{customer.Email}\" уже существует");
        }

        // Проверка телефона
        if (!string.IsNullOrWhiteSpace(customer.PhoneNumber))
        {
            var phoneRegex = new Regex(@"^[\+]?[(]?[0-9]{1,3}[)]?[-\s\.]?[(]?[0-9]{1,3}[)]?[-\s\.]?[0-9]{4,6}$");
            if (!phoneRegex.IsMatch(customer.PhoneNumber))
                throw new BusinessLogicException("Неверный формат телефона");
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Customer customer,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.ShelterCustomers.AnyAsync(x => x.IsnCustomer == customer.IsnCustomer, cancellationToken))
            throw new BusinessLogicException(
                $"Клиент с идентификатором \"{customer.IsnCustomer}\" не существует");
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