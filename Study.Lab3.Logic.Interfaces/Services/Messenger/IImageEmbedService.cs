using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Messenger;

namespace Study.Lab3.Logic.Interfaces.Services.Messenger;

public interface IImageEmbedService
{
    /// <summary>
    /// Проверка модели вложения на возможность создания
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="embed">Вложение</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateImageEmbedValidateAndThrowAsync(
        DataContext dataContext,
        ImageEmbed embed,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка модели вложения на возможность редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="embed">Вложение</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task UpdateImageEmbedValidateAndThrowAsync(
        DataContext dataContext,
        ImageEmbed embed,
        CancellationToken cancellationToken = default);
}
