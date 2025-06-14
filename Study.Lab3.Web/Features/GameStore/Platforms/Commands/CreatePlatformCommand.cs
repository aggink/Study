using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.GameStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.GameStore;
using Study.Lab3.Web.Features.GameStore.Platforms.DtoModels;

namespace Study.Lab3.Web.Features.GameStore.Platforms.Commands;

/// <summary>
/// Создание платформы
/// </summary>
public sealed class CreatePlatformCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные платформы
    /// </summary>
    [Required]
    [FromBody]
    public CreatePlatformDto Platform { get; init; }
}

public sealed class CreatePlatformCommandHandler : IRequestHandler<CreatePlatformCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPlatformService _platformService;

    public CreatePlatformCommandHandler(
        DataContext dataContext,
        IPlatformService platformService)
    {
        _dataContext = dataContext;
        _platformService = platformService;
    }

    public async Task<Guid> Handle(CreatePlatformCommand request, CancellationToken cancellationToken)
    {
        var platform = new Platform
        {
            IsnPlatform = Guid.NewGuid(),
            Name = request.Platform.Name,
            Manufacturer = request.Platform.Manufacturer,
            Type = request.Platform.Type,
            ReleaseDate = request.Platform.ReleaseDate,
            IsActive = request.Platform.IsActive,
            Description = request.Platform.Description,
            Generation = request.Platform.Generation,
            SupportsOnlineGaming = request.Platform.SupportsOnlineGaming
        };

        await _platformService.CreateOrUpdatePlatformValidateAndThrowAsync(
            _dataContext, platform, cancellationToken);

        await _dataContext.Platforms.AddAsync(platform, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return platform.IsnPlatform;
    }
}