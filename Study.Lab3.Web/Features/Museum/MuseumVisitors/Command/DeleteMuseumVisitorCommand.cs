using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Museum;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.Museum.MuseumVisitors.Command;

/// <summary>
/// Удаление посетителя музея
/// </summary>
public sealed class DeleteMuseumVisitorCommand : IRequest
{
    /// <summary>
    /// Идентификатор посетителя
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnMuseumVisitor { get; init; }
}

public sealed class DeleteMuseumVisitorCommandHandler : IRequestHandler<DeleteMuseumVisitorCommand>
{
    private readonly DataContext _dataContext;
    private readonly IMuseumVisitorService _visitorService;

    public DeleteMuseumVisitorCommandHandler(
        DataContext dataContext,
        IMuseumVisitorService visitorService)
    {
        _dataContext = dataContext;
        _visitorService = visitorService;
    }

    public async Task Handle(DeleteMuseumVisitorCommand request, CancellationToken cancellationToken)
    {
        var visitor = await _dataContext.MuseumVisitors
                          .FirstOrDefaultAsync(x => x.IsnMuseumVisitor == request.IsnMuseumVisitor, cancellationToken)
                      ?? throw new BusinessLogicException($"Посетитель с идентификатором \"{request.IsnMuseumVisitor}\" не существует");

        await _visitorService.CanDeleteAndThrowAsync(_dataContext, visitor, cancellationToken);

        _dataContext.MuseumVisitors.Remove(visitor);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}
