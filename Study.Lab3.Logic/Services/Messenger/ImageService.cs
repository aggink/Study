using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Messenger;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Messenger;

namespace Study.Lab3.Logic.Services.Messenger;

public sealed class ImageService : IImageService
{
    public async Task CreateImageValidateAndThrowAsync(
        DataContext dataContext,
        Image image,
        CancellationToken cancellationToken = default)
    {
        #region Isn
        if (await dataContext.Images.AnyAsync(x => x.IsnImage == image.IsnImage, cancellationToken))
            throw new BusinessLogicException($"Изображение {image.IsnImage} уже существует");
        #endregion

        #region Description
        if (image.Description.Length > ModelConstants.Image.Description)
            throw new BusinessLogicException("Описание слишком длинное");
        #endregion

        #region UploaderIsn
        if (!await dataContext.Users.AnyAsync(x => x.IsnUser == image.IsnUploader, cancellationToken))
            throw new BusinessLogicException($"Пользователь {image.IsnUploader} не существует");
        #endregion

        #region Data
        if (image.Data.Length == 0)
            throw new BusinessLogicException("Изображение пустое");
        #endregion
    }

    public async Task UpdateImageValidateAndThrowAsync(
        DataContext dataContext,
        Image image,
        CancellationToken cancellationToken = default)
    {
        #region Description
        if (image.Description.Length > ModelConstants.Image.Description)
            throw new BusinessLogicException("Описание слишком длинное");
        #endregion

        #region Data
        if (image.Data.Length == 0)
            throw new BusinessLogicException("Изображение пустое");
        #endregion
    }
}
