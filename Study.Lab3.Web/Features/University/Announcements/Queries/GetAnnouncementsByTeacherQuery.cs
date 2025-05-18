using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Announcements.DtoModels;

namespace Study.Lab3.Web.Features.University.Announcements.Queries;

/// <summary>
/// Получение объявлений по преподавателю
/// </summary>
public sealed class GetAnnouncementsByTeacherQuery : IRequest<AnnouncementDto[]>
{
    /// <summary>
    /// Идентификатор преподавателя
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnTeacher { get; init; }
}

public sealed class
    GetAnnouncementsByTeacherQueryHandler : IRequestHandler<GetAnnouncementsByTeacherQuery, AnnouncementDto[]>
{
    private readonly DataContext _dataContext;

    public GetAnnouncementsByTeacherQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<AnnouncementDto[]> Handle(GetAnnouncementsByTeacherQuery request,
        CancellationToken cancellationToken)
    {
        if (!await _dataContext.Teachers.AnyAsync(x => x.IsnTeacher == request.IsnTeacher, cancellationToken))
            throw new BusinessLogicException($"Преподаватель с идентификатором \"{request.IsnTeacher}\" не существует");

        return await _dataContext.Announcements
                                 .AsNoTracking()
                                 .Where(x => x.IsnTeacher == request.IsnTeacher)
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