using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Interfaces.Services.University;

public interface IStudentNoteService
{
    /// <summary>
    /// Проверка заметки студента на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="note">Заметка студента</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateNoteValidateAndThrowAsync(
        DataContext dataContext,
        StudentNote note,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления заметки студента
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="note">Заметка студента</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        StudentNote note,
        CancellationToken cancellationToken = default);
}