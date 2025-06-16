using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Messenger;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Messenger;

namespace Study.Lab3.Logic.Services.Messenger;

public sealed class PostService : IPostService
{
    public async Task CreatePostValidateAndThrowAsync(
        DataContext dataContext,
        Post post,
        CancellationToken cancellationToken = default)
    {
        #region Isn
        if (await dataContext.Posts.AnyAsync(x => x.IsnPost == post.IsnPost, cancellationToken))
            throw new BusinessLogicException($"Сообщение {post.IsnPost} уже существует");
        #endregion

        #region UserId
        if (!await dataContext.Users.AnyAsync(x => x.IsnUser == post.IsnUser, cancellationToken))
            throw new BusinessLogicException($"Пользователь {post.IsnUser} не существует");
        #endregion

        #region Message
        if (string.IsNullOrWhiteSpace(post.Message))
            throw new BusinessLogicException("Не указано сообщение");
        #endregion
    }

    public async Task UpdatePostValidateAndThrowAsync(
        DataContext dataContext,
        Post post,
        CancellationToken cancellationToken = default)
    {
        #region Message
        if (string.IsNullOrWhiteSpace(post.Message))
            throw new BusinessLogicException("Не указано сообщение");
        #endregion
    }
}
