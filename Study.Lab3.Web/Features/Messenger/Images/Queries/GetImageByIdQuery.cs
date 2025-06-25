using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Messenger.Images.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Messenger.Images.Queries;

/// <summary>
/// Получение изображения по идентификатору
/// </summary>
public sealed class GetImageByIsnQuery : IRequest<ImageDto>
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Required, FromRoute]
    public Guid Isn { get; init; }
}

public sealed class GetImageByIsnQueryHandler : IRequestHandler<GetImageByIsnQuery, ImageDto>
{
    private readonly DataContext _dataContext;

    public GetImageByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ImageDto> Handle(GetImageByIsnQuery request, CancellationToken cancellationToken)
    {
        var post = await _dataContext.Images
                       .AsNoTracking()
                       .FirstOrDefaultAsync(x => x.IsnImage == request.Isn, cancellationToken)
                   ?? throw new BusinessLogicException($"Изображение {request.Isn} не существует");

        return new ImageDto
        {
            Isn = post.IsnImage,
            Description = post.Description,
            IsnUploader = post.IsnUploader,
            Data = post.Data
        };
    }
}
