using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Interfaces.Services.University;

public interface IAttendanceLogService
{
    /// <summary>
    /// Проверка модели посещаемости на возможность создания или редактирования
    /// </summary>
    /// <param name="dataContext">Контекст базы данных</param>
    /// <param name="attendanceLog">Посещаемость</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateOrUpdateAttendanceLogValidateAndThrowAsync(
        DataContext dataContext,
        AttendanceLog attendanceLog,
        CancellationToken cancellationToken = default);
}
