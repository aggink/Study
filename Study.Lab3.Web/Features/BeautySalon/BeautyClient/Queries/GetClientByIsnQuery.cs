using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.BeautySalon.BeautyClient.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.BeautySalon.BeautyClient.Queries;

/// <summary>
/// Получение данных клиента
/// </summary>
public class GetClientByIsnQuery : IRequest<ClientDto>
{
    /// <summary>
    /// ID клиента
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnClient { get; init; }
}

public sealed class GetClientByIsnQueryHandler : IRequestHandler<GetClientByIsnQuery, ClientDto>
{
    private readonly DataContext _dataContext;

    public GetClientByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ClientDto> Handle(GetClientByIsnQuery request, CancellationToken cancellationToken)
    {
        var client = await _dataContext.BeautyClients
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnClient == request.IsnClient, cancellationToken)
            ?? throw new BusinessLogicException($"Клиента с идентификатором \"{request.IsnClient}\" не существует!");

        return new ClientDto
        {
            IsnClient = client.IsnClient,
            FirstName = client.FirstName,
            LastName = client.LastName,
            PhoneNumber = client.PhoneNumber,
            EmailAddress = client.EmailAddress
        };
    }
}