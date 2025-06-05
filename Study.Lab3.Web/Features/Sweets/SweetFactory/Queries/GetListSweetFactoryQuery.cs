using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Sweets.SweetFactories.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.SweetFactories.Queries;

/// <summary>
/// Получение списка фабрик
/// </summary>
public sealed class GetListSweetFactoryQuery : IRequest<SweetFactoryDto[]>
{
}

public sealed class GetListSweetFactoryQueryHandler : IRequestHandler<GetListSweetFactoryQuery, SweetFactoryDto[]>
{
    private readonly DataContext _dataContext;

    public GetListSweetFactoryQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<SweetFactoryDto[]> Handle(GetListSweetFactoryQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.SweetFactories
            .AsNoTracking()
            .OrderBy(c => c.IsnSweetFactory)
            .ThenBy(c => c.Name)
            .Select(c => new SweetFactoryDto
            {
                IsnSweetFactory = c.IsnSweetFactory,
                Name = c.Name,
                Address = c.Address,
                Volume = c.Volume
            })
            .ToArrayAsync(cancellationToken);
    }
}