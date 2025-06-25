using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Shelter;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Shelter;

namespace Study.Lab3.Logic.Services.Shelter;

public sealed class CatService : ICatService
{
    public async Task CreateOrUpdateCatValidateAndThrowAsync(DataContext dataContext, Cat cat,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(cat.Nickname))
        {
            throw new BusinessLogicException("Имя кота не может быть пустым");
        }

        if (cat.BirthDate.HasValue)
        {
            if (cat.BirthDate.Value > DateTime.Today)
                throw new BusinessLogicException("Дата рождения не может быть в будущем");

            var age = DateTime.Today.Year - cat.BirthDate.Value.Year;
            if (cat.BirthDate.Value.Date > DateTime.Today.AddYears(-age))
                age--;

            if (age > 30)
                throw new BusinessLogicException("Кот слишком старый");
        }

        if (string.IsNullOrWhiteSpace(cat.Breed))
        {
            throw new BusinessLogicException("Порода кота не может быть пустой");
        }

        if (string.IsNullOrWhiteSpace(cat.Color))
        {
            throw new BusinessLogicException("Цвет кота не может быть пустым");
        }

        if (cat.ArrivalDate > DateTime.Today)
            throw new BusinessLogicException("Кот не может быть в будущем");

        if (string.IsNullOrEmpty(cat.PhotoUrl))
            throw new BusinessLogicException("Необходимо указать URL фотографии кота");

        if (await dataContext.Cats.AnyAsync(
                x => x.PhotoUrl == cat.PhotoUrl && x.IsnCat != cat.IsnCat,
                cancellationToken))
        {
            throw new BusinessLogicException("Фото уже используется для другого кота");
        }

        if (cat.Weight is < 1 or > 20)
        {
            throw new BusinessLogicException("Вес кота должен быть в диапазоне от 1 до 20 кг");
        }

        if (cat.Age is < 0 or > 30)
        {
            throw new BusinessLogicException("Возраст кота должен быть в диапазоне от 0 до 30 лет");
        }

    }
}