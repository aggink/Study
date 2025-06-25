using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.PetShop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.PetShop;

namespace Study.Lab3.Logic.Services.PetShop;

public sealed class PetToyService : IPetToyService
{
    public async Task CreateOrUpdatePetToyValidateAndThrowAsync(
        DataContext dataContext,
        PetToy petToy,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(petToy.Name))
            throw new BusinessLogicException("Название игрушки не может быть пустым");

        if (petToy.Price <= 0)
            throw new BusinessLogicException("Цена игрушки должна быть положительным числом");

        if (petToy.StockQuantity < 0)
            throw new BusinessLogicException("Количество в наличии не может быть отрицательным");

        if (!petToy.IsSafe)
            throw new BusinessLogicException("Нельзя добавить небезопасную игрушку в каталог");

        if (await dataContext.PetToys.AnyAsync(
                x => x.Name == petToy.Name &&
                     x.Material == petToy.Material &&
                     x.Size == petToy.Size &&
                     x.TargetSpecies == petToy.TargetSpecies &&
                     x.IsnPetToy != petToy.IsnPetToy,
                cancellationToken))
            throw new BusinessLogicException(
                $"Игрушка \"{petToy.Name}\" из материала {petToy.Material} размера {petToy.Size} для {petToy.TargetSpecies} уже существует");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        PetToy petToy,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.PetToys.AnyAsync(x => x.IsnPetToy == petToy.IsnPetToy, cancellationToken))
            throw new BusinessLogicException(
                $"Игрушка с идентификатором \"{petToy.IsnPetToy}\" не существует");
    }
}