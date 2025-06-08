using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
<<<<<<< HEAD
using Study.Lab3.Web.Features.Sweets.SweetFactories.DtoModels;
using Study.Lab3.Web.Features.Sweets.SweetProductions.DtoModels;

namespace Study.Lab3.Web.Features.Sweets.SweetProductions.Queries;
=======
using Study.Lab3.Web.Features.Sweets.SweetProduction.DtoModels;

namespace Study.Lab3.Web.Features.Sweets.SweetProduction.Queries;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

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
            .OrderBy(c => c.IsnSweetFactory)
            .ThenBy(c => c.IsnSweet)
            .Select(c => new SweetProductionDto
            {
                IsnFactory = c.IsnSweetFactory,
<<<<<<< HEAD
                IsnSweet= c.IsnSweet,
=======
                IsnSweet = c.IsnSweet,
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117
            })
            .ToArrayAsync(cancellationToken);
    }
}