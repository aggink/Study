using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Announcements.DtoModels;

namespace Study.Lab3.Web.Features.University.Announcements.Commands;

/// <summary>
/// Обновление объявления
/// </summary>
public sealed class UpdateAnnouncementCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные объявления
    /// </summary>
    [Required]
    [FromBody]
    public UpdateAnnouncementDto Announcement { get; init; }
}

public sealed class UpdateAnnouncementCommandHandler : IRequestHandler<UpdateAnnouncementCommand, Guid>
{
    private readonly IAnnouncementService _announcementService;
    private readonly DataContext          _dataContext;

    public UpdateAnnouncementCommandHandler(
        DataContext dataContext,
        IAnnouncementService announcementService)
    {
        _dataContext = dataContext;
        _announcementService = announcementService;
    }

    public async Task<Guid> Handle(UpdateAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var announcement = await _dataContext.Announcements
                                             .FirstOrDefaultAsync(
                                                 x => x.IsnAnnouncement == request.Announcement.IsnAnnouncement,
                                                 cancellationToken)
                           ?? throw new BusinessLogicException(
                               $"Объявление с идентификатором \"{request.Announcement.IsnAnnouncement}\" не существует");

        announcement.Title = request.Announcement.Title;
        announcement.Content = request.Announcement.Content;
        announcement.IsImportant = request.Announcement.IsImportant;

        await _announcementService.CreateOrUpdateAnnouncementValidateAndThrowAsync(
            _dataContext, announcement, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return announcement.IsnAnnouncement;
    }
}