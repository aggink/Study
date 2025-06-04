using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Services.University;

public sealed class CareerService : ICareerService
{
    public async Task CreateOrUpdateCareerValidateAndThrowAsync(
        DataContext dataContext,
        Career career,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Students.AnyAsync(x => x.IsnStudent == career.IsnStudent, cancellationToken))
        {
            throw new BusinessLogicException($"Студент с идентификатором \"{career.IsnStudent}\" не существует");
        }

        if (!await dataContext.Subjects.AnyAsync(x => x.IsnSubject == career.IsnSubject, cancellationToken))
        {
            throw new BusinessLogicException($"Работа по виду занятости с идентификатором \"{career.IsnSubject}\" не существует");
        }

        if (career.ParticipantsCount < ModelConstants.Career.MinPartValue || career.ParticipantsCount > ModelConstants.Career.MaxPartValue)
        {
            throw new BusinessLogicException($"Количество участников должно быть от {ModelConstants.Career.MinPartValue} до {ModelConstants.Career.MaxPartValue}");
        }

        if (career.CareerDate > DateTime.UtcNow)
        {
            throw new BusinessLogicException("Нельзя провести мероприятие будущим числом");
        }

        var existingCareer = await dataContext.Career
            .FirstOrDefaultAsync(x =>
                x.IsnStudent == career.IsnStudent &&
                x.IsnSubject == career.IsnSubject &&
                x.CareerDate.Date == career.CareerDate.Date &&
                x.IsnCareer != career.IsnCareer,
                cancellationToken);

        if (existingCareer != null)
        {
            throw new BusinessLogicException("Студент уже назначил встречу на собеседование по эту работу в указанную дату");
        }

        if (career.IsnCareer != Guid.Empty)
        {
            var originalCareer = await dataContext.Career
                .FirstOrDefaultAsync(x => x.IsnCareer == career.IsnCareer, cancellationToken);

            if (originalCareer != null &&
                (DateTime.UtcNow - originalCareer.CareerDate).TotalDays > 30)
            {
                throw new BusinessLogicException("Нельзя изменить количество участников, зарегистрированных более месяца назад");
            }
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Career career,
        CancellationToken cancellationToken = default)
    {

        if ((DateTime.UtcNow - career.CareerDate).TotalDays > 30)
        {
            throw new BusinessLogicException("Нельзя удалить собеседование, проведенные более месяца назад");
        }

        var hasMeeting = await dataContext.Career
            .AnyAsync(x =>
                x.IsnStudent == career.IsnStudent &&
                x.IsnSubject == career.IsnSubject &&
                x.CareerDate > career.CareerDate,
                cancellationToken);

        if (hasMeeting)
        {
            throw new BusinessLogicException("Нельзя удалить собеседование, так как уже есть более поздние встречи на работу");
        }
    }
}