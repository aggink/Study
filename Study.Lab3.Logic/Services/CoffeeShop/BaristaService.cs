using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CoffeeShop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.CoffeeShop;

namespace Study.Lab3.Logic.Services.CoffeeShop;

/// <summary>
/// Сервис бариста
/// </summary>
public class BaristaService : IBaristaService
{
    public async Task CreateOrUpdateBaristaValidateAndThrowAsync(
        DataContext dataContext,
        Barista barista,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(barista.FirstName))
        {
            throw new BusinessLogicException("Имя бариста не может быть пустым.");
        }

        if (string.IsNullOrWhiteSpace(barista.LastName))
        {
            throw new BusinessLogicException("Фамилия бариста не может быть пустой.");
        }

        if (barista.Experience < 0)
        {
            throw new BusinessLogicException("Опыт работы не может быть отрицательным.");
        }

        if (barista.Salary.HasValue && barista.Salary <= 0)
        {
            throw new BusinessLogicException("Зарплата должна быть больше нуля.");
        }

        if (!string.IsNullOrWhiteSpace(barista.Email))
        {
            var existingBarista = await dataContext.Baristas
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == barista.Email && x.IsnBarista != barista.IsnBarista, cancellationToken);

            if (existingBarista != null)
            {
                throw new BusinessLogicException($"Бариста с email '{barista.Email}' уже существует.");
            }
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Barista barista,
        CancellationToken cancellationToken = default)
    {
        var exists = await dataContext.Baristas
            .AnyAsync(x => x.IsnBarista == barista.IsnBarista, cancellationToken);

        if (!exists)
        {
            throw new BusinessLogicException("Бариста не найден.");
        }
    }
}