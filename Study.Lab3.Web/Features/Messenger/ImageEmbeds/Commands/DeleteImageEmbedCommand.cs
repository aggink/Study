using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Messenger.ImageEmbeds.Commands;

/// <summary>
/// Удаление прикрепления
/// </summary>
public sealed class DeleteImageEmbedCommand : IRequest
{
    /// <summary>
    /// Идентификатор поста
    /// </summary>
    [Required, FromBody]
    public Guid Isn { get; init; }
}

public sealed class DeleteImageEmbedCommandHandler : IRequestHandler<DeleteImageEmbedCommand>
{
    private readonly DataContext _dataContext;

    public DeleteImageEmbedCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(DeleteImageEmbedCommand request, CancellationToken cancellationToken)
    {
        var embed = await _dataContext.ImageEmbeds
                       .FirstOrDefaultAsync(x => x.IsnImageEmbed == request.Isn, cancellationToken)
                   ?? throw new BusinessLogicException($"Прикрепление {request.Isn} не существует");

        _dataContext.ImageEmbeds.Remove(embed);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}
