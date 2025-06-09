using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Messenger.Images.DtoModels;

namespace Study.Lab3.Web.Features.Messenger.Images.Queries;

/// <summary>
/// Получение пользователя по имени
/// </summary>
public sealed class GetImageListQuery : IRequest<ImageDto[]>
{
}

public sealed class GetImageListQueryHandler : IRequestHandler<GetImageListQuery, ImageDto[]>
{
    private readonly DataContext _dataContext;

    public GetImageListQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ImageDto[]> Handle(GetImageListQuery request, CancellationToken cancellationToken)
    {
        var images = await _dataContext.Images.AsNoTracking().ToListAsync(cancellationToken)
                   ?? throw new BusinessLogicException("Нет пользователей");

        var imagesDto = new ImageDto[images.Count];
        for (int i = 0; i < images.Count; i++)
        {
            imagesDto[i] = new ImageDto
            {
                Isn = images[i].Isn,
                Description = images[i].Description,
                IsnUploader = images[i].IsnUploader,
                Data = images[i].Data
            };
        }
        return imagesDto;
    }
}
