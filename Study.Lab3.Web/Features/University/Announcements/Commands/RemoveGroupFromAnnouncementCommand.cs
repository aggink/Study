/*using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Announcements.Commands;

/// <summary>
/// Удаление группы из объявления
/// </summary>
public sealed class RemoveGroupFromAnnouncementCommand : IRequest
{
    /// <summary>
    /// Идентификатор объявления
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnAnnouncement { get; init; }

    /// <summary>
    /// Идентификатор группы
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnGroup { get; init; }
}

public sealed class RemoveGroupFromAnnouncementCommandHandler : IRequestHandler<RemoveGroupFromAnnouncementCommand>
{
    private readonly DataContext _dataContext;

    public RemoveGroupFromAnnouncementCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(RemoveGroupFromAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var announcementGroup = await _dataContext.AnnouncementGroups
                                    .FirstOrDefaultAsync(x =>
                                            x.IsnAnnouncement == request.IsnAnnouncement &&
                                            x.IsnGroup == request.IsnGroup,
                                        cancellationToken)
                                ?? throw new BusinessLogicException(
                                    "Указанная группа не привязана к данному объявлению");

        _dataContext.AnnouncementGroups.Remove(announcementGroup);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}*/