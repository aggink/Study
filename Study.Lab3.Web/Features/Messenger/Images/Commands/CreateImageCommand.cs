using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Messenger;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Messenger;
using Study.Lab3.Web.Features.Messenger.Images.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Messenger.Images.Commands;

/// <summary>
/// Создание изображения
/// </summary>
public sealed class CreateImageCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные изображения
    /// </summary>
    [Required, FromBody]
    public CreateImageDto Image { get; init; }
}

public sealed class CreatePostCommandHandler : IRequestHandler<CreateImageCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IImageService _imageService;

    public CreatePostCommandHandler(
        DataContext dataContext,
        IImageService imageService)
    {
        _dataContext = dataContext;
        _imageService = imageService;
    }

    public async Task<Guid> Handle(CreateImageCommand request, CancellationToken cancellationToken)
    {
        var image = new Image
        {
            IsnImage = Guid.NewGuid(),
            Description = request.Image.Description,
            IsnUploader = request.Image.IsnUploader,
            Data = request.Image.Data
        };

        await _imageService.CreateImageValidateAndThrowAsync(_dataContext, image, cancellationToken);

        await _dataContext.Images.AddAsync(image, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return image.IsnImage;
    }
}
