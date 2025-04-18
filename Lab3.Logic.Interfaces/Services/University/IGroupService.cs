using Lab3.Storage.Database;
using Lab3.Storage.Models.University;

namespace Lab3.Logic.Interfaces.Services.University
{
    public interface IGroupService
    {
        /// <summary>
        /// Проверка модели группы на возможность создания или редактирования
        /// </summary>
        /// <param name="dataContext">Контекст базы данных</param>
        /// <param name="group">Группа</param>
        /// <param name="cancellationToken">Токен отмены</param>
        Task CreateOrUpdateGroupValidateAsync(DataContext dataContext, Group group, CancellationToken cancellationToken);

        /// <summary>
        /// Проверка возможности удаления группы
        /// </summary>
        /// <param name="dataContext">Контекст базы данных</param>
        /// <param name="group">Группа</param>
        /// <param name="cancellationToken">Токен отмены</param>
        Task CanDeleteAsync(DataContext dataContext, Group group, CancellationToken cancellationToken);
    }
}
