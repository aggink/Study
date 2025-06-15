using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CarService;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.CarService;

namespace Study.Lab3.Logic.Services.CarService;

public sealed class ServiceRecordService : IServiceRecordService
{
    public async Task CreateOrUpdateServiceRecordValidateAndThrowAsync(
        DataContext dataContext, 
        ServiceRecord record,
        CancellationToken cancellationToken = default)
    {
       
        if (string.IsNullOrWhiteSpace(record.CarLicensePlate))
            throw new BusinessLogicException("Государственный номер автомобиля не может быть пустым");

        if (string.IsNullOrWhiteSpace(record.ServiceType))
            throw new BusinessLogicException("Тип обслуживания не может быть пустым");

        if (string.IsNullOrWhiteSpace(record.Description))
            throw new BusinessLogicException("Описание работ не может быть пустым");

        if (string.IsNullOrWhiteSpace(record.MechanicName))
            throw new BusinessLogicException("Имя механика не может быть пустым");

        if (record.ServiceDate > DateTime.UtcNow.AddDays(1))
            throw new BusinessLogicException("Дата обслуживания не может быть в будущем");

        if (record.Cost < 0)
            throw new BusinessLogicException("Стоимость не может быть отрицательной");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext, 
        ServiceRecord record,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.ServiceRecords.AnyAsync(x => x.IsnServiceRecord == record.IsnServiceRecord, cancellationToken))
            throw new BusinessLogicException($"Такой записи нет");
        
        if (record.IsCompleted && (DateTime.UtcNow - record.ServiceDate).TotalDays > 30)
            throw new BusinessLogicException("Невозможно удалить завершенную запись старше 30 дней");
    }
}