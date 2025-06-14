using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Services.University;

public sealed class KvnService : IKvnService
{
    public async Task CreateOrUpdateKvnValidateAndThrowAsync(
        DataContext dataContext,
        Kvn kvn,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Students.AnyAsync(x => x.IsnStudent == kvn.IsnStudent, cancellationToken))
        {
            throw new BusinessLogicException($"Студент с идентификатором \"{kvn.IsnStudent}\" не существует");
        }

        if (!await dataContext.Subjects.AnyAsync(x => x.IsnSubject == kvn.IsnSubject, cancellationToken))
        {
            throw new BusinessLogicException($"Выступление с идентификатором \"{kvn.IsnSubject}\" не существует");
        }

        if (kvn.ParticipantsCount < ModelConstants.Kvn.MinPart || kvn.ParticipantsCount > ModelConstants.Kvn.MaxPart)
        {
            throw new BusinessLogicException($"Количество участников должно быть от {ModelConstants.Kvn.MinPart} до {ModelConstants.Kvn.MaxPart}");
        }

        if (kvn.KvnDate > DateTime.UtcNow)
        {
            throw new BusinessLogicException("Нельзя провести мероприятие будущим числом");
        }

        var existingKvn = await dataContext.Kvns
            .FirstOrDefaultAsync(x =>
                x.IsnStudent == kvn.IsnStudent &&
                x.IsnSubject == kvn.IsnSubject &&
                x.KvnDate.Date == kvn.KvnDate.Date &&
                x.IsnKvn != kvn.IsnKvn,
                cancellationToken);

        if (existingKvn != null)
        {
            throw new BusinessLogicException("Выступление уже назначено в указанную дату");
        }

        if (kvn.IsnKvn != Guid.Empty)
        {
            var originalKvn = await dataContext.Kvns
                .FirstOrDefaultAsync(x => x.IsnKvn == kvn.IsnKvn, cancellationToken);

            if (originalKvn != null &&
                (DateTime.UtcNow - originalKvn.KvnDate).TotalDays > 30)
            {
                throw new BusinessLogicException("Нельзя изменить количество участников, зарегистрированных более месяца назад");
            }
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Kvn kvn,
        CancellationToken cancellationToken = default)
    {

        if ((DateTime.UtcNow - kvn.KvnDate).TotalDays > 30)
        {
            throw new BusinessLogicException("Нельзя отменить выступление, проведенное более месяца назад");
        }

        var hasMeeting = await dataContext.Kvns
            .AnyAsync(x =>
                x.IsnStudent == kvn.IsnStudent &&
                x.IsnSubject == kvn.IsnSubject &&
                x.KvnDate > kvn.KvnDate,
                cancellationToken);

        if (hasMeeting)
        {
            throw new BusinessLogicException("Нельзя удалить выступление, так как уже есть более поздние выступления");
        }
    }
}