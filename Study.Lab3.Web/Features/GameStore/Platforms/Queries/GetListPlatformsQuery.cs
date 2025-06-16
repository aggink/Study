using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.GameStore.Platforms.DtoModels;

namespace Study.Lab3.Web.Features.GameStore.Platforms.Queries;

/// <summary>
/// Получение списка платформ
/// </summary>
public sealed class GetListPlatformsQuery : IRequest<PlatformDto[]>
{
}

public sealed class GetListPlatformsQueryHandler : IRequestHandler<GetListPlatformsQuery, PlatformDto[]>
{
    private readonly DataContext _dataContext;

    public GetListPlatformsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PlatformDto[]> Handle(GetListPlatformsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Platforms
            .AsNoTracking()
            .Select(x => new PlatformDto
            {
                IsnPlatform = x.IsnPlatform,
                Name = x.Name,
                Manufacturer = x.Manufacturer,
                Type = x.Type,
                ReleaseDate = x.ReleaseDate,
                IsActive = x.IsActive,
                Description = x.Description,
                Generation = x.Generation,
                SupportsOnlineGaming = x.SupportsOnlineGaming
            })
            .OrderBy(x => x.Manufacturer)
            .ThenBy(x => x.Name)
            .ToArrayAsync(cancellationToken);
    }
}