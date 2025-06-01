using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.BeautySalon;

namespace Study.Lab3.Logic.Interfaces.Services.BeautySalon;

public interface IBeautyClientsService
{
    /// <summary>
    /// Проверка клиента на возможность создания/редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="beautyclient">Клиент салона</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateBeautyClientValidate(
        DataContext dataContext,
        BeautyClients beautyclient,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка клиента на возможность удаления
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="beautyclient">Клиент салона</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task DeleteBeautyClientValidate(
        DataContext dataContext,
        BeautyClients beautyclient,
        CancellationToken cancellationToken = default);
}
