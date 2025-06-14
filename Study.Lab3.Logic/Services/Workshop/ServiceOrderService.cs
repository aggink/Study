using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.Workshop;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Enums.Workshop;
using Study.Lab3.Storage.Models.Workshop;

namespace Study.Lab3.Logic.Services.Workshop;

public sealed class ServiceOrderService : IServiceOrderService
{
    public async Task CreateOrUpdateServiceOrderValidateAndThrowAsync(
        DataContext dataContext,
        ServiceOrder serviceOrder,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Masters.AnyAsync(x => x.IsnMaster == serviceOrder.IsnMaster, cancellationToken))
            throw new BusinessLogicException($"Мастер с идентификатором \"{serviceOrder.IsnMaster}\" не существует");

        if (!await dataContext.Services.AnyAsync(x => x.IsnService == serviceOrder.IsnService, cancellationToken))
            throw new BusinessLogicException($"Услуга с идентификатором \"{serviceOrder.IsnService}\" не существует");

        if (string.IsNullOrWhiteSpace(serviceOrder.CustomerName))
            throw new BusinessLogicException("Имя клиента не может быть пустым");

        if (string.IsNullOrWhiteSpace(serviceOrder.CustomerPhone))
            throw new BusinessLogicException("Телефон клиента не может быть пустым");

        if (serviceOrder.OrderDate > DateTime.UtcNow)
            throw new BusinessLogicException("Дата заказа не может быть в будущем");

        // Проверка формата телефона
        if (!IsValidPhone(serviceOrder.CustomerPhone))
            throw new BusinessLogicException("Неверный формат телефона клиента");

        // Проверка итоговой стоимости, если указана
        if (serviceOrder.TotalPrice.HasValue)
        {
            if (serviceOrder.TotalPrice.Value < ModelConstants.ServiceOrder.MinTotalPrice ||
                serviceOrder.TotalPrice.Value > ModelConstants.ServiceOrder.MaxTotalPrice)
                throw new BusinessLogicException(
                    $"Итоговая стоимость должна быть от {ModelConstants.ServiceOrder.MinTotalPrice} до {ModelConstants.ServiceOrder.MaxTotalPrice}");
        }

        // Бизнес-правило: нельзя изменить статус с Completed на другой
        if (serviceOrder.IsnServiceOrder != Guid.Empty)
        {
            var existingOrder = await dataContext.ServiceOrders
                .FirstOrDefaultAsync(x => x.IsnServiceOrder == serviceOrder.IsnServiceOrder, cancellationToken);

            if (existingOrder != null && existingOrder.Status == OrderStatus.Completed &&
                serviceOrder.Status != OrderStatus.Completed)
                throw new BusinessLogicException("Нельзя изменить статус завершенного заказа");
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        ServiceOrder serviceOrder,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.ServiceOrders.AnyAsync(x => x.IsnServiceOrder == serviceOrder.IsnServiceOrder, cancellationToken))
            throw new BusinessLogicException($"Заказ с идентификатором \"{serviceOrder.IsnServiceOrder}\" не существует");

        // Бизнес-правило: нельзя удалять завершенные заказы
        if (serviceOrder.Status == OrderStatus.Completed)
            throw new BusinessLogicException("Нельзя удалить завершенный заказ");

        // Бизнес-правило: нельзя удалять заказы в работе
        if (serviceOrder.Status == OrderStatus.InProgress)
            throw new BusinessLogicException("Нельзя удалить заказ, который находится в работе");
    }

    private static bool IsValidPhone(string phone)
    {
        return phone.All(c => char.IsDigit(c) || c == '+' || c == '-' || c == '(' || c == ')' || c == ' ')
               && phone.Any(char.IsDigit);
    }
}