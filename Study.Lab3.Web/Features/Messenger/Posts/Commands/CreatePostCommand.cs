using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Messenger;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Messenger;
using Study.Lab3.Web.Features.Messenger.Posts.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Messenger.Posts.Commands;

/// <summary>
/// Создание меню
/// </summary>
public sealed class CreatePostCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные меню
    /// </summary>
    [Required, FromBody]
    public CreatePostDto Post { get; init; }
}

public sealed class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPostService _postService;

    public CreatePostCommandHandler(
        DataContext dataContext,
        IPostService postService)
    {
        _dataContext = dataContext;
        _postService = postService;
    }

    public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var post = new Post
        {
            Isn = Guid.NewGuid(),
            IsnUser = request.Post.IsnUser,
            Message = request.Post.Message
        };

        await _postService.CreatePostValidateAndThrowAsync(_dataContext, post, cancellationToken);

        await _dataContext.Posts.AddAsync(post, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return post.Isn;
    }
}
