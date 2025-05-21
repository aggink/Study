using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Announcements.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Announcements.Queries;

/// <summary>
/// Получить объявление по идентификатору
/// </summary>
public sealed class GetAnnouncementByIsnQuery : IRequest<AnnouncementDto>
{
    /// <summary>
    /// Идентификатор объявления
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnAnnouncement { get; init; }
}

public sealed class GetAnnouncementByIsnQueryHandler : IRequestHandler<GetAnnouncementByIsnQuery, AnnouncementDto>
{
    private readonly DataContext _dataContext;

    public GetAnnouncementByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<AnnouncementDto> Handle(GetAnnouncementByIsnQuery request, CancellationToken cancellationToken)
    {
        var announcement = await _dataContext.Announcements
                               .AsNoTracking()
                               .FirstOrDefaultAsync(x => x.IsnAnnouncement == request.IsnAnnouncement,
                                   cancellationToken)
                           ?? throw new BusinessLogicException(
                               $"Объявление с идентификатором \"{request.IsnAnnouncement}\" не существует");

        return new AnnouncementDto
        {
            IsnAnnouncement = announcement.IsnAnnouncement,
            IsnTeacher = announcement.IsnTeacher,
            Title = announcement.Title,
            Content = announcement.Content,
            PublishDate = announcement.PublishDate,
            IsImportant = announcement.IsImportant
        };
    }
}