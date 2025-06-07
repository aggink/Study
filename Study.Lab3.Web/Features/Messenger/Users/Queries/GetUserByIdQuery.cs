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
public sealed class GetUserByIdQuery : IRequest<UserDto>
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Required, FromRoute]
    public Guid Id { get; init; }
}

public sealed class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly DataContext _dataContext;

    public GetUserByIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _dataContext.Users
                       .AsNoTracking()
                       .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                   ?? throw new BusinessLogicException($"Пользователь {request.Id} не существует");

        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            Username = user.Username,
            Phone = user.Phone,
            Website = user.Website,
            AboutMe = user.AboutMe,
            ProfilePictureId = user.ProfilePictureId
        };
    }
}
