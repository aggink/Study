using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Messenger;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Messenger;
using Study.Lab3.Web.Features.Messenger.ImageEmbeds.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Messenger.ImageEmbeds.Commands;

/// <summary>
/// Создание прикрепления
/// </summary>
public sealed class CreateImageEmbedCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные прикрепления
    /// </summary>
    [Required, FromBody]
    public CreateImageEmbedDto ImageEmbed { get; init; }
}

public sealed class CreateImageEmbedCommandHandler : IRequestHandler<CreateImageEmbedCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IImageEmbedService _imageEmbedService;

    public CreateImageEmbedCommandHandler(
        DataContext dataContext,
        IImageEmbedService imageEmbedService)
    {
        _dataContext = dataContext;
        _imageEmbedService = imageEmbedService;
    }

    public async Task<Guid> Handle(CreateImageEmbedCommand request, CancellationToken cancellationToken)
    {
        var embed = new ImageEmbed
        {
            Id = Guid.NewGuid(),
            PostId = request.ImageEmbed.PostId,
            ImageId = request.ImageEmbed.ImageId,
        };

        await _imageEmbedService.CreateImageEmbedValidateAndThrowAsync(_dataContext, embed, cancellationToken);

        await _dataContext.ImageEmbeds.AddAsync(embed, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return embed.Id;
    }
}
