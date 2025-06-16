using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Messenger.Users.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Messenger.Users.Queries;

/// <summary>
/// Получение пользователей по имени
/// </summary>
public sealed class GetUserListByUsernameQuery : IRequest<UserDto[]>
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    [Required, FromRoute]
    public string Username { get; init; }
}

public sealed class GetUserListByUsernameQueryHandler : IRequestHandler<GetUserListByUsernameQuery, UserDto[]>
{
    private readonly DataContext _dataContext;

    public GetUserListByUsernameQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<UserDto[]> Handle(GetUserListByUsernameQuery request, CancellationToken cancellationToken)
    {
        var users = await _dataContext.Users
                       .AsNoTracking().Where(x => x.Username == request.Username).ToListAsync(cancellationToken)
                   ?? throw new BusinessLogicException($"Прикреплений к сообщению {request.Username} не существует");

        var usersDto = new UserDto[users.Count];
        for (int i = 0; i < users.Count; i++)
        {
            usersDto[i] = new UserDto
            {
                Isn = users[i].IsnUser,
                IsnProfilePicture = users[i].IsnProfilePicture,
                Email = users[i].Email,
                Username = users[i].Username,
                Phone = users[i].Phone,
                Website = users[i].Website,
                AboutMe = users[i].AboutMe
            };
        }
        return usersDto;
    }
}
