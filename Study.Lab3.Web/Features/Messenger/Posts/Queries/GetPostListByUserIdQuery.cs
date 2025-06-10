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
public sealed class GetPostListByUserIdQuery : IRequest<PostDto[]>
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Required, FromRoute]
    public Guid IsnUser { get; init; }
}

public sealed class GetPostListByUserIdQueryHandler : IRequestHandler<GetPostListByUserIdQuery, PostDto[]>
{
    private readonly DataContext _dataContext;

    public GetPostListByUserIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PostDto[]> Handle(GetPostListByUserIdQuery request, CancellationToken cancellationToken)
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
