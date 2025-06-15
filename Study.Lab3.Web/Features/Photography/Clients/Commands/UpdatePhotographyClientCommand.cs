using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Photography;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Photography.Clients.DtoModels;

namespace Study.Lab3.Web.Features.Photography.Clients.Commands;

/// <summary>
/// Обновление клиента фотостудии
/// </summary>
public sealed class UpdatePhotographyClientCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные клиента
    /// </summary>
    [Required]
    [FromBody]
    public UpdatePhotographyClientDto Client { get; init; }
}

public sealed class UpdatePhotographyClientCommandHandler : IRequestHandler<UpdatePhotographyClientCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPhotographyClientService _clientService;

    public UpdatePhotographyClientCommandHandler(
        DataContext dataContext,
        IPhotographyClientService clientService)
    {
        _dataContext = dataContext;
        _clientService = clientService;
    }

    public async Task<Guid> Handle(UpdatePhotographyClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _dataContext.PhotographyClients
                         .FirstOrDefaultAsync(x => x.IsnPhotographyClient == request.Client.IsnPhotographyClient,
                             cancellationToken)
                     ?? throw new BusinessLogicException(
                         $"Клиент с идентификатором \"{request.Client.IsnPhotographyClient}\" не существует");

        client.FirstName = request.Client.FirstName;
        client.LastName = request.Client.LastName;
        client.Phone = request.Client.Phone;
        client.Email = request.Client.Email;
        client.BirthDate = request.Client.BirthDate;
        client.Notes = request.Client.Notes;

        await _clientService.CreateOrUpdateClientValidateAndThrowAsync(
            _dataContext, client, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return client.IsnPhotographyClient;
    }
}