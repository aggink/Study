using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Messenger.Users.DtoModels;

namespace Study.Lab3.Web.Features.Messenger.Users.Queries;

/// <summary>
/// Получение списка пользователей
/// </summary>
public sealed class GetUserListQuery : IRequest<UserDto[]>
{
}

public sealed class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, UserDto[]>
{
    private readonly DataContext _dataContext;

    public GetUserListQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<UserDto[]> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var users = await _dataContext.Users.AsNoTracking().ToListAsync(cancellationToken)
                   ?? throw new BusinessLogicException("Нет пользователей");

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
