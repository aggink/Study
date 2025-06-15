using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Messenger.Posts.DtoModels;

namespace Study.Lab3.Web.Features.Messenger.Posts.Queries;

/// <summary>
/// Получение пользователя по имени
/// </summary>
public sealed class GetPostListQuery : IRequest<PostDto[]>
{
}

public sealed class GetPostListQueryHandler : IRequestHandler<GetPostListQuery, PostDto[]>
{
    private readonly DataContext _dataContext;

    public GetPostListQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PostDto[]> Handle(GetPostListQuery request, CancellationToken cancellationToken)
    {
        var posts = await _dataContext.Posts.AsNoTracking().ToListAsync(cancellationToken)
                   ?? throw new BusinessLogicException("Нет пользователей");

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
