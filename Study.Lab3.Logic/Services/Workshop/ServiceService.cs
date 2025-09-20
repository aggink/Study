using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Workshop;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Workshop;

namespace Study.Lab3.Logic.Services.Workshop;

public sealed class ServiceService : IServiceService
{
    public async Task CreateOrUpdateServiceValidateAndThrowAsync(
        DataContext dataContext,
        Service service,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(service.Name))
            throw new BusinessLogicException("Название услуги не может быть пустым");

        if (service.Price < ModelConstants.Service.MinPrice ||
            service.Price > ModelConstants.Service.MaxPrice)
            throw new BusinessLogicException(
                $"Цена услуги должна быть от {ModelConstants.Service.MinPrice} до {ModelConstants.Service.MaxPrice}");

        if (service.Duration < ModelConstants.Service.MinDuration ||
            service.Duration > ModelConstants.Service.MaxDuration)
            throw new BusinessLogicException(
                $"Длительность услуги должна быть от {ModelConstants.Service.MinDuration} до {ModelConstants.Service.MaxDuration} минут");

        // Проверка уникальности названия
        if (await dataContext.Services.AnyAsync(x =>
            x.Name.ToLower() == service.Name.ToLower() &&
            x.IsnService != service.IsnService,
            cancellationToken))
            throw new BusinessLogicException($"Услуга с названием \"{service.Name}\" уже существует");
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Service service,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Services.AnyAsync(x => x.IsnService == service.IsnService, cancellationToken))
            throw new BusinessLogicException($"Услуга с идентификатором \"{service.IsnService}\" не существует");

        if (await dataContext.ServiceOrders.AnyAsync(x => x.IsnService == service.IsnService, cancellationToken))
            throw new BusinessLogicException("Невозможно удалить услугу, так как по ней есть заказы");
    }
}