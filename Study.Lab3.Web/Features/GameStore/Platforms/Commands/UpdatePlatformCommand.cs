using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.GameStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.GameStore.Platforms.DtoModels;

namespace Study.Lab3.Web.Features.GameStore.Platforms.Commands;

/// <summary>
/// Обновление платформы
/// </summary>
public sealed class UpdatePlatformCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные платформы
    /// </summary>
    [Required]
    [FromBody]
    public UpdatePlatformDto Platform { get; init; }
}

public sealed class UpdatePlatformCommandHandler : IRequestHandler<UpdatePlatformCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPlatformService _platformService;

    public UpdatePlatformCommandHandler(
        DataContext dataContext,
        IPlatformService platformService)
    {
        _dataContext = dataContext;
        _platformService = platformService;
    }

    public async Task<Guid> Handle(UpdatePlatformCommand request, CancellationToken cancellationToken)
    {
        var platform = await _dataContext.Platforms
                           .FirstOrDefaultAsync(x => x.IsnPlatform == request.Platform.IsnPlatform,
                               cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Платформа с идентификатором \"{request.Platform.IsnPlatform}\" не существует");

        platform.Name = request.Platform.Name;
        platform.Manufacturer = request.Platform.Manufacturer;
        platform.Type = request.Platform.Type;
        platform.ReleaseDate = request.Platform.ReleaseDate;
        platform.IsActive = request.Platform.IsActive;
        platform.Description = request.Platform.Description;
        platform.Generation = request.Platform.Generation;
        platform.SupportsOnlineGaming = request.Platform.SupportsOnlineGaming;

        await _platformService.CreateOrUpdatePlatformValidateAndThrowAsync(
            _dataContext, platform, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return platform.IsnPlatform;
    }
}