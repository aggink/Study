using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Photography.Clients.DtoModels;

namespace Study.Lab3.Web.Features.Photography.Clients.Queries;

public sealed class GetListPhotographyClientsQuery : IRequest<PhotographyClientDto[]>
{
}

public sealed class GetListPhotographyClientsQueryHandler : IRequestHandler<GetListPhotographyClientsQuery, PhotographyClientDto[]>
{
    private readonly DataContext _dataContext;

    public GetListPhotographyClientsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PhotographyClientDto[]> Handle(GetListPhotographyClientsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.PhotographyClients
            .AsNoTracking()
            .Select(x => new PhotographyClientDto
            {
                IsnPhotographyClient = x.IsnPhotographyClient,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Phone = x.Phone,
                Email = x.Email,
                RegistrationDate = x.RegistrationDate,
                BirthDate = x.BirthDate,
                Notes = x.Notes
            })
            .OrderBy(x => x.LastName)
            .ThenBy(x => x.FirstName)
            .ToArrayAsync(cancellationToken);
    }
}
