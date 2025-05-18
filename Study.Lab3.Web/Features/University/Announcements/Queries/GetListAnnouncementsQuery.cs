using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Announcements.DtoModels;

namespace Study.Lab3.Web.Features.University.Announcements.Queries;

/// <summary>
/// Получение списка объявлений
/// </summary>
public sealed class GetListAnnouncementsQuery : IRequest<AnnouncementDto[]>
{
}

public sealed class GetListAnnouncementsQueryHandler : IRequestHandler<GetListAnnouncementsQuery, AnnouncementDto[]>
{
    private readonly DataContext _dataContext;

    public GetListAnnouncementsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<AnnouncementDto[]> Handle(GetListAnnouncementsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Announcements
                                 .AsNoTracking()
                                 .Select(x => new AnnouncementDto
                                 {
                                     IsnAnnouncement = x.IsnAnnouncement,
                                     IsnTeacher = x.IsnTeacher,
                                     Title = x.Title,
                                     Content = x.Content,
                                     PublishDate = x.PublishDate,
                                     IsImportant = x.IsImportant
                                 })
                                 .OrderByDescending(x => x.IsImportant)
                                 .ThenByDescending(x => x.PublishDate)
                                 .ToArrayAsync(cancellationToken);
    }
}