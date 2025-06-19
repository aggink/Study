using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.GameStore;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.GameStore.Platforms.Commands;

/// <summary>
/// Удаление платформы
/// </summary>
public sealed class DeletePlatformCommand : IRequest
{
    /// <summary>
    /// Идентификатор платформы
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnPlatform { get; init; }
}

public sealed class DeletePlatformCommandHandler : IRequestHandler<DeletePlatformCommand>
{
    private readonly DataContext _dataContext;
    private readonly IPlatformService _platformService;

    public DeletePlatformCommandHandler(
        DataContext dataContext,
        IPlatformService platformService)
    {
        _dataContext = dataContext;
        _platformService = platformService;
    }

    public async Task Handle(DeletePlatformCommand request, CancellationToken cancellationToken)
    {
        var platform = await _dataContext.Platforms
                           .FirstOrDefaultAsync(x => x.IsnPlatform == request.IsnPlatform, cancellationToken)
                       ?? throw new BusinessLogicException(
                           $"Платформа с идентификатором \"{request.IsnPlatform}\" не существует");

        await _platformService.CanDeleteAndThrowAsync(_dataContext, platform, cancellationToken);

        _dataContext.Platforms.Remove(platform);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}