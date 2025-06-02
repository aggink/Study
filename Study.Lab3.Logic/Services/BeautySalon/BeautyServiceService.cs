using CoreLib.Common.Extensions;
using Study.Lab3.Logic.Interfaces.Services.BeautySalon;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.BeautySalon;

namespace Study.Lab3.Logic.Services.BeautySalon;

public sealed class BeautyServiceService : IBeautyServiceService
{
    public async Task CreateOrUpdateBeautyServiceValidate(
        DataContext dataContext,
        BeautyService beautyservice,
        CancellationToken cancellationToken = default)
    {
        /// Проверка правильности ввода названия услуги
        if (string.IsNullOrWhiteSpace(beautyservice.ServiceName))
        {
            throw new BusinessLogicException($"Название услуги не может быть пустым!");
        }

        if (beautyservice.ServiceName.Length > ModelConstants.BeautyService.ServiceName)
        {
            throw new BusinessLogicException($"Название услуги не может превышать {ModelConstants.BeautyService.ServiceName} символов!");
        }

        /// Проверка правильности ввода описания услуги
        if (string.IsNullOrWhiteSpace(beautyservice.Description))
        {
            throw new BusinessLogicException($"Описание услуги не может быть пустым!");
        }

        if (beautyservice.Description.Length > ModelConstants.BeautyService.Description)
        {
            throw new BusinessLogicException($"Описание услуги не может превышать {ModelConstants.BeautyService.Description} символов!");
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

    public async Task DeleteBeautyServiceValidate(
        DataContext dataContext,
        BeautyService beautyservice,
        CancellationToken cancellationToken = default)
    {
        return;
    }
}