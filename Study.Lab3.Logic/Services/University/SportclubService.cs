using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Services.University;

public sealed class SportclubService : ISportclubService
{
    public async Task CreateOrUpdateSportclubValidateAndThrowAsync(
        DataContext dataContext,
        Sportclub sportclub,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Students.AnyAsync(x => x.IsnStudent == sportclub.IsnStudent, cancellationToken))
        {
            throw new BusinessLogicException($"Студент с идентификатором \"{sportclub.IsnStudent}\" не существует");
        }

        if (!await dataContext.Subjects.AnyAsync(x => x.IsnSubject == sportclub.IsnSubject, cancellationToken))
        {
            throw new BusinessLogicException($"Спортивная деятельность по виду спорта с идентификатором \"{sportclub.IsnSubject}\" не существует");
        }

        if (sportclub.ParticipantsCount < ModelConstants.Sportclub.MinParticipantValue || sportclub.ParticipantsCount > ModelConstants.Sportclub.MaxParticipantValue)
        {
            throw new BusinessLogicException($"Количество участников должно быть от {ModelConstants.Sportclub.MinParticipantValue} до {ModelConstants.Sportclub.MaxParticipantValue}");
        }

        if (sportclub.SportclubDate > DateTime.UtcNow)
        {
            throw new BusinessLogicException("Нельзя провести мероприятие будущим числом");
        }

        var existingSportclub = await dataContext.Sportclub
            .FirstOrDefaultAsync(x =>
                x.IsnStudent == sportclub.IsnStudent &&
                x.IsnSubject == sportclub.IsnSubject &&
                x.SportclubDate.Date == sportclub.SportclubDate.Date &&
                x.IsnSportclub != sportclub.IsnSportclub,
                cancellationToken);

        if (existingSportclub != null)
        {
            throw new BusinessLogicException("Студент уже назначил встречу для соревнований по этому предмету в указанную дату");
        }

        if (sportclub.IsnSportclub != Guid.Empty)
        {
            var originalSportclub = await dataContext.Sportclub
                .FirstOrDefaultAsync(x => x.IsnSportclub == sportclub.IsnSportclub, cancellationToken);

            if (originalSportclub != null &&
                (DateTime.UtcNow - originalSportclub.SportclubDate).TotalDays > 30)
            {
                throw new BusinessLogicException("Нельзя изменить количество участников, зарегистрированных более месяца назад");
            }
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Sportclub sportclub,
        CancellationToken cancellationToken = default)
    {

        if ((DateTime.UtcNow - sportclub.SportclubDate).TotalDays > 30)
        {
            throw new BusinessLogicException("Нельзя удалить соревнования, проведенные более месяца назад");
        }

        var hasMeeting = await dataContext.Sportclub
            .AnyAsync(x =>
                x.IsnStudent == sportclub.IsnStudent &&
                x.IsnSubject == sportclub.IsnSubject &&
                x.SportclubDate > sportclub.SportclubDate,
                cancellationToken);

        if (hasMeeting)
        {
            throw new BusinessLogicException("Нельзя удалить соревнования, так как уже есть более поздние встречи по предмету");
        }
    }
}