using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.BeautySalon;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.BeautySalon;

namespace Study.Lab3.Logic.Services.BeautySalon;

public sealed class BeautyServiceService : IBeautyServiceService
{
    public async Task CreateOrUpdateBeautyServiceValidateAndThrowAsync(
        DataContext dataContext,
        BeautyService beautyservice,
        CancellationToken cancellationToken = default)
    {
        /// Проверка правильности ввода названия услуги
        if (string.IsNullOrWhiteSpace(beautyservice.ServiceName) || (beautyservice.ServiceName.Length > ModelConstants.BeautyService.ServiceName))
        {
            throw new BusinessLogicException($"Название услуги не может быть пустым и не может превышать {ModelConstants.BeautyService.ServiceName} символов!");
        }

        /// Проверка правильности ввода описания услуги
        if (string.IsNullOrWhiteSpace(beautyservice.Description) || (beautyservice.Description.Length > ModelConstants.BeautyService.Description))
        {
            throw new BusinessLogicException($"Описание услуги не может быть пустым и не может превышать {ModelConstants.BeautyService.Description} символов!");
        }

        /// Проверка правильности ввода цены
        if (beautyservice.Price < ModelConstants.BeautyService.MinServicePrice || beautyservice.Price > ModelConstants.BeautyService.MaxServicePrice)
        {
            throw new BusinessLogicException($"Цена должна быть от {ModelConstants.BeautyService.MinServicePrice} до {ModelConstants.BeautyService.MaxServicePrice} рублей!");
        }

        /// Проверка правильности ввода длительности услуги
        if (beautyservice.Duration > ModelConstants.BeautyService.Duration)
        {
            throw new BusinessLogicException($"Длительность услуги не может превышать {ModelConstants.BeautyService.Duration} минут!");
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        BeautyService beautyservice,
        CancellationToken cancellationToken = default)
    {
        bool hasAppointments = await dataContext.BeautyAppointment.AnyAsync(x => x.IsnBeautyService == beautyservice.IsnService, cancellationToken);
        if (hasAppointments)
        {
            throw new BusinessLogicException("Невозможно удалить услугу, котор используется в заказах");
        }
    }
}