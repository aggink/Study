using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.Photography;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Photography;
using Study.Lab3.Web.Features.Photography.Clients.DtoModels;

namespace Study.Lab3.Web.Features.Photography.Clients.Commands;

/// <summary>
/// Создание клиента фотостудии
/// </summary>
public sealed class CreatePhotographyClientCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные клиента
    /// </summary>
    [Required]
    [FromBody]
    public CreatePhotographyClientDto Client { get; init; }
}

public sealed class CreatePhotographyClientCommandHandler : IRequestHandler<CreatePhotographyClientCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPhotographyClientService _clientService;

    public CreatePhotographyClientCommandHandler(
        DataContext dataContext,
        IPhotographyClientService clientService)
    {
        _dataContext = dataContext;
        _clientService = clientService;
    }

    public async Task<Guid> Handle(CreatePhotographyClientCommand request, CancellationToken cancellationToken)
    {
        var client = new PhotographyClient
        {
            IsnPhotographyClient = Guid.NewGuid(),
            FirstName = request.Client.FirstName,
            LastName = request.Client.LastName,
            Phone = request.Client.Phone,
            Email = request.Client.Email,
            RegistrationDate = request.Client.RegistrationDate,
            BirthDate = request.Client.BirthDate,
            Notes = request.Client.Notes
        };

        await _clientService.CreateOrUpdateClientValidateAndThrowAsync(
            _dataContext, client, cancellationToken);

        await _dataContext.PhotographyClients.AddAsync(client, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return client.IsnPhotographyClient;
    }
}