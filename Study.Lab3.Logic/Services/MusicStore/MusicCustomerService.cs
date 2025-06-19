using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.MusicStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.MusicStore;

namespace Study.Lab3.Logic.Services.MusicStore;

public sealed class MusicCustomerService : IMusicCustomerService
{
    public async Task CreateOrUpdateCustomerValidateAndThrowAsync(
        DataContext dataContext,
        MusicCustomer customer,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(customer.FirstName))
            throw new BusinessLogicException("Имя покупателя не может быть пустым");

        if (string.IsNullOrWhiteSpace(customer.LastName))
            throw new BusinessLogicException("Фамилия покупателя не может быть пустой");

        if (string.IsNullOrWhiteSpace(customer.Email))
            throw new BusinessLogicException("Email покупателя не может быть пустым");

        if (!IsValidEmail(customer.Email))
            throw new BusinessLogicException("Некорректный формат email адреса");

        if (customer.BirthDate.HasValue && customer.BirthDate.Value > DateTime.Now)
            throw new BusinessLogicException("Дата рождения не может быть в будущем");

        if (customer.BirthDate.HasValue && customer.BirthDate.Value < DateTime.Now.AddYears(-120))
            throw new BusinessLogicException("Некорректная дата рождения");

        if (await dataContext.MusicCustomers.AnyAsync(
                x => x.Email == customer.Email &&
                     x.IsnCustomer != customer.IsnCustomer,
                cancellationToken))
            throw new BusinessLogicException($"Покупатель с email \"{customer.Email}\" уже существует");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        MusicCustomer customer,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.MusicCustomers.AnyAsync(x => x.IsnCustomer == customer.IsnCustomer, cancellationToken))
            throw new BusinessLogicException($"Покупатель с идентификатором \"{customer.IsnCustomer}\" не существует");
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
}
