using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.HospitalStore;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.HospitalStore;

namespace Study.Lab3.Logic.Services.HospitalStore;

public sealed class PatientService : IPatientService
{
    public async Task CreateOrUpdatePatientValidateAndThrowAsync(
        DataContext dataContext,
        Patient patient,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(patient.FullName) || patient.FullName.Length > ModelConstants.Patient.FullNameMaxLength)
        {
            throw new BusinessLogicException($"ФИО не должно быть пустым и не должно превышать {ModelConstants.Patient.FullNameMaxLength} символов");
        }

        if (string.IsNullOrWhiteSpace(patient.MedicalCardId) || patient.MedicalCardId.Length > ModelConstants.Patient.MedicalCardIdMaxLength)
        {
            throw new BusinessLogicException($"Номер медкарты не должен быть пустым и не должен превышать {ModelConstants.Patient.MedicalCardIdMaxLength} символов");
        }

        if (string.IsNullOrWhiteSpace(patient.Phone) || patient.Phone.Length > ModelConstants.Patient.PhoneMaxLength)
        {
            throw new BusinessLogicException($"Телефон не должен быть пустым и не должен превышать {ModelConstants.Patient.PhoneMaxLength} символов");
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Patient patient,
        CancellationToken cancellationToken = default)
    {
        bool hasOrders = await dataContext.Orders.AnyAsync(x => x.IsnPatient == patient.IsnPatient, cancellationToken);
        if (hasOrders)
        {
            throw new BusinessLogicException("Невозможно удалить пациента, у которого есть связанные заказы");
        }
    }
}
