using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.BeautySalon;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.BeautySalon.BeautyClient.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.BeautySalon.BeautyClient.Commands;

/// <summary>
/// Создание клиента
/// </summary>
public sealed class CreateClientCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные клиента
    /// </summary>
    [Required]
    [FromBody]
    public CreateClientDto Client { get; init; }
}

public sealed class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IBeautyClientService _clientService;

    public CreateClientCommandHandler(DataContext dataContext, IBeautyClientService clientService)
    {
        _dataContext = dataContext;
        _clientService = clientService;
    }

    public async Task<Guid> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var client = new Storage.Models.BeautySalon.BeautyClient
        {
            IsnClient = Guid.NewGuid(),
            FirstName = request.Client.FirstName,
            LastName = request.Client.LastName,
            PhoneNumber = request.Client.PhoneNumber,
            EmailAddress = request.Client.EmailAddress,
        };

        await _clientService.CreateOrUpdateBeautyClientValidate(_dataContext, client, cancellationToken);

        await _dataContext.BeautyClients.AddAsync(client, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return client.IsnClient;
    }
}