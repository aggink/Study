using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Sweets.SweetFactories.DtoModels;
using Study.Lab3.Web.Features.Sweets.SweetProductions.DtoModels;
using Study.Lab3.Web.Features.Sweets.SweetTypes.DtoModels;

namespace Study.Lab3.Web.Features.Sweets.SweetTypes.Queries;

/// <summary>
/// Получение списка фабрик
/// </summary>
public sealed class GetListSweetTypeQuery : IRequest<SweetTypeDto[]>
{
}

public sealed class GetListSweetTypeQueryHandler : IRequestHandler<GetListSweetTypeQuery, SweetTypeDto[]>
{
    private readonly DataContext _dataContext;

    public GetListSweetTypeQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<SweetTypeDto[]> Handle(GetListSweetTypeQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.SweetTypes
            .AsNoTracking()
            .OrderBy(c => c.ID)
            .ThenBy(c => c.Name)
            .Select(c => new SweetTypeDto
            {
                ID = c.ID,
                Name = c.Name,
            })
            .ToArrayAsync(cancellationToken);
    }
}