using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Interfaces.Services.University;
//Обработка связей преподаватель-предмет
public interface ITeacherSubjectService
{
    /// <summary>
    /// Проверка связи учитель-предмет на возможность создания
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="teacherSubject">Связь учитель-предмет</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateTeacherSubjectValidateAndThrowAsync(
        DataContext dataContext,
        TeacherSubject teacherSubject,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка возможности удаления связи учитель-предмет
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="teacherSubject">Связь учитель-предмет</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        TeacherSubject teacherSubject,
        CancellationToken cancellationToken = default);
}