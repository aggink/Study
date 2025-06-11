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
        #region Isn
        if (await dataContext.Users.AnyAsync(x => x.Isn == user.Isn, cancellationToken))
            throw new BusinessLogicException($"Пользователь {user.Isn} уже существует");
        #endregion

        #region Email
        if (user.Email.Length > ModelConstants.User.Email)
            throw new BusinessLogicException("Почтовый адрес слишком длинный");

        if (await dataContext.Users.AnyAsync(x => x.Email == user.Email, cancellationToken))
            throw new BusinessLogicException($"Пользователь с почтовым адресом \"{user.Email}\" уже существует");
        #endregion

        #region Username
        if (string.IsNullOrWhiteSpace(user.Username))
            throw new BusinessLogicException("Имя пользователя не указано");

        if (user.Username.Length > ModelConstants.User.Username)
            throw new BusinessLogicException("Имя пользователя слишком длинное");
        #endregion

        #region Phone
        if (user.Phone.Length > ModelConstants.User.Phone)
            throw new BusinessLogicException("Номер телефона слишком длинный");
        #endregion

        #region Website
        if (user.Website.Length > ModelConstants.User.Website)
            throw new BusinessLogicException("Ссылка на персональный сайт слишком длинная");
        #endregion

        #region ProfilePicture
        if (user.IsnProfilePicture is not null
            && !await dataContext.Images.AnyAsync(x => x.Isn == user.IsnProfilePicture))
            throw new BusinessLogicException($"Изображение {user.IsnProfilePicture} не существует");
        #endregion
    }

    public async Task UpdateUserValidateAndThrowAsync(
        DataContext dataContext,
        User user,
        CancellationToken cancellationToken)
    {
        #region Email
        if (user.Email.Length > ModelConstants.User.Email)
            throw new BusinessLogicException("Почтовый адрес слишком длинный");

        if (await dataContext.Users.AnyAsync(x => x.Email == user.Email && x.Isn != user.Isn, cancellationToken))
            throw new BusinessLogicException($"Пользователь с почтовым адресом \"{user.Email}\" уже существует");
        #endregion

        #region Username
        if (user.Username.Length > ModelConstants.User.Username)
            throw new BusinessLogicException("Имя пользователя слишком длинное");
        #endregion

        #region Phone
        if (user.Phone.Length > ModelConstants.User.Phone)
            throw new BusinessLogicException("Номер телефона слишком длинный");
        #endregion

        #region Website
        if (user.Website.Length > ModelConstants.User.Website)
            throw new BusinessLogicException("Ссылка на персональный сайт слишком длинная");
        #endregion

        #region ProfilePicture
        if (user.IsnProfilePicture is not null
            && !await dataContext.Images.AnyAsync(x => x.Isn == user.IsnProfilePicture))
            throw new BusinessLogicException($"Изображение {user.IsnProfilePicture} не существует");
        #endregion
    }
}
