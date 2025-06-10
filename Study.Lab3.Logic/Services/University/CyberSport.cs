using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Services.University;

public sealed class CyberSportService : ICyberSportService
{
    public async Task CreateOrUpdateCyberSportValidateAndThrowAsync(
        DataContext dataContext,
        CyberSport cyberSport,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Students.AnyAsync(x => x.IsnStudent == cyberSport.IsnStudent, cancellationToken))
        {
            throw new BusinessLogicException($"Студент с идентификатором \"{cyberSport.IsnStudent}\" не существует");
        }

        if (!await dataContext.Subjects.AnyAsync(x => x.IsnSubject == cyberSport.IsnSubject, cancellationToken))
        {
            throw new BusinessLogicException($"Спортивная деятельность по виду спорта с идентификатором \"{cyberSport.IsnSubject}\" не существует");
        }

        if (cyberSport.PointsCount < ModelConstants.CyberSport.MinPointsValue || cyberSport.PointsCount > ModelConstants.CyberSport.MaxPointsValue)
        {
            throw new BusinessLogicException($"Количество участников должно быть от {ModelConstants.CyberSport.MinPointsValue} до {ModelConstants.CyberSport.MaxPointsValue}");
        }

        if (cyberSport.CyberSportDate > DateTime.UtcNow)
        {
            throw new BusinessLogicException("Нельзя провести мероприятие будущим числом");
        }

        var existingCyberSport = await dataContext.CyberSport
            .FirstOrDefaultAsync(x =>
                x.IsnStudent == cyberSport.IsnStudent &&
                x.IsnSubject == cyberSport.IsnSubject &&
                x.CyberSportDate.Date == cyberSport.CyberSportDate.Date &&
                x.IsnCyberSport != cyberSport.IsnCyberSport,
                cancellationToken);

        if (existingCyberSport != null)
        {
            throw new BusinessLogicException("Студент уже назначил встречу для соревнований по этому предмету в указанную дату");
        }

        if (cyberSport.IsnCyberSport != Guid.Empty)
        {
            var originalCyberSport = await dataContext.CyberSport
                .FirstOrDefaultAsync(x => x.IsnCyberSport == cyberSport.IsnCyberSport, cancellationToken);

            if (originalCyberSport != null &&
                (DateTime.UtcNow - originalCyberSport.CyberSportDate).TotalDays > 30)
            {
                throw new BusinessLogicException("Нельзя изменить количество участников, зарегистрированных более месяца назад");
            }
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        CyberSport cyberSport,
        CancellationToken cancellationToken = default)
    {

        if ((DateTime.UtcNow - cyberSport.CyberSportDate).TotalDays > 30)
        {
            throw new BusinessLogicException("Нельзя удалить соревнования, проведенные более месяца назад");
        }

        var hasMeeting = await dataContext.CyberSport
            .AnyAsync(x =>
                x.IsnStudent == cyberSport.IsnStudent &&
                x.IsnSubject == cyberSport.IsnSubject &&
                x.CyberSportDate > cyberSport.CyberSportDate,
                cancellationToken);

        if (hasMeeting)
        {
            throw new BusinessLogicException("Нельзя удалить соревнования, так как уже есть более поздние встречи по предмету");
        }
    }
}