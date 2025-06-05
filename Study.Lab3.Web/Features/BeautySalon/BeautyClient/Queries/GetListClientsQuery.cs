using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.BeautySalon.BeautyClient.DtoModels;

namespace Study.Lab3.Web.Features.BeautySalon.BeautyClient.Queries;

/// <summary>
/// Получение списка клиентов
/// </summary>
public sealed class GetListClientsQuery : IRequest<ClientDto[]>
{
}

public sealed class GetListClientsQueryHandler : IRequestHandler<GetListClientsQuery, ClientDto[]>
{
    private readonly DataContext _dataContext;

    public GetListClientsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ClientDto[]> Handle(GetListClientsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.BeautyClient
            .AsNoTracking()
            .Select(x => new ClientDto
            {
                IsnClient = x.IsnClient,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                EmailAddress = x.EmailAddress
            })
            .OrderBy(x => x.LastName) // Сортировка по фамилии
            .ToArrayAsync(cancellationToken);
    }
}