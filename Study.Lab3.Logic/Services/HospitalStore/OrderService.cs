using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.HospitalStore;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.HospitalStore;

namespace Study.Lab3.Logic.Services.HospitalStore;

public sealed class OrderService : IOrderService
{
    public async Task CreateOrUpdateOrderValidateAndThrowAsync(
        DataContext dataContext,
        Order order,
        CancellationToken cancellationToken = default)
    {
        if (!await dataContext.Patients.AnyAsync(x => x.IsnPatient == order.IsnPatient, cancellationToken))
        {
            throw new BusinessLogicException($"Пациент с идентификатором \"{order.IsnPatient}\" не существует");
        }

        if (!await dataContext.Products.AnyAsync(x => x.IsnProduct == order.IsnProduct, cancellationToken))
        {
            throw new BusinessLogicException($"Товар с идентификатором \"{order.IsnProduct}\" не существует");
        }

        if (order.Quantity < ModelConstants.Order.QuantityMin || order.Quantity > ModelConstants.Order.QuantityMax)
        {
            throw new BusinessLogicException(
                $"Количество товара должно быть от {ModelConstants.Order.QuantityMin} до {ModelConstants.Order.QuantityMax}");
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        Order order,
        CancellationToken cancellationToken = default)
    {
        return;
    }
}
