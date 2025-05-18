using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.University;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.University;
using Study.Lab3.Web.Features.University.Announcements.DtoModels;

namespace Study.Lab3.Web.Features.University.Announcements.Commands;

/// <summary>
/// Добавление группы к объявлению
/// </summary>
public sealed class AddGroupToAnnouncementCommand : IRequest
{
    /// <summary>
    /// Данные привязки группы к объявлению
    /// </summary>
    [Required]
    [FromBody]
    public AddGroupToAnnouncementDto AnnouncementGroup { get; init; }
}

public sealed class AddGroupToAnnouncementCommandHandler : IRequestHandler<AddGroupToAnnouncementCommand>
{
    private readonly IAnnouncementService _announcementService;
    private readonly DataContext          _dataContext;

    public AddGroupToAnnouncementCommandHandler(
        DataContext dataContext,
        IAnnouncementService announcementService)
    {
        _dataContext = dataContext;
        _announcementService = announcementService;
    }

    public async Task Handle(AddGroupToAnnouncementCommand request, CancellationToken cancellationToken)
    {
        var announcementGroup = new AnnouncementGroup
        {
            IsnAnnouncement = request.AnnouncementGroup.IsnAnnouncement,
            IsnGroup = request.AnnouncementGroup.IsnGroup
        };

        await _announcementService.AddGroupValidateAndThrowAsync(
            _dataContext, announcementGroup, cancellationToken);

        await _dataContext.AnnouncementGroups.AddAsync(announcementGroup, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}