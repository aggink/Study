using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.GameStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.GameStore;

namespace Study.Lab3.Logic.Services.GameStore;

public sealed class PlatformService : IPlatformService
{
    public async Task CreateOrUpdatePlatformValidateAndThrowAsync(
        DataContext dataContext,
        Platform platform,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(platform.Name))
            throw new BusinessLogicException("Название платформы не может быть пустым");

        if (platform.Name.Length > 100)
            throw new BusinessLogicException("Название платформы не может превышать 100 символов");

        if (string.IsNullOrWhiteSpace(platform.Manufacturer))
            throw new BusinessLogicException("Производитель не может быть пустым");

        if (platform.Manufacturer.Length > 100)
            throw new BusinessLogicException("Название производителя не может превышать 100 символов");

        if (string.IsNullOrWhiteSpace(platform.Type))
            throw new BusinessLogicException("Тип платформы не может быть пустым");

        var validTypes = new[] { "Console", "PC", "Mobile", "Handheld", "VR", "Arcade" };
        if (!validTypes.Contains(platform.Type))
            throw new BusinessLogicException("Недопустимый тип платформы. Доступные: Console, PC, Mobile, Handheld, VR, Arcade");

        if (platform.ReleaseDate.HasValue)
        {
            if (platform.ReleaseDate.Value > DateTime.UtcNow.AddYears(5))
                throw new BusinessLogicException("Дата выхода платформы не может быть более чем через 5 лет");

            if (platform.ReleaseDate.Value < new DateTime(1970, 1, 1))
                throw new BusinessLogicException("Дата выхода платформы не может быть раньше 1970 года");
        }

        if (platform.Generation.HasValue)
        {
            if (platform.Generation.Value < 1 || platform.Generation.Value > 20)
                throw new BusinessLogicException("Поколение платформы должно быть от 1 до 20");
        }

        var existingPlatform = await dataContext.Platforms
            .FirstOrDefaultAsync(x => x.Name == platform.Name &&
                                      x.Manufacturer == platform.Manufacturer &&
                                      x.IsnPlatform != platform.IsnPlatform, cancellationToken);

        if (existingPlatform != null)
            throw new BusinessLogicException($"Платформа \"{platform.Name}\" от производителя \"{platform.Manufacturer}\" уже существует");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Platform platform,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Platforms.AnyAsync(x => x.IsnPlatform == platform.IsnPlatform, cancellationToken))
            throw new BusinessLogicException($"Платформа с идентификатором \"{platform.IsnPlatform}\" не существует");
    }
}
