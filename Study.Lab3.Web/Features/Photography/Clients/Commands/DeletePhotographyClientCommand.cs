using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Photography;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.Photography.Clients.Commands;

/// <summary>
/// Удаление клиента фотостудии
/// </summary>
public sealed class DeletePhotographyClientCommand : IRequest
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnPhotographyClient { get; init; }
}

public sealed class DeletePhotographyClientCommandHandler : IRequestHandler<DeletePhotographyClientCommand>
{
    private readonly DataContext _dataContext;
    private readonly IPhotographyClientService _clientService;

    public DeletePhotographyClientCommandHandler(
        DataContext dataContext,
        IPhotographyClientService clientService)
    {
        _dataContext = dataContext;
        _clientService = clientService;
    }

    public async Task Handle(DeletePhotographyClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _dataContext.PhotographyClients
                         .FirstOrDefaultAsync(x => x.IsnPhotographyClient == request.IsnPhotographyClient,
                             cancellationToken)
                     ?? throw new BusinessLogicException(
                         $"Клиент с идентификатором \"{request.IsnPhotographyClient}\" не существует");

        await _clientService.CanDeleteAndThrowAsync(_dataContext, client, cancellationToken);

        _dataContext.PhotographyClients.Remove(client);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}