using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Fitness;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Fitness;

namespace Study.Lab3.Logic.Services.Fitness;

public class FitnessEquipmentService : IFitnessEquipmentService
{
    public async Task CreateOrUpdateEquipmentValidateAndThrowAsync(
        DataContext dataContext,
        FitnessEquipment equipment,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(equipment.Name))
            throw new BusinessLogicException("Название оборудования не может быть пустым");

        if (string.IsNullOrWhiteSpace(equipment.Manufacturer))
            throw new BusinessLogicException("Производитель не может быть пустым");

        if (string.IsNullOrWhiteSpace(equipment.Model))
            throw new BusinessLogicException("Модель не может быть пустой");

        if (string.IsNullOrWhiteSpace(equipment.SerialNumber))
            throw new BusinessLogicException("Серийный номер не может быть пустым");

        if (equipment.PurchaseDate > DateTime.UtcNow.Date)
            throw new BusinessLogicException("Дата покупки не может быть в будущем");

        if (equipment.PurchasePrice <= 0)
            throw new BusinessLogicException("Цена покупки должна быть больше нуля");

        if (equipment.LastMaintenanceDate.HasValue && equipment.LastMaintenanceDate.Value > DateTime.UtcNow.Date)
            throw new BusinessLogicException("Дата последнего обслуживания не может быть в будущем");

        // Проверка уникальности серийного номера
        var existingEquipmentWithSerial = await dataContext.Equipments
            .FirstOrDefaultAsync(x => x.SerialNumber == equipment.SerialNumber && x.IsnEquipment != equipment.IsnEquipment, cancellationToken);

        if (existingEquipmentWithSerial != null)
            throw new BusinessLogicException($"Оборудование с серийным номером \"{equipment.SerialNumber}\" уже существует");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        FitnessEquipment equipment,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Equipments.AnyAsync(x => x.IsnEquipment == equipment.IsnEquipment, cancellationToken))
            throw new BusinessLogicException($"Оборудование с идентификатором \"{equipment.IsnEquipment}\" не существует");
    }
}