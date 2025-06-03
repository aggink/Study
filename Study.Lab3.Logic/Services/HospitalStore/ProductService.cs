using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.HospitalStore;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.HospitalStore;

namespace Study.Lab3.Logic.Services.HospitalStore;

public sealed class ProductService : IProductService
{
    public async Task CreateOrUpdateProductValidateAndThrowAsync(
        DataContext dataContext,
        Product product,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(product.Name) || product.Name.Length > ModelConstants.Product.NameMaxLength)
        {
            throw new BusinessLogicException($"Название товара не должно быть пустым и не должно превышать {ModelConstants.Product.NameMaxLength} символов");
        }

        if (string.IsNullOrWhiteSpace(product.Category) || product.Category.Length > ModelConstants.Product.CategoryMaxLength)
        {
            throw new BusinessLogicException($"Категория не должна быть пустой и не должна превышать {ModelConstants.Product.CategoryMaxLength} символов");
        }

        if (product.Price < ModelConstants.Product.PriceMin || product.Price > ModelConstants.Product.PriceMax)
        {
            throw new BusinessLogicException($"Цена должна быть от {ModelConstants.Product.PriceMin} до {ModelConstants.Product.PriceMax} рублей");
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Product product,
        CancellationToken cancellationToken = default)
    {
        bool hasOrders = await dataContext.Orders.AnyAsync(x => x.IsnProduct == product.IsnProduct, cancellationToken);
        if (hasOrders)
        {
            throw new BusinessLogicException("Невозможно удалить товар, который используется в заказах");
        }
    }
}
