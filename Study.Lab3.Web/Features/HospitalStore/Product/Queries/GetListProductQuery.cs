using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.HospitalStore.Product.DtoModels;

namespace Study.Lab3.Web.Features.HospitalStore.Product.Queries;

/// <summary>
/// Получение списка товаров
/// </summary>
public sealed class GetListProductQuery : IRequest<ProductDto[]>
{
}

public sealed class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, ProductDto[]>
{
    private readonly DataContext _dataContext;

    public GetListProductQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ProductDto[]> Handle(GetListProductQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Products
            .AsNoTracking()
            .Select(x => new ProductDto
            {
                IsnProduct = x.IsnProduct,
                Name = x.Name,
                Category = x.Category,
                Price = x.Price
            })
            .OrderBy(x => x.Name) // Сортировка по названию
            .ToArrayAsync(cancellationToken);
    }
}