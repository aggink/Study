/*using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.University.Materials.DtoModels;

namespace Study.Lab3.Web.Features.University.Materials.Queries;

/// <summary>
/// Получение списка материалов
/// </summary>
public sealed class GetListMaterialsQuery : IRequest<MaterialDto[]>
{
}

public sealed class GetListMaterialsQueryHandler : IRequestHandler<GetListMaterialsQuery, MaterialDto[]>
{
    private readonly DataContext _dataContext;

    public GetListMaterialsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MaterialDto[]> Handle(GetListMaterialsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Materials
            .AsNoTracking()
            .Select(x => new MaterialDto
            {
                IsnMaterial = x.IsnMaterial,
                IsnSubject = x.IsnSubject,
                Title = x.Title,
                Description = x.Description,
                Type = x.Type,
                Url = x.Url,
                PublishDate = x.PublishDate
            })
            .OrderByDescending(x => x.PublishDate)
            .ToArrayAsync(cancellationToken);
    }
}*/