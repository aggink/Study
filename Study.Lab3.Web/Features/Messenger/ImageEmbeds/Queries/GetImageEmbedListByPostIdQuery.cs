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
public sealed class GetImageEmbedListByPostIdQuery : IRequest<ImageEmbedDto[]>
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Required, FromRoute]
    public Guid PostId { get; init; }
}

public sealed class GetImageEmbedListByPostIdQueryHandler : IRequestHandler<GetImageEmbedListByPostIdQuery, ImageEmbedDto[]>
{
    private readonly DataContext _dataContext;

    public GetImageEmbedListByPostIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ImageEmbedDto[]> Handle(GetImageEmbedListByPostIdQuery request, CancellationToken cancellationToken)
    {
        var embeds = await _dataContext.ImageEmbeds
                       .AsNoTracking().Where(x => x.PostId == request.PostId).ToListAsync(cancellationToken)
                   ?? throw new BusinessLogicException($"Прикреплений к сообщению {request.PostId} не существует");

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
