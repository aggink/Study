using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.BeautySalon;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.BeautySalon.BeautyClient.Commands;

/// <summary>
/// Удаление клиента
/// </summary>
public sealed class DeleteClientCommand : IRequest
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnClient { get; init; }
}

public sealed class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand>
{
    private readonly DataContext _dataContext;
    private readonly IBeautyClientService _clientService;

    public DeleteClientCommandHandler(DataContext dataContext, IBeautyClientService clientService)
    {
        _dataContext = dataContext;
        _clientService = clientService;
    }

    public async Task Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _dataContext.BeautyClients.FirstOrDefaultAsync(x => x.IsnClient == request.IsnClient, cancellationToken)
                ?? throw new BusinessLogicException($"Клиента с идентификатором \"{request.IsnClient}\" не существует!");

        _dataContext.BeautyClients.Remove(client);
        await _dataContext.SaveChangesAsync(cancellationToken);
        return;
    }
}