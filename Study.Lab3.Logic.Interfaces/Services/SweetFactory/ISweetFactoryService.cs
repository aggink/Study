using Study.Lab3.Storage.Database;
<<<<<<< HEAD
using Study.Lab3.Storage.Models.Sweets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab3.Logic.Interfaces.Services.Sweets
=======

namespace Study.Lab3.Logic.Interfaces.Services.SweetFactory
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
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
<<<<<<< HEAD
            SweetFactory sweetfactory,
=======
            Storage.Models.Sweets.SweetFactory sweetfactory,
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка возможности удаления зала
        /// </summary>
        /// <param name="dataContext">Контекст базы данных</param>
        /// <param name="sweetfactory">Зал</param>
        /// <param name="cancellationToken">Токен отмены</param>
        Task CanDeleteAndThrowAsync(
            DataContext dataContext,
<<<<<<< HEAD
            SweetFactory sweetfactory,
=======
            Storage.Models.Sweets.SweetFactory sweetfactory,
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
            CancellationToken cancellationToken = default);
    }
}
