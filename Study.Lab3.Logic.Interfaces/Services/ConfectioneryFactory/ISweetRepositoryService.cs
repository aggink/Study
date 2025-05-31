using Study.Lab3.Storage.Models.Cinema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab3.Logic.Interfaces.Services.ConfectioneryFactory
{
    public interface ISweetRepositoryService
    {
        /// <summary>
        /// Получает сладость по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сладости</param>
        /// <returns>Найденная сладость или null, если не найдена</returns>
        Task<Sweet> GetByIdAsync(int id);

        /// <summary>
        /// Получает все сладости
        /// </summary>
        /// <returns>Коллекция всех сладостей</returns>
        Task<IEnumerable<Sweet>> GetAllAsync();

        /// <summary>
        /// Добавляет новую сладость
        /// </summary>
        /// <param name="sweet">Добавляемая сладость</param>
        /// <exception cref="ArgumentNullException">Если сладость равна null</exception>
        Task AddAsync(Sweet sweet);

        /// <summary>
        /// Обновляет существующую сладость
        /// </summary>
        /// <param name="sweet">Обновляемая сладость</param>
        /// <exception cref="ArgumentNullException">Если сладость равна null</exception>
        /// <exception cref="KeyNotFoundException">Если сладость не найдена</exception>
        Task UpdateAsync(Sweet sweet);

        /// <summary>
        /// Удаляет сладость по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор удаляемой сладости</param>
        /// <exception cref="KeyNotFoundException">Если сладость не найдена</exception>
        Task DeleteAsync(int id);

        /// <summary>
        /// Получает сладости по категории
        /// </summary>
        /// <param name="categoryId">Идентификатор категории</param>
        /// <returns>Коллекция сладостей в указанной категории</returns>
        Task<IEnumerable<Sweet>> GetByCategoryAsync(int categoryId);

        /// <summary>
        /// Получает сладости по производителю
        /// </summary>
        /// <param name="manufacturerId">Идентификатор производителя</param>
        /// <returns>Коллекция сладостей указанного производителя</returns>
        Task<IEnumerable<Sweet>> GetByManufacturerAsync(int manufacturerId);

        /// <summary>
        /// Находит сладости по списку ингредиентов
        /// </summary>
        /// <param name="ingredientIds">Список идентификаторов ингредиентов</param>
        /// <returns>Коллекция сладостей, содержащих указанные ингредиенты</returns>
        /// <exception cref="ArgumentNullException">Если список ингредиентов равен null</exception>
        Task<IEnumerable<Sweet>> FindByIngredientsAsync(IEnumerable<int> ingredientIds);

        /// <summary>
        /// Получает сладости с истекающим сроком годности
        /// </summary>
        /// <param name="daysThreshold">Количество дней до истечения срока</param>
        /// <returns>Коллекция сладостей с истекающим сроком</returns>
        Task<IEnumerable<Sweet>> GetExpiringSoonAsync(int daysThreshold);

        /// <summary>
        /// Получает сладость по идентификатору с информацией об ингредиентах
        /// </summary>
        /// <param name="id">Идентификатор сладости</param>
        /// <returns>Сладость с заполненной коллекцией ингредиентов</returns>
        Task<Sweet> GetByIdWithIngredientsAsync(int id);

        /// <summary>
        /// Получает сладость по идентификатору с информацией о категории и производителе
        /// </summary>
        /// <param name="id">Идентификатор сладости</param>
        /// <returns>Сладость с заполненными данными о категории и производителе</returns>
        Task<Sweet> GetByIdWithCategoryAndManufacturerAsync(int id);
    }
}
