using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.GameStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.GameStore;

namespace Study.Lab3.Logic.Services.GameStore;

public sealed class DeveloperService : IDeveloperService
{
    public async Task CreateOrUpdateDeveloperValidateAndThrowAsync(
        DataContext dataContext,
        Developer developer,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(developer.CompanyName))
            throw new BusinessLogicException("Название компании не может быть пустым");

        if (developer.CompanyName.Length > 150)
            throw new BusinessLogicException("Название компании не может превышать 150 символов");

        if (string.IsNullOrWhiteSpace(developer.Country))
            throw new BusinessLogicException("Страна не может быть пустой");

        if (developer.Country.Length > 100)
            throw new BusinessLogicException("Название страны не может превышать 100 символов");

        if (developer.FoundedDate.HasValue)
        {
            if (developer.FoundedDate.Value > DateTime.UtcNow)
                throw new BusinessLogicException("Дата основания не может быть в будущем");

            if (developer.FoundedDate.Value < new DateTime(1900, 1, 1))
                throw new BusinessLogicException("Дата основания не может быть раньше 1900 года");
        }

        if (!string.IsNullOrWhiteSpace(developer.ContactEmail))
        {
            if (developer.ContactEmail.Length > 100)
                throw new BusinessLogicException("Email не может превышать 100 символов");

            if (!IsValidEmail(developer.ContactEmail))
                throw new BusinessLogicException("Некорректный формат email");
        }

        if (!string.IsNullOrWhiteSpace(developer.Website))
        {
            if (developer.Website.Length > 200)
                throw new BusinessLogicException("URL веб-сайта не может превышать 200 символов");

            if (!IsValidUrl(developer.Website))
                throw new BusinessLogicException("Некорректный формат URL веб-сайта");
        }

        var existingDeveloper = await dataContext.Developers
            .FirstOrDefaultAsync(x => x.CompanyName == developer.CompanyName && x.IsnDeveloper != developer.IsnDeveloper, cancellationToken);

        if (existingDeveloper != null)
            throw new BusinessLogicException($"Разработчик с названием \"{developer.CompanyName}\" уже существует");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Developer developer,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Developers.AnyAsync(x => x.IsnDeveloper == developer.IsnDeveloper, cancellationToken))
            throw new BusinessLogicException($"Разработчик с идентификатором \"{developer.IsnDeveloper}\" не существует");

        if (await dataContext.Games.AnyAsync(x => x.IsnDeveloper == developer.IsnDeveloper, cancellationToken))
            throw new BusinessLogicException("Невозможно удалить разработчика, так как у него есть игры");
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

    private static bool IsValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out var uriResult) &&
               (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}
