using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Photography;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Photography;

namespace Study.Lab3.Logic.Services.Photography;

public sealed class PhotographyEquipmentService : IPhotographyEquipmentService
{
    public async Task CreateOrUpdateEquipmentValidateAndThrowAsync(
        DataContext dataContext,
        PhotographyEquipment equipment,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(equipment.Name))
            throw new BusinessLogicException("Название оборудования не может быть пустым");

        if (string.IsNullOrWhiteSpace(equipment.Brand))
            throw new BusinessLogicException("Бренд оборудования не может быть пустым");

        if (string.IsNullOrWhiteSpace(equipment.Model))
            throw new BusinessLogicException("Модель оборудования не может быть пустой");

        // Проверка уникальности серийного номера, если он указан
        if (!string.IsNullOrWhiteSpace(equipment.SerialNumber))
        {
            if (await dataContext.PhotographyEquipments.AnyAsync(
                    x => x.SerialNumber == equipment.SerialNumber &&
                         x.IsnPhotographyEquipment != equipment.IsnPhotographyEquipment,
                    cancellationToken))
                throw new BusinessLogicException(
                    $"Оборудование с серийным номером \"{equipment.SerialNumber}\" уже существует");
        }

        // Проверка даты покупки
        if (equipment.PurchaseDate.HasValue && equipment.PurchaseDate.Value > DateTime.Now)
            throw new BusinessLogicException("Дата покупки не может быть в будущем");

        if (equipment.PurchaseDate.HasValue && equipment.PurchaseDate.Value < new DateTime(1900, 1, 1))
            throw new BusinessLogicException("Дата покупки не может быть ранее 1900 года");

        // Проверка цены
        if (equipment.Price.HasValue && equipment.Price.Value < 0)
            throw new BusinessLogicException("Цена оборудования не может быть отрицательной");

        // Проверка уникальности комбинации бренд + модель + серийный номер
        if (await dataContext.PhotographyEquipments.AnyAsync(
                x => x.Brand == equipment.Brand &&
                     x.Model == equipment.Model &&
                     x.SerialNumber == equipment.SerialNumber &&
                     x.IsnPhotographyEquipment != equipment.IsnPhotographyEquipment,
                cancellationToken))
            throw new BusinessLogicException(
                $"Оборудование \"{equipment.Brand} {equipment.Model}\" с серийным номером \"{equipment.SerialNumber}\" уже существует");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        PhotographyEquipment equipment,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.PhotographyEquipments.AnyAsync(
                x => x.IsnPhotographyEquipment == equipment.IsnPhotographyEquipment, cancellationToken))
            throw new BusinessLogicException(
                $"Оборудование с идентификатором \"{equipment.IsnPhotographyEquipment}\" не существует");
    }
}