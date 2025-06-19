using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Photography.Clients.DtoModels;

namespace Study.Lab3.Web.Features.Photography.Clients.Queries;

/// <summary>
/// Получение клиента по идентификатору
/// </summary>
public sealed class GetPhotographyClientByIsnQuery : IRequest<PhotographyClientDto>
{
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnPhotographyClient { get; init; }
}

public sealed class GetPhotographyClientByIsnQueryHandler : IRequestHandler<GetPhotographyClientByIsnQuery, PhotographyClientDto>
{
    private readonly DataContext _dataContext;

    public GetPhotographyClientByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PhotographyClientDto> Handle(GetPhotographyClientByIsnQuery request, CancellationToken cancellationToken)
    {
        var client = await _dataContext.PhotographyClients
                         .AsNoTracking()
                         .FirstOrDefaultAsync(x => x.IsnPhotographyClient == request.IsnPhotographyClient,
                             cancellationToken)
                     ?? throw new BusinessLogicException(
                         $"Клиент с идентификатором \"{request.IsnPhotographyClient}\" не существует");

        return new PhotographyClientDto
        {
            IsnPhotographyClient = client.IsnPhotographyClient,
            FirstName = client.FirstName,
            LastName = client.LastName,
            Phone = client.Phone,
            Email = client.Email,
            RegistrationDate = client.RegistrationDate,
            BirthDate = client.BirthDate,
            Notes = client.Notes
        };
    }
}