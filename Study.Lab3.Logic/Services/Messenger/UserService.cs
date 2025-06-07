using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Messenger;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Messenger;

namespace Study.Lab3.Logic.Services.Messenger;

public sealed class UserService : IUserService
{
    public async Task CreateUserValidateAndThrowAsync(
        DataContext dataContext,
        User user,
        CancellationToken cancellationToken = default)
    {
        #region Id
        if (await dataContext.Users.AnyAsync(x => x.Id == user.Id, cancellationToken))
            throw new BusinessLogicException($"Пользователь {user.Id} уже существует");
        #endregion

        #region Email
        if (await Task.Run(() => { return user.Email.Length > ModelConstants.User.Email; }))
            throw new BusinessLogicException("Почтовый адрес слишком длинный");

        if (await dataContext.Users.AnyAsync(x => x.Email == user.Email, cancellationToken))
            throw new BusinessLogicException($"Пользователь с почтовым адресом \"{user.Email}\" уже существует");
        #endregion

        #region Username
        if (await Task.Run(() => { return string.IsNullOrWhiteSpace(user.Username); }))
            throw new BusinessLogicException("Имя пользователя не указано");

        if (await Task.Run(() => { return user.Username.Length > ModelConstants.User.Username; }))
            throw new BusinessLogicException("Имя пользователя слишком длинное");
        #endregion

        #region Phone
        if (await Task.Run(() => { return user.Phone.Length > ModelConstants.User.Phone; }))
            throw new BusinessLogicException("Номер телефона слишком длинный");
        #endregion

        #region Website
        if (await Task.Run(() => { return user.Website.Length > ModelConstants.User.Website; }))
            throw new BusinessLogicException("Ссылка на персональный сайт слишком длинная");
        #endregion

        #region ProfilePicture
        if (await Task.Run(() => { return user.ProfilePictureId is not null; })
            && !await dataContext.Images.AnyAsync(x => x.Id == user.ProfilePictureId))
            throw new BusinessLogicException($"Изображение {user.ProfilePictureId} не существует");
        #endregion
    }

    public async Task UpdateUserValidateAndThrowAsync(
        DataContext dataContext,
        User user,
        CancellationToken cancellationToken)
    {
        #region Email
        if (await Task.Run(() => { return user.Email.Length > ModelConstants.User.Email; }))
            throw new BusinessLogicException("Почтовый адрес слишком длинный");

        if (await dataContext.Users.AnyAsync(x => x.Email == user.Email && x.Id != user.Id, cancellationToken))
            throw new BusinessLogicException($"Пользователь с почтовым адресом \"{user.Email}\" уже существует");
        #endregion

        #region Username
        if (await Task.Run(() => { return user.Username.Length > ModelConstants.User.Username; }))
            throw new BusinessLogicException("Имя пользователя слишком длинное");
        #endregion

        #region Phone
        if (await Task.Run(() => { return user.Phone.Length > ModelConstants.User.Phone; }))
            throw new BusinessLogicException("Номер телефона слишком длинный");
        #endregion

        #region Website
        if (await Task.Run(() => { return user.Website.Length > ModelConstants.User.Website; }))
            throw new BusinessLogicException("Ссылка на персональный сайт слишком длинная");
        #endregion

        #region ProfilePicture
        if (await Task.Run(() => { return user.ProfilePictureId is not null; })
            && !await dataContext.Images.AnyAsync(x => x.Id == user.ProfilePictureId))
            throw new BusinessLogicException($"Изображение {user.ProfilePictureId} не существует");
        #endregion
    }
}
