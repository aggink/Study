using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Messenger;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Messenger;

namespace Study.Lab3.Logic.Services.Messenger;

public sealed class ImageEmbedService : IImageEmbedService
{
    public async Task CreateImageEmbedValidateAndThrowAsync(
        DataContext dataContext,
        ImageEmbed embed,
        CancellationToken cancellationToken = default)
    {
        #region Id
        if (await dataContext.ImageEmbeds.AnyAsync(x => x.Id == embed.Id, cancellationToken))
            throw new BusinessLogicException($"Внедрение {embed.Id} уже существует");
        #endregion

        #region PostId
        if (!await dataContext.Posts.AnyAsync(x => x.Id == embed.PostId, cancellationToken))
            throw new BusinessLogicException($"Сообщение {embed.PostId} не существует");
        #endregion

        #region ImageId
        if (!await dataContext.Images.AnyAsync(x => x.Id == embed.ImageId, cancellationToken))
            throw new BusinessLogicException($"Изображение {embed.ImageId} не существует");
        #endregion

        // Проверка на дубликат
        if (await dataContext.ImageEmbeds.AnyAsync(
                x => x.PostId == embed.PostId && x.ImageId == embed.ImageId, cancellationToken
        ))
            throw new BusinessLogicException($"Внедрение {embed.PostId}:{embed.ImageId} уже существует");
    }

    public async Task UpdateImageEmbedValidateAndThrowAsync(
        DataContext dataContext,
        ImageEmbed embed,
        CancellationToken cancellationToken = default)
    {
        #region PostId
        if (!await dataContext.Posts.AnyAsync(x => x.Id == embed.PostId, cancellationToken))
            throw new BusinessLogicException($"Сообщение {embed.PostId} не существует");
        #endregion

        #region ImageId
        if (!await dataContext.Images.AnyAsync(x => x.Id == embed.ImageId, cancellationToken))
            throw new BusinessLogicException($"Изображение {embed.ImageId} не существует");
        #endregion

        // Проверка на дубликат
        if (await dataContext.ImageEmbeds.AnyAsync(
                x => x.PostId == embed.PostId && x.ImageId == embed.ImageId, cancellationToken
        ))
            throw new BusinessLogicException($"Внедрение {embed.PostId}:{embed.ImageId} уже существует");
    }
}
