/*using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.Announcements.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.University.Announcements.Commands;

/// <summary>
/// Создание объявления
/// </summary>
public sealed class CreateAnnouncementCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные объявления
    /// </summary>
    [Required]
    [FromBody]
    public CreateAnnouncementDto Announcement { get; init; }
}

public sealed class CreateAnnouncementCommandHandler : IRequestHandler<CreateAnnouncementCommand, Guid>
{
    private readonly IAnnouncementService _announcementService;
    private readonly DataContext _dataContext;

    public CreateAnnouncementCommandHandler(
        DataContext dataContext,
        IAnnouncementService announcementService)
    {
        _dataContext = dataContext;
        _announcementService = announcementService;
    }

    public async Task<Guid> Handle(CreateAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var announcement = new Announcement
        {
            IsnAnnouncement = Guid.NewGuid(),
            IsnTeacher = request.Announcement.IsnTeacher,
            Title = request.Announcement.Title,
            Content = request.Announcement.Content,
            PublishDate = request.Announcement.PublishDate,
            IsImportant = request.Announcement.IsImportant,
            AnnouncementGroups = new List<AnnouncementGroup>()
        };

        await _announcementService.CreateOrUpdateAnnouncementValidateAndThrowAsync(
            _dataContext, announcement, cancellationToken);

        await _dataContext.Announcements.AddAsync(announcement, cancellationToken);

        // Добавление связей с группами
        if (request.Announcement.GroupIds != null && request.Announcement.GroupIds.Length > 0)
            foreach (var groupId in request.Announcement.GroupIds)
            {
                var announcementGroup = new AnnouncementGroup
                {
                    IsnAnnouncement = announcement.IsnAnnouncement,
                    IsnGroup = groupId
                };

                await _announcementService.AddGroupValidateAndThrowAsync(
                    _dataContext, announcementGroup, cancellationToken, true); // true - пропустить проверку

                await _dataContext.AnnouncementGroups.AddAsync(announcementGroup, cancellationToken);
            }

        // Единственный SaveChangesAsync в конце всех операций
        await _dataContext.SaveChangesAsync(cancellationToken);

        return announcement.IsnAnnouncement;
    }
}*/