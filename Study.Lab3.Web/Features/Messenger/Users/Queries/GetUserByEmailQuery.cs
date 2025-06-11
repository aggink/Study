using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Messenger.Users.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Messenger.Users.Queries;

/// <summary>
/// Получение пользователя по почтовому адресу
/// </summary>
public sealed class GetUserByEmailQuery : IRequest<UserDto>
{
    /// <summary>
    /// Почтовый адрес
    /// </summary>
    [Required, FromRoute]
    public string Email { get; init; }
}

public sealed class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserDto>
{
    private readonly DataContext _dataContext;

    public GetUserByEmailQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<UserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await _dataContext.Users
                       .AsNoTracking()
                       .FirstOrDefaultAsync(x => x.Email == request.Email, cancellationToken)
                   ?? throw new BusinessLogicException($"Пользователь с почтовым адресом {request.Email} не существует");

        return new UserDto
        {
            Isn = user.Isn,
            IsnProfilePicture = user.IsnProfilePicture,
            Email = user.Email,
            Username = user.Username,
            Phone = user.Phone,
            Website = user.Website,
            AboutMe = user.AboutMe
        };
    }
}
