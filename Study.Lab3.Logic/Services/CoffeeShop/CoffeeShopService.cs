using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CoffeeShop;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Logic.Services.CoffeeShop;

/// <summary>
/// Сервис кофейни
/// </summary>
public class CoffeeShopService : ICoffeeShopService
{
    public async Task CreateOrUpdateCoffeeShopValidateAndThrowAsync(
        DataContext dataContext,
        Storage.Models.CoffeeShop.CoffeeShop coffeeShop,
        CancellationToken cancellationToken = default)
    {
        var existingShop = await dataContext.CoffeeShops
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Name == coffeeShop.Name && x.IsnCoffeeShop != coffeeShop.IsnCoffeeShop, cancellationToken);

        if (existingShop != null)
        {
            throw new BusinessLogicException($"Кофейня с названием '{coffeeShop.Name}' уже существует.");
        }

        if (string.IsNullOrWhiteSpace(coffeeShop.Name))
        {
            throw new BusinessLogicException("Название кофейни не может быть пустым.");
        }

        if (string.IsNullOrWhiteSpace(coffeeShop.Address))
        {
            throw new BusinessLogicException("Адрес кофейни не может быть пустым.");
        }

        if (coffeeShop.Rating.HasValue && (coffeeShop.Rating < 0 || coffeeShop.Rating > 5))
        {
            throw new BusinessLogicException("Рейтинг должен быть от 0 до 5.");
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Storage.Models.CoffeeShop.CoffeeShop coffeeShop,
        CancellationToken cancellationToken = default)
    {
        var exists = await dataContext.CoffeeShops
            .AnyAsync(x => x.IsnCoffeeShop == coffeeShop.IsnCoffeeShop, cancellationToken);

        if (!exists)
        {
            throw new BusinessLogicException("Кофейня не найдена.");
        }
    }
}