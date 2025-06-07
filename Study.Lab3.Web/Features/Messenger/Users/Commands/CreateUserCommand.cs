using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Messenger;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Messenger;
using Study.Lab3.Web.Features.Messenger.Users.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Messenger.Users.Commands;

/// <summary>
/// Создание пользователя
/// </summary>
public sealed class CreateUserCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные пользователя
    /// </summary>
    [Required, FromBody]
    public CreateUserDto User { get; init; }
}

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IUserService _userService;

    public CreateUserCommandHandler(
        DataContext dataContext,
        IUserService userService)
    {
        _dataContext = dataContext;
        _userService = userService;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = request.User.Email,
            Username = request.User.Username,
            Phone = request.User.Phone,
            Website = request.User.Website,
            AboutMe = request.User.AboutMe,
            ProfilePictureId = request.User.ProfilePicture
        };

        await _userService.CreateUserValidateAndThrowAsync(_dataContext, user, cancellationToken);

        await _dataContext.Users.AddAsync(user, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
