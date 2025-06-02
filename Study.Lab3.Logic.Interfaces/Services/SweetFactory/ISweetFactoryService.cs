using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Cinema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab3.Logic.Interfaces.Services.Sweets
{
    public interface ISweetFactoryService
    {
        /// <summary>
        /// Проверка модели зала на возможность создания или редактирования
        /// </summary>
        /// <param name="dataContext">Контекст базы данных</param>
        /// <param name="hall">Зал</param>
        /// <param name="cancellationToken">Токен отмены</param>
        Task CreateOrUpdateHallValidateAndThrowAsync(
            DataContext dataContext,
            Hall hall,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка возможности удаления зала
        /// </summary>
        /// <param name="dataContext">Контекст базы данных</param>
        /// <param name="hall">Зал</param>
        /// <param name="cancellationToken">Токен отмены</param>
        Task CanDeleteAndThrowAsync(
            DataContext dataContext,
            Hall hall,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Генерация мест для зала
        /// </summary>
        /// <param name="dataContext">Контекст базы данных</param>
        /// <param name="hall">Зал</param>
        /// <param name="cancellationToken">Токен отмены</param>
        Task GenerateSeatsForHallAsync(
            DataContext dataContext,
            Hall hall,
            CancellationToken cancellationToken = default);
    }
}
