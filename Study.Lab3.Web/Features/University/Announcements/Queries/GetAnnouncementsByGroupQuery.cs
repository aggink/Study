using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Announcements.DtoModels;

namespace Study.Lab3.Web.Features.University.Announcements.Queries;

/// <summary>
/// Получение объявлений для группы
/// </summary>
public sealed class GetAnnouncementsByGroupQuery : IRequest<AnnouncementDto[]>
{
    /// <summary>
    /// Идентификатор группы
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnGroup { get; init; }
}

public sealed class
    GetAnnouncementsByGroupQueryHandler : IRequestHandler<GetAnnouncementsByGroupQuery, AnnouncementDto[]>
{
    private readonly DataContext _dataContext;

    public GetAnnouncementsByGroupQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<AnnouncementDto[]> Handle(GetAnnouncementsByGroupQuery request,
        CancellationToken cancellationToken)
    {
        if (!await _dataContext.Groups.AnyAsync(x => x.IsnGroup == request.IsnGroup, cancellationToken))
            throw new BusinessLogicException($"Группа с идентификатором \"{request.IsnGroup}\" не существует");

        return await _dataContext.AnnouncementGroups
                                 .AsNoTracking()
                                 .Where(x => x.IsnGroup == request.IsnGroup)
                                 .Select(x => new AnnouncementDto
                                 {
                                     IsnAnnouncement = x.Announcement.IsnAnnouncement,
                                     IsnTeacher = x.Announcement.IsnTeacher,
                                     Title = x.Announcement.Title,
                                     Content = x.Announcement.Content,
                                     PublishDate = x.Announcement.PublishDate,
                                     IsImportant = x.Announcement.IsImportant
                                 })
                                 .OrderByDescending(x => x.IsImportant)
                                 .ThenByDescending(x => x.PublishDate)
                                 .ToArrayAsync(cancellationToken);
    }
}