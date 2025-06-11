using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Messenger;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Messenger.ImageEmbeds.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Messenger.ImageEmbeds.Commands;

/// <summary>
/// Обновление вставки
/// </summary>
public sealed class UpdateImageEmbedCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные вставки
    /// </summary>
    [Required]
    [FromBody]
    public UpdateImageEmbedDto Embed { get; init; }
}

public sealed class UpdateImageEmbedCommandHandler : IRequestHandler<UpdateImageEmbedCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IImageEmbedService _imageEmbedService;

    public UpdateImageEmbedCommandHandler(
        DataContext dataContext,
        IImageEmbedService imageEmbedService)
    {
        _dataContext = dataContext;
        _imageEmbedService = imageEmbedService;
    }

    public async Task<Guid> Handle(UpdateImageEmbedCommand request, CancellationToken cancellationToken)
    {
        var embed = await _dataContext.ImageEmbeds
                       .FirstOrDefaultAsync(x => x.Isn == request.Embed.Isn, cancellationToken)
                   ?? throw new BusinessLogicException($"Вставка {request.Embed.Isn} не существует");

        if (request.Embed.IsnPost is not null) embed.IsnPost = (Guid)request.Embed.IsnPost;
        if (request.Embed.IsnImage is not null) embed.IsnImage = (Guid)request.Embed.IsnImage;

        await _imageEmbedService.UpdateImageEmbedValidateAndThrowAsync(_dataContext, embed, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);

        return embed.Isn;
    }
}
