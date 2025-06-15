using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Messenger;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Messenger.Images.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Messenger.Images.Commands;

/// <summary>
/// Обновление меню
/// </summary>
public sealed class UpdateImageCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные меню
    /// </summary>
    [Required, FromBody]
    public UpdateImageDto Image { get; init; }
}

public sealed class UpdateImageCommandHandler : IRequestHandler<UpdateImageCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IImageService _imageService;

    public UpdateImageCommandHandler(
        DataContext dataContext,
        IImageService imageService)
    {
        _dataContext = dataContext;
        _imageService = imageService;
    }

    public async Task<Guid> Handle(UpdateImageCommand request, CancellationToken cancellationToken)
    {
        var image = await _dataContext.Images
                       .FirstOrDefaultAsync(x => x.Isn == request.Image.Isn, cancellationToken)
                   ?? throw new BusinessLogicException($"Изображение {request.Image.Isn} не существует");

        if (request.Image.Description is not null) image.Description = request.Image.Description;
        if (request.Image.Data is not null) image.Data = request.Image.Data;

        await _imageService.UpdateImageValidateAndThrowAsync(_dataContext, image, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return image.Isn;
    }
}
