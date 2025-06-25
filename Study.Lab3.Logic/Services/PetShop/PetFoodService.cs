using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.PetShop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.PetShop;

namespace Study.Lab3.Logic.Services.PetShop;

public sealed class PetFoodService : IPetFoodService
{
    public async Task CreateOrUpdatePetFoodValidateAndThrowAsync(
        DataContext dataContext,
        PetFood petFood,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(petFood.Name))
            throw new BusinessLogicException("Название корма не может быть пустым");

        if (string.IsNullOrWhiteSpace(petFood.Brand))
            throw new BusinessLogicException("Бренд корма не может быть пустым");

        if (petFood.WeightInGrams <= 0)
            throw new BusinessLogicException("Вес упаковки должен быть положительным числом");

        if (petFood.Price <= 0)
            throw new BusinessLogicException("Цена корма должна быть положительным числом");

        if (petFood.ExpirationDate <= DateTime.UtcNow)
            throw new BusinessLogicException("Срок годности не может быть в прошлом");

        if (petFood.StockQuantity < 0)
            throw new BusinessLogicException("Количество в наличии не может быть отрицательным");

        if (await dataContext.PetFoods.AnyAsync(
                x => x.Name == petFood.Name &&
                     x.Brand == petFood.Brand &&
                     x.WeightInGrams == petFood.WeightInGrams &&
                     x.TargetSpecies == petFood.TargetSpecies &&
                     x.IsnPetFood != petFood.IsnPetFood,
                cancellationToken))
            throw new BusinessLogicException(
                $"Корм \"{petFood.Brand} {petFood.Name}\" весом {petFood.WeightInGrams}г для {petFood.TargetSpecies} уже существует");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        PetFood petFood,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.PetFoods.AnyAsync(x => x.IsnPetFood == petFood.IsnPetFood, cancellationToken))
            throw new BusinessLogicException(
                $"Корм с идентификатором \"{petFood.IsnPetFood}\" не существует");
    }
}