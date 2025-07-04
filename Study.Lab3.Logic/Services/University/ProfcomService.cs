﻿using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Services.University;

public sealed class ProfcomService : IProfcomService
{
    public async Task CreateOrUpdateProfcomValidateAndThrowAsync(
        DataContext dataContext,
        Profcom profcom,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Students.AnyAsync(x => x.IsnStudent == profcom.IsnStudent, cancellationToken))
        {
            throw new BusinessLogicException($"Студент с идентификатором \"{profcom.IsnStudent}\" не существует");
        }

        if (!await dataContext.Subjects.AnyAsync(x => x.IsnSubject == profcom.IsnSubject, cancellationToken))
        {
            throw new BusinessLogicException($"Научная деятельность по предмету с идентификатором \"{profcom.IsnSubject}\" не существует");
        }

        if (profcom.ParticipantsCount < ModelConstants.Profcom.MinPartValue || profcom.ParticipantsCount > ModelConstants.Profcom.MaxPartValue)
        {
            throw new BusinessLogicException($"Количество участников должно быть от {ModelConstants.Profcom.MinPartValue} до {ModelConstants.Profcom.MaxPartValue}");
        }

        if (profcom.ProfcomDate > DateTime.UtcNow)
        {
            throw new BusinessLogicException("Нельзя провести мероприятие будущим числом");
        }

        var existingProfcom = await dataContext.Profcoms
            .FirstOrDefaultAsync(x =>
                x.IsnStudent == profcom.IsnStudent &&
                x.IsnSubject == profcom.IsnSubject &&
                x.ProfcomDate.Date == profcom.ProfcomDate.Date &&
                x.IsnProfcom != profcom.IsnProfcom,
                cancellationToken);

        if (existingProfcom != null)
        {
            throw new BusinessLogicException("Студент уже назначил встречу для научной деятельности по этому предмету в указанную дату");
        }

        if (profcom.IsnProfcom != Guid.Empty)
        {
            var originalProfcom = await dataContext.Profcoms
                .FirstOrDefaultAsync(x => x.IsnProfcom == profcom.IsnProfcom, cancellationToken);

            if (originalProfcom != null &&
                (DateTime.UtcNow - originalProfcom.ProfcomDate).TotalDays > 30)
            {
                throw new BusinessLogicException("Нельзя изменить количество участников, зарегистрированных более месяца назад");
            }
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Profcom profcom,
        CancellationToken cancellationToken = default)
    {

        if ((DateTime.UtcNow - profcom.ProfcomDate).TotalDays > 30)
        {
            throw new BusinessLogicException("Нельзя удалить научную встречу, проведенную более месяца назад");
        }

        var hasMeeting = await dataContext.Profcoms
            .AnyAsync(x =>
                x.IsnStudent == profcom.IsnStudent &&
                x.IsnSubject == profcom.IsnSubject &&
                x.ProfcomDate > profcom.ProfcomDate,
                cancellationToken);

        if (hasMeeting)
        {
            throw new BusinessLogicException("Нельзя удалить научную встречу, так как уже есть более поздние встречи по предмету");
        }
    }
}