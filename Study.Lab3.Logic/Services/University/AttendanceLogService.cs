using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Services.University;

public sealed class AttendanceLogService : IAttendanceLogService
{
    public async Task CreateOrUpdateAttendanceLogValidateAndThrowAsync(
        DataContext dataContext,
        AttendanceLog attendanceLog,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Students.AnyAsync(x => x.IsnStudent == attendanceLog.IsnStudent, cancellationToken))
        {
            throw new BusinessLogicException($"Студент с идентификатором \"{attendanceLog.IsnStudent}\" не существует");
        }

        if (!await dataContext.Subjects.AnyAsync(x => x.IsnSubject == attendanceLog.IsnSubject, cancellationToken))
        {
            throw new BusinessLogicException($"Предмет с идентификатором \"{attendanceLog.IsnSubject}\" не существует");
        }

        if (attendanceLog.IsPresent < ModelConstants.AttendanceLog.MinPresentValue || attendanceLog.IsPresent > ModelConstants.AttendanceLog.MaxPresentValue)
        {
            throw new BusinessLogicException($"Значение присутствия должно быть либо {ModelConstants.AttendanceLog.MinPresentValue} (отсутствие), либо {ModelConstants.AttendanceLog.MaxPresentValue} (присутствие)");
        }

        var existingAttendanceLog = await dataContext.TheAttendanceLog
            .FirstOrDefaultAsync(x =>
                x.IsnStudent == attendanceLog.IsnStudent &&
                x.IsnSubject == attendanceLog.IsnSubject &&
                x.SubjectDate.Date == attendanceLog.SubjectDate.Date &&
                x.IsnAttendanceLog != attendanceLog.IsnAttendanceLog,
                cancellationToken);

        if (existingAttendanceLog != null)
        {
            throw new BusinessLogicException("В данную дату уже отмечена посещаемость");
        }

        if (attendanceLog.IsnAttendanceLog != Guid.Empty)
        {
            var originalAttendanceLog = await dataContext.TheAttendanceLog
                .FirstOrDefaultAsync(x => x.IsnAttendanceLog == attendanceLog.IsnAttendanceLog, cancellationToken);
        }
    }
}
