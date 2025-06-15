using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Messenger.Users.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Messenger.Users.Queries;

/// <summary>
/// Получение пользователя по идентификатору
/// </summary>
public sealed class GetUserByIsnQuery : IRequest<UserDto>
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Required, FromRoute]
    public Guid Isn { get; init; }
}

public sealed class GetUserByIsnQueryHandler : IRequestHandler<GetUserByIsnQuery, UserDto>
{
    private readonly DataContext _dataContext;

    public GetUserByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<UserDto> Handle(GetUserByIsnQuery request, CancellationToken cancellationToken)
    {
        var user = await _dataContext.Users
                       .AsNoTracking()
                       .FirstOrDefaultAsync(x => x.Isn == request.Isn, cancellationToken)
                   ?? throw new BusinessLogicException($"Пользователь {request.Isn} не существует");

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
