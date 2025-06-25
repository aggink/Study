using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Pharmacy;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Pharmacy;

namespace Study.Lab3.Logic.Services.Pharmacy;

/// <summary>
/// Сервис для работы с рецептами
/// </summary>
public sealed class PrescriptionService : IPrescriptionService
{
    public async Task CreateOrUpdatePrescriptionValidateAndThrowAsync(
        DataContext dataContext,
        Prescription prescription,
        CancellationToken cancellationToken = default)
    {
        // Проверка клиента
        var customer = await dataContext.PharmacyCustomers
            .FirstOrDefaultAsync(x => x.IsnCustomer == prescription.IsnCustomer, cancellationToken);
        if (customer == null)
            throw new BusinessLogicException($"Клиент с идентификатором {prescription.IsnCustomer} не найден");

        // Проверка медикамента
        var medication = await dataContext.PharmacyMedications
            .FirstOrDefaultAsync(x => x.IsnMedication == prescription.IsnMedication, cancellationToken);
        if (medication == null)
            throw new BusinessLogicException($"Медикамент с идентификатором {prescription.IsnMedication} не найден");

        // Проверка, что медикамент требует рецепт
        if (!medication.RequiresPrescription)
            throw new BusinessLogicException("Рецепт не требуется для данного медикамента");

        // Проверка номера рецепта
        if (string.IsNullOrWhiteSpace(prescription.PrescriptionNumber))
            throw new BusinessLogicException("Номер рецепта не может быть пустым");

        // Проверка уникальности номера рецепта
        if (await dataContext.Prescriptions.AnyAsync(
                x => x.IsnPrescription != prescription.IsnPrescription &&
                     x.PrescriptionNumber == prescription.PrescriptionNumber,
                cancellationToken))
        {
            throw new BusinessLogicException($"Рецепт с номером \"{prescription.PrescriptionNumber}\" уже существует");
        }

        // Проверка имени врача
        if (string.IsNullOrWhiteSpace(prescription.DoctorName))
            throw new BusinessLogicException("Имя врача не может быть пустым");

        // Проверка дозировки
        if (prescription.Dosage < ModelConstants.Prescription.MinDosage ||
            prescription.Dosage > ModelConstants.Prescription.MaxDosage)
            throw new BusinessLogicException(
                $"Дозировка должна быть между {ModelConstants.Prescription.MinDosage} и {ModelConstants.Prescription.MaxDosage}");

        // Проверка даты выписки
        if (prescription.IssueDate > DateTime.UtcNow)
            throw new BusinessLogicException("Дата выписки не может быть в будущем");

        // Проверка срока действия
        if (prescription.ExpiryDate <= prescription.IssueDate)
            throw new BusinessLogicException("Срок действия рецепта должен быть после даты выписки");

        // Проверка доступности медикамента
        if (medication.QuantityInStock < prescription.Dosage)
            throw new BusinessLogicException("Недостаточное количество медикаментов на складе");

        // Проверка срока годности медикамента
        if (medication.ExpirationDate < prescription.ExpiryDate)
            throw new BusinessLogicException("Срок годности медикамента истекает раньше срока действия рецепта");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Prescription prescription,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Prescriptions.AnyAsync(x => x.IsnPrescription == prescription.IsnPrescription,
                cancellationToken))
        {
            throw new BusinessLogicException($"Рецепт с идентификатором {prescription.IsnPrescription} не найден");
        }
    }
}