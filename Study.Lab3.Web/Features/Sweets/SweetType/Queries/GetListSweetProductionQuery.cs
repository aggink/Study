using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Sweets.SweetFactories.DtoModels;
using Study.Lab3.Web.Features.Sweets.SweetProductions.DtoModels;

namespace Study.Lab3.Web.Features.Sweets.SweetTypes.Queries;

/// <summary>
/// Получение списка фабрик
/// </summary>
public sealed class GetListSweetProductionQuery : IRequest<SweetProductionDto[]>
{
}

public sealed class GetListSweetProductionQueryHandler : IRequestHandler<GetListSweetProductionQuery, SweetProductionDto[]>
{
    private readonly DataContext _dataContext;

    public GetListSweetProductionQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<SweetProductionDto[]> Handle(GetListSweetProductionQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.SweetProductions
            .AsNoTracking()
            .OrderBy(c => c.SweetFactoryID)
            .ThenBy(c => c.SweetID)
            .Select(c => new SweetFactoryDto
            {
                FactoryID = c.SweetFactoryID,
                SweetID = c.SweetID,
            })
            .ToArrayAsync(cancellationToken);
    }
}