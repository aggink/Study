using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.GameStore.Developers.DtoModels;

namespace Study.Lab3.Web.Features.GameStore.Developers.Queries;

/// <summary>
/// Получение списка разработчиков
/// </summary>
public sealed class GetListDevelopersQuery : IRequest<DeveloperDto[]>
{
}

public sealed class GetListDevelopersQueryHandler : IRequestHandler<GetListDevelopersQuery, DeveloperDto[]>
{
    private readonly DataContext _dataContext;

    public GetListDevelopersQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<DeveloperDto[]> Handle(GetListDevelopersQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Developers
            .AsNoTracking()
            .Select(x => new DeveloperDto
            {
                IsnDeveloper = x.IsnDeveloper,
                CompanyName = x.CompanyName,
                Country = x.Country,
                FoundedDate = x.FoundedDate,
                Website = x.Website,
                ContactEmail = x.ContactEmail,
                IsActive = x.IsActive,
                Description = x.Description
            })
            .OrderBy(x => x.CompanyName)
            .ToArrayAsync(cancellationToken);
    }
}