using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
<<<<<<< HEAD
using Study.Lab3.Web.Features.Sweets.Sweets.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.Sweets.Queries;
=======
using Study.Lab3.Web.Features.Sweets.Sweet.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Sweets.Sweet.Queries;
>>>>>>> 047df7a98a474bbf79c1e63ef959da231cb59117

/// <summary>
/// Получение списка клиентов
/// </summary>
public sealed class GetListSweetsQuery : IRequest<SweetDto[]>
{
}

public sealed class GetListSweetQueryHandler : IRequestHandler<GetListSweetsQuery, SweetDto[]>
{
    private readonly DataContext _dataContext;

    public GetListSweetQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<SweetDto[]> Handle(GetListSweetsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Sweets
            .AsNoTracking()
            .OrderBy(c => c.IsnSweet)
            .ThenBy(c => c.Name)
            .Select(c => new SweetDto
            {
                IsnSweet = c.IsnSweet,
                Name = c.Name,
                IsnSweetType = c.IsnSweetType,
                Ingredients = c.Ingredients
            })
            .ToArrayAsync(cancellationToken);
    }
}