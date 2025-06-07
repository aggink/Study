using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Sweets;
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
        /// Проверка модели фабрики на возможность создания или редактирования
        /// </summary>
        /// <param name="dataContext">Контекст базы данных</param>
        /// <param name="sweetfactory">Фабрика сладостей</param>
        /// <param name="cancellationToken">Токен отмены</param>
        Task CreateOrUpdateSweetFactoryValidateAndThrowAsync(
            DataContext dataContext,
            SweetFactory sweetfactory,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка возможности удаления зала
        /// </summary>
        /// <param name="dataContext">Контекст базы данных</param>
        /// <param name="sweetfactory">Зал</param>
        /// <param name="cancellationToken">Токен отмены</param>
        Task CanDeleteAndThrowAsync(
            DataContext dataContext,
            SweetFactory sweetfactory,
            CancellationToken cancellationToken = default);
    }
}
