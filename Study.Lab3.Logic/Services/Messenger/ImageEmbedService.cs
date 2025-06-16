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
        #region Isn
        if (await dataContext.ImageEmbeds.AnyAsync(x => x.IsnImageEmbed == embed.IsnImageEmbed, cancellationToken))
            throw new BusinessLogicException($"Внедрение {embed.IsnImageEmbed} уже существует");
        #endregion

        #region PostIsn
        if (!await dataContext.Posts.AnyAsync(x => x.IsnPost == embed.IsnPost, cancellationToken))
            throw new BusinessLogicException($"Сообщение {embed.IsnPost} не существует");
        #endregion

        #region ImageIsn
        if (!await dataContext.Images.AnyAsync(x => x.IsnImage == embed.IsnImage, cancellationToken))
            throw new BusinessLogicException($"Изображение {embed.IsnImage} не существует");
        #endregion

        // Проверка на дубликат
        if (await dataContext.ImageEmbeds.AnyAsync(
                x => x.IsnPost == embed.IsnPost && x.IsnImage == embed.IsnImage, cancellationToken
        ))
            throw new BusinessLogicException($"Вложение {embed.IsnPost}:{embed.IsnImage} уже существует");
    }

    public async Task UpdateImageEmbedValidateAndThrowAsync(
        DataContext dataContext,
        ImageEmbed embed,
        CancellationToken cancellationToken = default)
    {
        #region PostIsn
        if (!await dataContext.Posts.AnyAsync(x => x.IsnPost == embed.IsnPost, cancellationToken))
            throw new BusinessLogicException($"Сообщение {embed.IsnPost} не существует");
        #endregion

        #region ImageIsn
        if (!await dataContext.Images.AnyAsync(x => x.IsnImage == embed.IsnImage, cancellationToken))
            throw new BusinessLogicException($"Изображение {embed.IsnImage} не существует");
        #endregion

        // Проверка на дубликат
        if (await dataContext.ImageEmbeds.AnyAsync(
                x => x.IsnPost == embed.IsnPost && x.IsnImage == embed.IsnImage, cancellationToken
        ))
            throw new BusinessLogicException($"Вложение {embed.IsnPost}:{embed.IsnImage} уже существует");
    }
}
