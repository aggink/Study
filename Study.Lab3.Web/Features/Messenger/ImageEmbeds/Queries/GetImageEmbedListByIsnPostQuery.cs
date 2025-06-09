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
public sealed class GetImageEmbedListByIsnPostQuery : IRequest<ImageEmbedDto[]>
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Required, FromRoute]
    public Guid IsnPost { get; init; }
}

public sealed class GetImageEmbedListByIsnPostQueryHandler : IRequestHandler<GetImageEmbedListByIsnPostQuery, ImageEmbedDto[]>
{
    private readonly DataContext _dataContext;

    public GetImageEmbedListByIsnPostQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ImageEmbedDto[]> Handle(GetImageEmbedListByIsnPostQuery request, CancellationToken cancellationToken)
    {
        var embeds = await _dataContext.ImageEmbeds
                       .AsNoTracking().Where(x => x.IsnPost == request.IsnPost).ToListAsync(cancellationToken)
                   ?? throw new BusinessLogicException($"Прикреплений к сообщению {request.IsnPost} не существует");

        var embedsDto = new ImageEmbedDto[embeds.Count];
        for (int i = 0; i < embeds.Count; i++)
        {
            embedsDto[i] = new ImageEmbedDto
            {
                Isn = embeds[i].Isn,
                IsnPost = embeds[i].IsnPost,
                IsnImage = embeds[i].IsnImage
            };
        }
        return embedsDto;
    }
}
