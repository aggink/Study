using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.BeautySalon;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.BeautySalon.BeautyClient.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.BeautySalon.BeautyClient.Commands;

/// <summary>
/// Редактирование клиента
/// </summary>
public sealed class UpdateClientCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные клиента
    /// </summary>
    [Required]
    [FromBody]
    public UpdateClientDto Client { get; init; }
}

public sealed class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IBeautyClientService _clientService;

    public UpdateClientCommandHandler(DataContext dataContext, IBeautyClientService clientService)
    {
        _dataContext = dataContext;
        _clientService = clientService;
    }

    public async Task<Guid> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _dataContext.BeautyClients.FirstOrDefaultAsync(x => x.IsnClient == request.Client.IsnClient, cancellationToken)
                ?? throw new BusinessLogicException($"Клиента с идентификатором \"{request.Client.IsnClient}\" не существует!");

        client.FirstName = request.Client.FirstName;
        client.LastName = request.Client.LastName;
        client.PhoneNumber = request.Client.PhoneNumber;
        client.EmailAddress = request.Client.EmailAddress;

        await _clientService.CreateOrUpdateBeautyClientValidate(_dataContext, client, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return client.IsnClient;
    }
}