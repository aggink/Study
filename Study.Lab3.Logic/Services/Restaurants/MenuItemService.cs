using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Restaurants;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Restaurants;

namespace Study.Lab3.Logic.Services.Restaurants;

public sealed class MenuItemService : IMenuItemService
{
    public async Task CreateOrUpdateMenuItemValidateAndThrowAsync(
        DataContext dataContext,
        MenuItem menuItem,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Menus.AnyAsync(x => x.IsnMenu == menuItem.IsnMenu, cancellationToken))
            throw new BusinessLogicException($"Меню с идентификатором \"{menuItem.IsnMenu}\" не существует");

        if (string.IsNullOrWhiteSpace(menuItem.Name))
            throw new BusinessLogicException("Название блюда не может быть пустым");

        if (menuItem.Name.Length > ModelConstants.MenuItem.Name)
            throw new BusinessLogicException($"Название блюда не может превышать {ModelConstants.MenuItem.Name} символов");

        if (!string.IsNullOrEmpty(menuItem.Description) && menuItem.Description.Length > ModelConstants.MenuItem.Description)
            throw new BusinessLogicException($"Описание блюда не может превышать {ModelConstants.MenuItem.Description} символов");

        if (string.IsNullOrWhiteSpace(menuItem.Category))
            throw new BusinessLogicException("Категория блюда не может быть пустой");

        if (menuItem.Category.Length > ModelConstants.MenuItem.Category)
            throw new BusinessLogicException($"Категория не может превышать {ModelConstants.MenuItem.Category} символов");

        if (menuItem.Price < ModelConstants.MenuItem.MinPrice || menuItem.Price > ModelConstants.MenuItem.MaxPrice)
            throw new BusinessLogicException($"Цена должна быть от {ModelConstants.MenuItem.MinPrice} до {ModelConstants.MenuItem.MaxPrice}");

        if (menuItem.CookingTimeMinutes < ModelConstants.MenuItem.MinCookingTime || menuItem.CookingTimeMinutes > ModelConstants.MenuItem.MaxCookingTime)
            throw new BusinessLogicException($"Время приготовления должно быть от {ModelConstants.MenuItem.MinCookingTime} до {ModelConstants.MenuItem.MaxCookingTime} минут");

        // Проверка уникальности названия блюда в рамках меню
        if (await dataContext.MenuItems.AnyAsync(x =>
            x.IsnMenuItem != menuItem.IsnMenuItem &&
            x.IsnMenu == menuItem.IsnMenu &&
            x.Name == menuItem.Name,
            cancellationToken))
            throw new BusinessLogicException("Блюдо с таким названием уже существует в данном меню");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        MenuItem menuItem,
        CancellationToken cancellationToken = default)
    {
        if (await dataContext.OrderItems.AnyAsync(x => x.IsnMenuItem == menuItem.IsnMenuItem, cancellationToken))
            throw new BusinessLogicException("Невозможно удалить позицию меню, так как она используется в заказах");
    }
}
