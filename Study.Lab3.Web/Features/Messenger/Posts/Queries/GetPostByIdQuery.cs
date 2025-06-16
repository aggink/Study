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
public sealed class GetPostByIdQuery : IRequest<PostDto>
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Required, FromRoute]
    public Guid Isn { get; init; }
}

public sealed class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, PostDto>
{
    private readonly DataContext _dataContext;

    public GetPostByIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PostDto> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var post = await _dataContext.Posts
                       .AsNoTracking().FirstOrDefaultAsync(x => x.IsnPost == request.Isn, cancellationToken)
                   ?? throw new BusinessLogicException($"Сообщение {request.Isn} не существует");

        return new PostDto
        {
            Isn = post.IsnPost,
            IsnUser = post.IsnUser,
            Message = post.Message
        };
    }
}
