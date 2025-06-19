using System.Text.RegularExpressions;
using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Photography;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Photography;

namespace Study.Lab3.Logic.Services.Photography;

public sealed class PhotographyClientService : IPhotographyClientService
{
    public async Task CreateOrUpdateClientValidateAndThrowAsync(
        DataContext dataContext,
        PhotographyClient client,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(client.FirstName))
            throw new BusinessLogicException("Имя клиента не может быть пустым");

        if (string.IsNullOrWhiteSpace(client.LastName))
            throw new BusinessLogicException("Фамилия клиента не может быть пустой");

        if (string.IsNullOrWhiteSpace(client.Phone))
            throw new BusinessLogicException("Телефон клиента не может быть пустым");

        if (string.IsNullOrWhiteSpace(client.Email))
            throw new BusinessLogicException("Email клиента не может быть пустым");

        // Валидация формата email
        if (!IsValidEmail(client.Email))
            throw new BusinessLogicException("Неверный формат email");

        // Валидация формата телефона
        if (!IsValidPhone(client.Phone))
            throw new BusinessLogicException("Неверный формат телефона");

        // Проверка уникальности email
        if (await dataContext.PhotographyClients.AnyAsync(
                x => x.Email == client.Email && x.IsnPhotographyClient != client.IsnPhotographyClient,
                cancellationToken))
            throw new BusinessLogicException($"Клиент с email \"{client.Email}\" уже существует");

        // Проверка уникальности телефона
        if (await dataContext.PhotographyClients.AnyAsync(
                x => x.Phone == client.Phone && x.IsnPhotographyClient != client.IsnPhotographyClient,
                cancellationToken))
            throw new BusinessLogicException($"Клиент с телефоном \"{client.Phone}\" уже существует");

        // Проверка даты рождения
        if (client.BirthDate.HasValue && client.BirthDate.Value > DateTime.Now.AddYears(-5))
            throw new BusinessLogicException("Возраст клиента должен быть не менее 5 лет");

        if (client.BirthDate.HasValue && client.BirthDate.Value < DateTime.Now.AddYears(-120))
            throw new BusinessLogicException("Возраст клиента не может превышать 120 лет");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        PhotographyClient client,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.PhotographyClients.AnyAsync(
                x => x.IsnPhotographyClient == client.IsnPhotographyClient, cancellationToken))
            throw new BusinessLogicException(
                $"Клиент с идентификатором \"{client.IsnPhotographyClient}\" не существует");
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
        return phone.All(c => char.IsDigit(c) || c == '+' || c == '-' || c == '(' || c == ')' || c == ' ')
               && phone.Any(char.IsDigit);
    }
}