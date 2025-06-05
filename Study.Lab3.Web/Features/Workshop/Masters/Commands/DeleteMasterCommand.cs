using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Workshop;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Workshop.Masters.Commands;

/// <summary>
/// Удаление мастера
/// </summary>
public sealed class DeleteMasterCommand : IRequest
{
    /// <summary>
    /// Идентификатор мастера
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMaster { get; init; }
}

public sealed class DeleteMasterCommandHandler : IRequestHandler<DeleteMasterCommand>
{
    private readonly DataContext _dataContext;
    private readonly IMasterService _masterService;

    public DeleteMasterCommandHandler(
        DataContext dataContext,
        IMasterService masterService)
    {
        _dataContext = dataContext;
        _masterService = masterService;
    }

    public async Task Handle(DeleteMasterCommand request, CancellationToken cancellationToken)
    {
        var master = await _dataContext.Masters
                         .FirstOrDefaultAsync(x => x.IsnMaster == request.IsnMaster, cancellationToken)
                     ?? throw new BusinessLogicException(
                         $"Мастер с идентификатором \"{request.IsnMaster}\" не существует");

        await _masterService.CanDeleteAndThrowAsync(_dataContext, master, cancellationToken);

        _dataContext.Masters.Remove(master);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}