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
public sealed class GetImageByIdQuery : IRequest<ImageDto>
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Required, FromRoute]
    public Guid Id { get; init; }
}

public sealed class GetImageByIdQueryHandler : IRequestHandler<GetImageByIdQuery, ImageDto>
{
    private readonly DataContext _dataContext;

    public GetImageByIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ImageDto> Handle(GetImageByIdQuery request, CancellationToken cancellationToken)
    {
        var post = await _dataContext.Images
                       .AsNoTracking()
                       .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                   ?? throw new BusinessLogicException($"Изображение {request.Id} не существует");

        return new ImageDto
        {
            Id = post.Id,
            Description = post.Description,
            UploaderId = post.UploaderId,
            Data = post.Data
        };
    }
}
