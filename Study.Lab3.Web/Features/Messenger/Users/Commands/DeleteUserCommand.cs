using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Messenger.Users.Commands;

/// <summary>
/// Удаление пользователя
/// </summary>
public sealed class DeleteUserCommand : IRequest
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Required, FromBody]
    public Guid Id { get; init; }
}

public sealed class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly DataContext _dataContext;

    public DeleteUserCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _dataContext.Users
                       .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                   ?? throw new BusinessLogicException($"Пользователь {request.Id} не существует");

        _dataContext.Users.Remove(user);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}
