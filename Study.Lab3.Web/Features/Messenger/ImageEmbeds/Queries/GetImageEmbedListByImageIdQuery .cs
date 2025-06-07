using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Messenger.ImageEmbeds.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Messenger.ImageEmbeds.Queries;

/// <summary>
/// Получение прикрепления по идентификатору
/// </summary>
public sealed class GetImageEmbedListByImageIdQuery : IRequest<ImageEmbedDto[]>
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Required, FromRoute]
    public Guid ImageId { get; init; }
}

public sealed class GetImageEmbedListByImageIdQueryHandler : IRequestHandler<GetImageEmbedListByImageIdQuery, ImageEmbedDto[]>
{
    private readonly DataContext _dataContext;

    public GetImageEmbedListByImageIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ImageEmbedDto[]> Handle(GetImageEmbedListByImageIdQuery request, CancellationToken cancellationToken)
    {
        var embeds = await _dataContext.ImageEmbeds
                       .AsNoTracking().Where(x => x.ImageId == request.ImageId).ToListAsync(cancellationToken)
                   ?? throw new BusinessLogicException($"Прикреплений с изображением {request.ImageId} не существует");

        var embedsDto = new ImageEmbedDto[embeds.Count];
        for (int i = 0; i < embeds.Count; i++)
        {
            embedsDto[i] = new ImageEmbedDto
            {
                Id = embeds[i].Id,
                PostId = embeds[i].PostId,
                ImageId = embeds[i].ImageId
            };
        }
        return embedsDto;
    }
}
