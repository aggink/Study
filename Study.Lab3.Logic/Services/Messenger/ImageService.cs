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
        #region Id
        if (await dataContext.Images.AnyAsync(x => x.Id == image.Id, cancellationToken))
            throw new BusinessLogicException($"Изображение {image.Id} уже существует");
        #endregion

        #region Description
        if (await Task.Run(() => { return image.Description.Length > ModelConstants.Image.Description; }))
            throw new BusinessLogicException("Описание слишком длинное");
        #endregion

        #region UploaderId
        if (!await dataContext.Users.AnyAsync(x => x.Id == image.UploaderId, cancellationToken))
            throw new BusinessLogicException($"Пользователь {image.UploaderId} не существует");
        #endregion

        #region Data
        if (await Task.Run(() => { return image.Data.Length == 0; }))
            throw new BusinessLogicException("Изображение пустое");
        #endregion
    }

    public async Task UpdateImageValidateAndThrowAsync(
        DataContext dataContext,
        Image image,
        CancellationToken cancellationToken = default)
    {
        #region Description
        if (await Task.Run(() => { return image.Description.Length > ModelConstants.Image.Description; }))
            throw new BusinessLogicException("Описание слишком длинное");
        #endregion

        #region Data
        if (await Task.Run(() => { return image.Data.Length == 0; }))
            throw new BusinessLogicException("Изображение пустое");
        #endregion
    }
}
