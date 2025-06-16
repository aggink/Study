using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Messenger;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Messenger.Posts.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Messenger.Posts.Commands;

/// <summary>
/// Обновление меню
/// </summary>
public sealed class UpdatePostCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные меню
    /// </summary>
    [Required, FromBody]
    public UpdatePostDto Post { get; init; }
}

public sealed class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPostService _postService;

    public UpdatePostCommandHandler(
        DataContext dataContext,
        IPostService postService)
    {
        _dataContext = dataContext;
        _postService = postService;
    }

    public async Task<Guid> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _dataContext.Posts
                       .FirstOrDefaultAsync(x => x.IsnPost == request.Post.Isn, cancellationToken)
                   ?? throw new BusinessLogicException($"Пост {request.Post.Isn} не существует");

        post.Message = request.Post.Message;

        await _postService.UpdatePostValidateAndThrowAsync(_dataContext, post, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return post.IsnPost;
    }
}
