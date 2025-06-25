using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Pharmacy;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Pharmacy;

namespace Study.Lab3.Logic.Services.Pharmacy;

/// <summary>
/// Сервис для работы с медикаментами аптеки
/// </summary>
public sealed class PharmacyMedicationService : IPharmacyMedicationService
{
    public async Task CreateOrUpdateMedicationValidateAndThrowAsync(
        DataContext dataContext,
        PharmacyMedication medication,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(medication.Name))
            throw new BusinessLogicException("Название медикамента не может быть пустым");
        
        if (string.IsNullOrWhiteSpace(medication.Manufacturer))
            throw new BusinessLogicException("Название производителя не может быть пустым");
        
        if (medication.Price < ModelConstants.PharmacyMedication.MinPrice || 
            medication.Price > ModelConstants.PharmacyMedication.MaxPrice)
            throw new BusinessLogicException($"Цена должна быть между {ModelConstants.PharmacyMedication.MinPrice} и {ModelConstants.PharmacyMedication.MaxPrice}");
        
        if (medication.QuantityInStock < ModelConstants.PharmacyMedication.MinQuantity || 
            medication.QuantityInStock > ModelConstants.PharmacyMedication.MaxQuantity)
            throw new BusinessLogicException($"Количество должно быть между {ModelConstants.PharmacyMedication.MinQuantity} и {ModelConstants.PharmacyMedication.MaxQuantity}");
        
        if (medication.ExpirationDate <= DateTime.UtcNow)
            throw new BusinessLogicException("Срок годности должен быть в будущем");
        
        // Проверка на дубликаты по названию и производителю
        if (await dataContext.PharmacyMedications.AnyAsync(
                x => x.IsnMedication != medication.IsnMedication && 
                     x.Name == medication.Name && 
                     x.Manufacturer == medication.Manufacturer,
                cancellationToken))
        {
            throw new BusinessLogicException($"Медикамент с названием \"{medication.Name}\" от производителя \"{medication.Manufacturer}\" уже существует");
        }
        
        // Установка даты поступления для новых медикаментов
        if (medication.IsnMedication == Guid.Empty)
        {
            medication.ReceiptDate = DateTime.UtcNow;
        }
    }
    
    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        PharmacyMedication medication,
        CancellationToken cancellationToken = default)
    {
        if (await dataContext.Prescriptions.AnyAsync(x => x.IsnMedication == medication.IsnMedication, cancellationToken))
            throw new BusinessLogicException("Нельзя удалить медикамент, на который выписаны рецепты");
    }
}