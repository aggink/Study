using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Services.University;

public sealed class ProjectActivitiesService : IProjectActivitiesService
{
    public async Task CreateOrUpdateProjectActivitiesValidateAndThrowAsync(
        DataContext dataContext,
        ProjectActivities projectactivities,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Students.AnyAsync(x => x.IsnStudent == projectactivities.IsnStudent, cancellationToken))
        {
            throw new BusinessLogicException($"Студент с идентификатором \"{projectactivities.IsnStudent}\" не существует");
        }

        if (!await dataContext.Subjects.AnyAsync(x => x.IsnSubject == projectactivities.IsnSubject, cancellationToken))
        {
            throw new BusinessLogicException($"Научная деятельность по предмету с идентификатором \"{projectactivities.IsnSubject}\" не существует");
        }

        if (projectactivities.PerformancesCount < ModelConstants.ProjectActivities.MinPerformancesValue || projectactivities.PerformancesCount > ModelConstants.ProjectActivities.MaxPerformancesValue)
        {
            throw new BusinessLogicException($"Количество участников должно быть от {ModelConstants.ProjectActivities.MinPerformancesValue} до {ModelConstants.ProjectActivities.MaxPerformancesValue}");
        }

        if (projectactivities.ProjectActivitiesDate > DateTime.UtcNow)
        {
            throw new BusinessLogicException("Нельзя провести мероприятие будущим числом");
        }

        var existingProjectActivities = await dataContext.ProjectActivities
            .FirstOrDefaultAsync(x =>
                x.IsnStudent == projectactivities.IsnStudent &&
                x.IsnSubject == projectactivities.IsnSubject &&
                x.ProjectActivitiesDate.Date == projectactivities.ProjectActivitiesDate.Date &&
                x.IsnProjectActivities != projectactivities.IsnProjectActivities,
                cancellationToken);

        if (existingProjectActivities != null)
        {
            throw new BusinessLogicException("Студент уже назначил встречу для научной деятельности по этому предмету в указанную дату");
        }

        if (projectactivities.IsnProjectActivities != Guid.Empty)
        {
            var originalProjectActivities = await dataContext.ProjectActivities
                .FirstOrDefaultAsync(x => x.IsnProjectActivities == projectactivities.IsnProjectActivities, cancellationToken);

            if (originalProjectActivities != null &&
                (DateTime.UtcNow - originalProjectActivities.ProjectActivitiesDate).TotalDays > 30)
            {
                throw new BusinessLogicException("Нельзя изменить количество участников, зарегистрированных более месяца назад");
            }
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        ProjectActivities projectactivities,
        CancellationToken cancellationToken = default)
    {

        if ((DateTime.UtcNow - projectactivities.ProjectActivitiesDate).TotalDays > 30)
        {
            throw new BusinessLogicException("Нельзя удалить научную встречу, проведенную более месяца назад");
        }

        var hasMeeting = await dataContext.ProjectActivities
            .AnyAsync(x =>
                x.IsnStudent == projectactivities.IsnStudent &&
                x.IsnSubject == projectactivities.IsnSubject &&
                x.ProjectActivitiesDate > projectactivities.ProjectActivitiesDate,
                cancellationToken);

        if (hasMeeting)
        {
            throw new BusinessLogicException("Нельзя удалить научную встречу, так как уже есть более поздние встречи по предмету");
        }
    }
}