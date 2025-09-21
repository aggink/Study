using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.GameStore.Platforms.DtoModels;

namespace Study.Lab3.Web.Features.GameStore.Platforms.Queries;

/// <summary>
/// Получение платформы по идентификатору
/// </summary>
public sealed class GetPlatformByIsnQuery : IRequest<PlatformDto>
{
    /// <summary>
    /// Идентификатор платформы
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnPlatform { get; init; }
}

public sealed class GetPlatformByIsnQueryHandler : IRequestHandler<GetPlatformByIsnQuery, PlatformDto>
{
    private readonly DataContext _dataContext;

    public GetPlatformByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PlatformDto> Handle(GetPlatformByIsnQuery request, CancellationToken cancellationToken)
    {
        var platform = await _dataContext.Platforms
                           .AsNoTracking()
                           .FirstOrDefaultAsync(x => x.IsnPlatform == request.IsnPlatform, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Платформа с идентификатором \"{request.IsnPlatform}\" не существует");

        return new PlatformDto
        {
            IsnPlatform = platform.IsnPlatform,
            Name = platform.Name,
            Manufacturer = platform.Manufacturer,
            Type = platform.Type,
            ReleaseDate = platform.ReleaseDate,
            IsActive = platform.IsActive,
            Description = platform.Description,
            Generation = platform.Generation,
            SupportsOnlineGaming = platform.SupportsOnlineGaming
        };
    }
}