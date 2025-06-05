using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.HospitalStore.Product.DtoModels;

namespace Study.Lab3.Web.Features.HospitalStore.Product.Queries;

/// <summary>
/// Получение товара по идентификатору
/// </summary>
public sealed class GetProductByIsnQuery : IRequest<ProductDto?>
{
    public Guid IsnProduct { get; }

    public GetProductByIsnQuery(Guid isnProduct)
    {
        IsnProduct = isnProduct;
    }
}

public sealed class GetProductByIsnQueryHandler : IRequestHandler<GetProductByIsnQuery, ProductDto?>
{
    private readonly DataContext _dataContext;

    public GetProductByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ProductDto?> Handle(GetProductByIsnQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Products
            .AsNoTracking()
            .Where(x => x.IsnProduct == request.IsnProduct)
            .Select(x => new ProductDto
            {
                IsnProduct = x.IsnProduct,
                Name = x.Name,
                Category = x.Category,
                Price = x.Price
            })
            .FirstOrDefaultAsync(cancellationToken);
    }
}