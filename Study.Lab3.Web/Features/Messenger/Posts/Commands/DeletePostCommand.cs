using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Messenger.Posts.Commands;

/// <summary>
/// Удаление меню
/// </summary>
public sealed class DeletePostCommand : IRequest
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Required, FromBody]
    public Guid Id { get; init; }
}

public sealed class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
{
    private readonly DataContext _dataContext;

    public DeletePostCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _dataContext.Posts
                       .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                   ?? throw new BusinessLogicException($"Пост {request.Id} не существует");

        _dataContext.Posts.Remove(post);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}
