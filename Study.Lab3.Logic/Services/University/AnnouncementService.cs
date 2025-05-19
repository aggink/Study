using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;

namespace Study.Lab3.Logic.Services.University;

public sealed class AnnouncementService : IAnnouncementService
{
    public async Task CreateOrUpdateAnnouncementValidateAndThrowAsync(
        DataContext dataContext,
        Announcement announcement,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Teachers.AnyAsync(x => x.IsnTeacher == announcement.IsnTeacher, cancellationToken))
            throw new BusinessLogicException(
                $"Преподаватель с идентификатором \"{announcement.IsnTeacher}\" не существует");

        if (string.IsNullOrWhiteSpace(announcement.Title))
            throw new BusinessLogicException("Заголовок объявления не может быть пустым");

        if (string.IsNullOrWhiteSpace(announcement.Content))
            throw new BusinessLogicException("Текст объявления не может быть пустым");

        if (announcement.Title.Length > 200)
            throw new BusinessLogicException("Заголовок объявления не может превышать 200 символов");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Announcement announcement,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Announcements.AnyAsync(x => x.IsnAnnouncement == announcement.IsnAnnouncement, cancellationToken))
            throw new BusinessLogicException(
                $"Объявление с идентификатором \"{announcement.IsnAnnouncement}\" не существует");

        if (await dataContext.AnnouncementGroups.AnyAsync(x => x.IsnAnnouncement == announcement.IsnAnnouncement, cancellationToken))
            throw new BusinessLogicException("Невозможно удалить объявление, так как оно связано с группами");
    }

    public async Task AddGroupValidateAndThrowAsync(
        DataContext dataContext,
        AnnouncementGroup announcementGroup,
        CancellationToken cancellationToken = default,
        bool skipAnnouncementCheck = false)
    {
        if (!skipAnnouncementCheck && !await dataContext.Announcements.AnyAsync(
                x => x.IsnAnnouncement == announcementGroup.IsnAnnouncement, cancellationToken))
            throw new BusinessLogicException(
                $"Объявление с идентификатором \"{announcementGroup.IsnAnnouncement}\" не существует");

        if (!await dataContext.Announcements.AnyAsync(x => x.IsnAnnouncement == announcementGroup.IsnAnnouncement,
                cancellationToken))
            throw new BusinessLogicException(
                $"Объявление с идентификатором \"{announcementGroup.IsnAnnouncement}\" не существует");

        if (!await dataContext.Groups.AnyAsync(x => x.IsnGroup == announcementGroup.IsnGroup, cancellationToken))
            throw new BusinessLogicException(
                $"Группа с идентификатором \"{announcementGroup.IsnGroup}\" не существует");

        if (await dataContext.AnnouncementGroups.AnyAsync(
                x => x.IsnAnnouncement == announcementGroup.IsnAnnouncement &&
                     x.IsnGroup == announcementGroup.IsnGroup,
                cancellationToken))
            throw new BusinessLogicException("Эта группа уже добавлена к данному объявлению");
    }
}