using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.BeautySalon;

namespace Study.Lab3.Logic.Interfaces.Services.BeautySalon;

public interface IBeautyClientService
{
    /// <summary>
    /// Проверка клиента на возможность создания/редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="beautyclient">Клиент салона</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateBeautyClientValidateAndThrowAsync(
        DataContext dataContext,
        BeautyClient beautyclient,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка клиента на возможность удаления
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="beautyclient">Клиент салона</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        BeautyClient beautyclient,
        CancellationToken cancellationToken = default);
}
