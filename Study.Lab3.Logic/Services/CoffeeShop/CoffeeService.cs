using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CoffeeShop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.CoffeeShop;

namespace Study.Lab3.Logic.Services.CoffeeShop;

/// <summary>
/// Сервис кофе
/// </summary>
public class CoffeeService : ICoffeeService
{
    public async Task CreateOrUpdateCoffeeValidateAndThrowAsync(
        DataContext dataContext,
        Coffee coffee,
        CancellationToken cancellationToken = default)
    {
        var existingCoffee = await dataContext.Coffee
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Name == coffee.Name && x.IsnCoffee != coffee.IsnCoffee, cancellationToken);

        if (existingCoffee != null)
        {
            throw new BusinessLogicException($"Кофе с названием '{coffee.Name}' уже существует.");
        }

        if (coffee.Price <= 0)
        {
            throw new BusinessLogicException("Цена кофе должна быть больше нуля.");
        }

        if (coffee.Size <= 0)
        {
            throw new BusinessLogicException("Размер порции должен быть больше нуля.");
        }

        if (string.IsNullOrWhiteSpace(coffee.Name))
        {
            throw new BusinessLogicException("Название кофе не может быть пустым.");
        }
    }
    
    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Coffee coffee,
        CancellationToken cancellationToken = default)
    {
        var exists = await dataContext.Coffee
            .AnyAsync(x => x.IsnCoffee == coffee.IsnCoffee, cancellationToken);

        if (!exists)
        {
            throw new BusinessLogicException("Кофе не найдено.");
        }
    }
}