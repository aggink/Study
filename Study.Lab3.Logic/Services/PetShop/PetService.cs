using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.PetShop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.PetShop;

namespace Study.Lab3.Logic.Services.PetShop;

public sealed class PetService : IPetService
{
    public async Task CreateOrUpdatePetValidateAndThrowAsync(
        DataContext dataContext,
        Pet pet,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(pet.Name))
            throw new BusinessLogicException("Кличка животного не может быть пустой");

        if (pet.AgeInMonths <= 0)
            throw new BusinessLogicException("Возраст животного должен быть положительным числом");

        if (pet.Price <= 0)
            throw new BusinessLogicException("Цена животного должна быть положительным числом");

        if (pet.ArrivalDate > DateTime.UtcNow)
            throw new BusinessLogicException("Дата поступления не может быть в будущем");

        if (await dataContext.Pets.AnyAsync(
                x => x.Name == pet.Name &&
                     x.Species == pet.Species &&
                     x.IsnPet != pet.IsnPet,
                cancellationToken))
            throw new BusinessLogicException(
                $"Животное вида {pet.Species} с кличкой \"{pet.Name}\" уже существует");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Pet pet,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Pets.AnyAsync(x => x.IsnPet == pet.IsnPet, cancellationToken))
            throw new BusinessLogicException(
                $"Животное с идентификатором \"{pet.IsnPet}\" не существует");
    }
}