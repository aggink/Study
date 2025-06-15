using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Messenger.Posts.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Messenger.Posts.Queries;

/// <summary>
/// Получение сообщения по идентификатору
/// </summary>
public sealed class GetPostListByIsnUserQuery : IRequest<PostDto[]>
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Required, FromRoute]
    public Guid IsnUser { get; init; }
}

public sealed class GetPostListByIsnUserQueryHandler : IRequestHandler<GetPostListByIsnUserQuery, PostDto[]>
{
    private readonly DataContext _dataContext;

    public GetPostListByIsnUserQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PostDto[]> Handle(GetPostListByIsnUserQuery request, CancellationToken cancellationToken)
    {
        var posts = await _dataContext.Posts
                       .AsNoTracking().Where(x => x.IsnUser == request.IsnUser).ToListAsync(cancellationToken)
                   ?? throw new BusinessLogicException($"Постов от пользователя {request.IsnUser} не существует");

        var postsDto = new PostDto[posts.Count];
        for (int i = 0; i < posts.Count; i++)
        {
            postsDto[i] = new PostDto
            {
                Isn = posts[i].Isn,
                IsnUser = posts[i].IsnUser,
                Message = posts[i].Message
            };
        }
        return postsDto;
    }
}
