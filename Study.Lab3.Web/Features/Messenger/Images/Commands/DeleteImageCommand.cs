using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Messenger.Images.Commands;

/// <summary>
/// Удаление меню
/// </summary>
public sealed class DeleteImageCommand : IRequest
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Required, FromBody]
    public Guid Id { get; init; }
}

public sealed class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand>
{
    private readonly DataContext _dataContext;

    public DeleteImageCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(DeleteImageCommand request, CancellationToken cancellationToken)
    {
        var image = await _dataContext.Images
                       .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                   ?? throw new BusinessLogicException($"Изображение {request.Id} не существует");

        _dataContext.Images.Remove(image);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}
