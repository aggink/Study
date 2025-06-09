using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Sweets.SweetType.DtoModels;

namespace Study.Lab3.Web.Features.Sweets.SweetType.Queries;

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
            .OrderBy(c => c.IsnSweetType)
            .ThenBy(c => c.Name)
            .Select(c => new SweetTypeDto
            {
                IsnSweetType = c.IsnSweetType,
                Name = c.Name,
            })
            .ToArrayAsync(cancellationToken);
    }
}