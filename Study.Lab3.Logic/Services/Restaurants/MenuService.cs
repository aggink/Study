using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Restaurants;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Restaurants;

namespace Study.Lab3.Logic.Services.Restaurants;

public sealed class MenuService : IMenuService
{
    public async Task CreateOrUpdateMenuValidateAndThrowAsync(
        DataContext dataContext,
        Menu menu,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Restaurants.AnyAsync(x => x.IsnRestaurant == menu.IsnRestaurant, cancellationToken))
            throw new BusinessLogicException($"Ресторан с идентификатором \"{menu.IsnRestaurant}\" не существует");

        if (string.IsNullOrWhiteSpace(menu.Name))
            throw new BusinessLogicException("Название меню не может быть пустым");

        if (menu.Name.Length > ModelConstants.Menu.Name)
            throw new BusinessLogicException($"Название меню не может превышать {ModelConstants.Menu.Name} символов");

        if (!string.IsNullOrEmpty(menu.Description) && menu.Description.Length > ModelConstants.Menu.Description)
            throw new BusinessLogicException($"Описание меню не может превышать {ModelConstants.Menu.Description} символов");

        // Проверка уникальности названия меню в рамках ресторана
        if (await dataContext.Menus.AnyAsync(x =>
                    x.IsnMenu != menu.IsnMenu &&
                    x.IsnRestaurant == menu.IsnRestaurant &&
                    x.Name == menu.Name,
                cancellationToken))
            throw new BusinessLogicException("Меню с таким названием уже существует в данном ресторане");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Menu menu,
        CancellationToken cancellationToken = default)
    {
        if (await dataContext.MenuItems.AnyAsync(x => x.IsnMenu == menu.IsnMenu, cancellationToken))
            throw new BusinessLogicException("Невозможно удалить меню, так как в нем есть позиции");
    }
}
