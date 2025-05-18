using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Announcements.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Announcements.Queries;

/// <summary>
/// Получить объявление с детальной информацией
/// </summary>
public sealed class GetAnnouncementWithDetailsQuery : IRequest<AnnouncementWithDetailsDto>
{
    /// <summary>
    /// Идентификатор объявления
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnAnnouncement { get; init; }
}

public sealed class GetAnnouncementWithDetailsQueryHandler : IRequestHandler<GetAnnouncementWithDetailsQuery,
    AnnouncementWithDetailsDto>
{
    private readonly DataContext _dataContext;

    public GetAnnouncementWithDetailsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<AnnouncementWithDetailsDto> Handle(GetAnnouncementWithDetailsQuery request,
        CancellationToken cancellationToken)
    {
        return await _dataContext.Announcements
                                 .AsNoTracking()
                                 .Where(x => x.IsnAnnouncement == request.IsnAnnouncement)
                                 .Select(x => new AnnouncementWithDetailsDto
                                 {
                                     IsnAnnouncement = x.IsnAnnouncement,
                                     IsnTeacher = x.IsnTeacher,
                                     TeacherFullName =
                                         $"{x.Teacher.SurName} {x.Teacher.Name} {x.Teacher.PatronymicName}",
                                     Title = x.Title,
                                     Content = x.Content,
                                     PublishDate = x.PublishDate,
                                     IsImportant = x.IsImportant,
                                     Groups = x.AnnouncementGroups.Select(ag => new AnnouncementGroupItemDto
                                     {
                                         IsnGroup = ag.IsnGroup,
                                         GroupName = ag.Group.Name
                                     }).ToArray()
                                 })
                                 .FirstOrDefaultAsync(cancellationToken)
               ?? throw new BusinessLogicException(
                   $"Объявление с идентификатором \"{request.IsnAnnouncement}\" не существует");
    }
}