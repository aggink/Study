using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Messenger;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Messenger.Users.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Messenger.Users.Commands;

/// <summary>
/// Обновление пользователя
/// </summary>
public sealed class UpdateUserCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные пользователя
    /// </summary>
    [Required, FromBody]
    public UpdateUserDto User { get; init; }
}

public sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IUserService _userService;

    public UpdateUserCommandHandler(
        DataContext dataContext,
        IUserService userService)
    {
        _dataContext = dataContext;
        _userService = userService;
    }

    public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _dataContext.Users
                       .FirstOrDefaultAsync(x => x.IsnUser == request.User.Isn, cancellationToken)
                   ?? throw new BusinessLogicException($"Пользователь {request.User.Isn} не существует");

        if (request.User.IsnProfilePicture is not null) user.IsnProfilePicture = request.User.IsnProfilePicture;
        if (request.User.Email is not null) user.Email = request.User.Email;
        if (request.User.Username is not null) user.Username = request.User.Username;
        if (request.User.Phone is not null) user.Phone = request.User.Phone;
        if (request.User.Website is not null) user.Website = request.User.Website;
        if (request.User.AboutMe is not null) user.AboutMe = request.User.AboutMe;

        await _userService.UpdateUserValidateAndThrowAsync(_dataContext, user, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return user.IsnUser;
    }
}
