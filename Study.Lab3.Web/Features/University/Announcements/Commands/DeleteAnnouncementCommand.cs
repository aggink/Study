using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.University.Announcements.Commands;

/// <summary>
/// Удаление объявления
/// </summary>
public sealed class DeleteAnnouncementCommand : IRequest
{
    /// <summary>
    /// Идентификатор объявления
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnAnnouncement { get; init; }
}

public sealed class DeleteAnnouncementCommandHandler : IRequestHandler<DeleteAnnouncementCommand>
{
    private readonly IAnnouncementService _announcementService;
    private readonly DataContext          _dataContext;

    public DeleteAnnouncementCommandHandler(
        DataContext dataContext,
        IAnnouncementService announcementService)
    {
        _dataContext = dataContext;
        _announcementService = announcementService;
    }

    public async Task Handle(DeleteAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var announcement = await _dataContext.Announcements
                                             .Include(x => x.AnnouncementGroups)
                                             .FirstOrDefaultAsync(x => x.IsnAnnouncement == request.IsnAnnouncement,
                                                 cancellationToken)
                           ?? throw new BusinessLogicException(
                               $"Объявление с идентификатором \"{request.IsnAnnouncement}\" не существует");

        await _announcementService.CanDeleteAndThrowAsync(
            _dataContext, announcement, cancellationToken);

        _dataContext.AnnouncementGroups.RemoveRange(announcement.AnnouncementGroups);
        _dataContext.Announcements.Remove(announcement);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}