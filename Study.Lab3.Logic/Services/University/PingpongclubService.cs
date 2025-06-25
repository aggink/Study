using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Services.University;

public sealed class PingpongclubService : IPingpongclubService
{
    public async Task CreateOrUpdatePingpongclubValidateAndThrowAsync(
        DataContext dataContext,
        Pingpongclub Pingpongclub,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Students.AnyAsync(x => x.IsnStudent == Pingpongclub.IsnStudent, cancellationToken))
        {
            throw new BusinessLogicException($"Студент с идентификатором \"{Pingpongclub.IsnStudent}\" не существует");
        }

        if (!await dataContext.Subjects.AnyAsync(x => x.IsnSubject == Pingpongclub.IsnSubject, cancellationToken))
        {
            throw new BusinessLogicException($"Спортивная деятельность по виду спорта с идентификатором \"{Pingpongclub.IsnSubject}\" не существует");
        }

        if (Pingpongclub.ParticipantsCount < ModelConstants.Pingpongclub.MinParticipantValue || Pingpongclub.ParticipantsCount > ModelConstants.Pingpongclub.MaxParticipantValue)
        {
            throw new BusinessLogicException($"Количество участников должно быть от {ModelConstants.Pingpongclub.MinParticipantValue} до {ModelConstants.Pingpongclub.MaxParticipantValue}");
        }

        if (Pingpongclub.PingpongclubDate > DateTime.UtcNow)
        {
            throw new BusinessLogicException("Нельзя провести мероприятие будущим числом");
        }

        var existingPingpongclub = await dataContext.Pingpongclub
            .FirstOrDefaultAsync(x =>
                x.IsnStudent == Pingpongclub.IsnStudent &&
                x.IsnSubject == Pingpongclub.IsnSubject &&
                x.PingpongclubDate.Date == Pingpongclub.PingpongclubDate.Date &&
                x.IsnPingpongclub != Pingpongclub.IsnPingpongclub,
                cancellationToken);

        if (existingPingpongclub != null)
        {
            throw new BusinessLogicException("Студент уже назначил встречу для соревнований по этому предмету в указанную дату");
        }

        if (Pingpongclub.IsnPingpongclub != Guid.Empty)
        {
            var originalPingpongclub = await dataContext.Pingpongclub
                .FirstOrDefaultAsync(x => x.IsnPingpongclub == Pingpongclub.IsnPingpongclub, cancellationToken);

            if (originalPingpongclub != null &&
                (DateTime.UtcNow - originalPingpongclub.PingpongclubDate).TotalDays > 30)
            {
                throw new BusinessLogicException("Нельзя изменить количество участников, зарегистрированных более месяца назад");
            }
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Pingpongclub Pingpongclub,
        CancellationToken cancellationToken = default)
    {

        if ((DateTime.UtcNow - Pingpongclub.PingpongclubDate).TotalDays > 30)
        {
            throw new BusinessLogicException("Нельзя удалить соревнования, проведенные более месяца назад");
        }

        var hasMeeting = await dataContext.Pingpongclub
            .AnyAsync(x =>
                x.IsnStudent == Pingpongclub.IsnStudent &&
                x.IsnSubject == Pingpongclub.IsnSubject &&
                x.PingpongclubDate > Pingpongclub.PingpongclubDate,
                cancellationToken);

        if (hasMeeting)
        {
            throw new BusinessLogicException("Нельзя удалить соревнования, так как уже есть более поздние встречи по предмету");
        }
    }
}