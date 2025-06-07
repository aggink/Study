using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Messenger.ImageEmbeds.DtoModels;

namespace Study.Lab3.Web.Features.Messenger.ImageEmbeds.Queries;

/// <summary>
/// Получение пользователя по имени
/// </summary>
public sealed class GetImageEmbedListQuery : IRequest<ImageEmbedDto[]>
{
}

public sealed class GetImageEmbedListQueryHandler : IRequestHandler<GetImageEmbedListQuery, ImageEmbedDto[]>
{
    private readonly DataContext _dataContext;

    public GetImageEmbedListQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ImageEmbedDto[]> Handle(GetImageEmbedListQuery request, CancellationToken cancellationToken)
    {
        var users = await _dataContext.ImageEmbeds.AsNoTracking().ToListAsync(cancellationToken)
                   ?? throw new BusinessLogicException("Нет пользователей");

        var usersDto = new ImageEmbedDto[users.Count];
        for (int i = 0; i < users.Count; i++)
        {
            usersDto[i] = new ImageEmbedDto
            {
                Id = users[i].Id,
                PostId = users[i].PostId,
                ImageId = users[i].ImageId
            };
        }
        return usersDto;
    }
}
