using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.GameStore;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.GameStore.Developers.Commands;

/// <summary>
/// Удаление разработчика
/// </summary>
public sealed class DeleteDeveloperCommand : IRequest
{
    /// <summary>
    /// Идентификатор разработчика
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnDeveloper { get; init; }
}

public sealed class DeleteDeveloperCommandHandler : IRequestHandler<DeleteDeveloperCommand>
{
    private readonly DataContext _dataContext;
    private readonly IDeveloperService _developerService;

    public DeleteDeveloperCommandHandler(
        DataContext dataContext,
        IDeveloperService developerService)
    {
        _dataContext = dataContext;
        _developerService = developerService;
    }

    public async Task Handle(DeleteDeveloperCommand request, CancellationToken cancellationToken)
    {
        var developer = await _dataContext.Developers
                            .FirstOrDefaultAsync(x => x.IsnDeveloper == request.IsnDeveloper, cancellationToken)
                        ?? throw new BusinessLogicException(
                            $"Разработчик с идентификатором \"{request.IsnDeveloper}\" не существует");

        await _developerService.CanDeleteAndThrowAsync(_dataContext, developer, cancellationToken);

        _dataContext.Developers.Remove(developer);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}