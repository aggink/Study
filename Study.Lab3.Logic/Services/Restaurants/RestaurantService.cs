using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Restaurants;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Restaurants;

namespace Study.Lab3.Logic.Services.Restaurants;

public sealed class RestaurantService : IRestaurantService
{
    public async Task CreateOrUpdateRestaurantValidateAndThrowAsync(
        DataContext dataContext,
        Restaurant restaurant,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(restaurant.Name))
            throw new BusinessLogicException("Название ресторана не peut быть пустым");

        if (restaurant.Name.Length > ModelConstants.Restaurant.Name)
            throw new BusinessLogicException($"Название ресторана не может превышать {ModelConstants.Restaurant.Name} символов");

        if (string.IsNullOrWhiteSpace(restaurant.Address))
            throw new BusinessLogicException("Адрес ресторана не может быть пустым");

        if (restaurant.Address.Length > ModelConstants.Restaurant.Address)
            throw new BusinessLogicException($"Адрес не может превышать {ModelConstants.Restaurant.Address} символов");

        if (!string.IsNullOrEmpty(restaurant.Phone) && restaurant.Phone.Length > ModelConstants.Restaurant.Phone)
            throw new BusinessLogicException($"Телефон не может превышать {ModelConstants.Restaurant.Phone} символов");

        if (!string.IsNullOrEmpty(restaurant.Email) && restaurant.Email.Length > ModelConstants.Restaurant.Email)
            throw new BusinessLogicException($"Email не может превышать {ModelConstants.Restaurant.Email} символов");

        if (!string.IsNullOrEmpty(restaurant.WorkingHours) && restaurant.WorkingHours.Length > ModelConstants.Restaurant.WorkingHours)
            throw new BusinessLogicException($"Время работы не может превышать {ModelConstants.Restaurant.WorkingHours} символов");

        // Проверка уникальности названия и адреса
        if (await dataContext.Restaurants.AnyAsync(x =>
            x.IsnRestaurant != restaurant.IsnRestaurant &&
            x.Name == restaurant.Name &&
            x.Address == restaurant.Address,
            cancellationToken))
            throw new BusinessLogicException("Ресторан с таким названием и адресом уже существует");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Restaurant restaurant,
        CancellationToken cancellationToken = default)
    {
        if (await dataContext.Menus.AnyAsync(x => x.IsnRestaurant == restaurant.IsnRestaurant, cancellationToken))
            throw new BusinessLogicException("Невозможно удалить ресторан, так как у него есть меню");

        if (await dataContext.Orders.AnyAsync(x => x.IsnRestaurant == restaurant.IsnRestaurant, cancellationToken))
            throw new BusinessLogicException("Невозможно удалить ресторан, так как у него есть заказы");
    }
}
