using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Shelter;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Shelter;

namespace Study.Lab3.Logic.Services.Shelter;

public sealed class MiniPigService : IMiniPigService
{
    public async Task CreateOrUpdateMiniPigValidateAndThrowAsync(DataContext dataContext, MiniPig minipig,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(minipig.Nickname))
        {
            throw new BusinessLogicException("Имя мини пига не может быть пустым");
        }

        if (minipig.BirthDate.HasValue)
        {
            if (minipig.BirthDate.Value > DateTime.Today)
                throw new BusinessLogicException("Дата рождения не может быть в будущем");

            var age = DateTime.Today.Year - minipig.BirthDate.Value.Year;
            if (minipig.BirthDate.Value.Date > DateTime.Today.AddYears(-age))
                age--;

            if (age > 20)
                throw new BusinessLogicException("Мини пиг слишком старый");
        }

        if (string.IsNullOrWhiteSpace(minipig.Breed))
        {
            throw new BusinessLogicException("Порода мини пига не может быть пустой");
        }

        if (string.IsNullOrWhiteSpace(minipig.Color))
        {
            throw new BusinessLogicException("Цвет мини пига не может быть пустым");
        }

        if (minipig.ArrivalDate > DateTime.Today)
            throw new BusinessLogicException("Мини пиг не может быть в будущем");

        if (string.IsNullOrEmpty(minipig.PhotoUrl))
            throw new BusinessLogicException("Необходимо указать URL фотографии мини пига");

        if (await dataContext.MiniPigs.AnyAsync(
                x => x.PhotoUrl == minipig.PhotoUrl && x.IsnMiniPig != minipig.IsnMiniPig,
                cancellationToken))
        {
            throw new BusinessLogicException("Фото уже используется для другого мини пига");
        }

        if (minipig.Weight is < 1 or > 20)
        {
            throw new BusinessLogicException("Вес мини пига должен быть в диапазоне от 10 до 120 кг");
        }

        if (minipig.Age is < 0 or > 20)
        {
            throw new BusinessLogicException("Возраст мини пига должен быть в диапазоне от 0 до 20 лет");
        }

    }
}