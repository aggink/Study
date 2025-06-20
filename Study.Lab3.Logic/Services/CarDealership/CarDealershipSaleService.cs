using CoreLib.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CarDealership;
using Study.Lab3.Storage.Constants;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.CarDealership;

namespace Study.Lab3.Logic.Services.CarDealership;

/// <summary>
/// Сервис для работы с продажами автомобилей
/// </summary>
public sealed class CarDealershipSaleService : ICarDealershipSaleService
{
    public async Task CreateOrUpdateSaleValidateAndThrowAsync(
        DataContext dataContext,
        CarDealershipSale sale,
        CancellationToken cancellationToken = default)
    {
        // Проверка наличия клиента
        var customer = await dataContext.CarDealershipCustomers
            .FirstOrDefaultAsync(x => x.IsnCustomer == sale.IsnCustomer, cancellationToken);
        if (customer == null)
            throw new BusinessLogicException($"Клиент с идентификатором {sale.IsnCustomer} не найден");

        // Проверка наличия автомобиля
        var vehicle = await dataContext.Vehicles
            .FirstOrDefaultAsync(x => x.IsnVehicle == sale.IsnVehicle, cancellationToken);
        if (vehicle == null)
            throw new BusinessLogicException($"Автомобиль с идентификатором {sale.IsnVehicle} не найден");

        // Проверка, что автомобиль доступен для продажи
        if (!vehicle.IsAvailable)
            throw new BusinessLogicException("Автомобиль недоступен для продажи");

        // Проверка, что автомобиль не продан в другой продаже
        if (await dataContext.CarDealershipSales.AnyAsync(
            x => x.IsnVehicle == sale.IsnVehicle && x.IsnSale != sale.IsnSale,
            cancellationToken))
        {
            throw new BusinessLogicException("Автомобиль уже продан");
        }

        // Проверка скидки
        if (sale.Discount < ModelConstants.CarDealershipSale.MinDiscount || sale.Discount > ModelConstants.CarDealershipSale.MaxDiscount)
            throw new BusinessLogicException($"Скидка должна быть между {ModelConstants.CarDealershipSale.MinDiscount} и {ModelConstants.CarDealershipSale.MaxDiscount}");

        // Проверка итоговой цены
        if (sale.FinalPrice < ModelConstants.CarDealershipSale.MinFinalPrice || sale.FinalPrice > ModelConstants.CarDealershipSale.MaxFinalPrice)
            throw new BusinessLogicException($"Итоговая цена должна быть между {ModelConstants.CarDealershipSale.MinFinalPrice} и {ModelConstants.CarDealershipSale.MaxFinalPrice}");

        // Проверка логики цены: итоговая цена = цена автомобиля - скидка
        if (Math.Abs(sale.FinalPrice - (vehicle.Price - sale.Discount)) > 0.01)
            throw new BusinessLogicException("Итоговая цена должна равняться цене автомобиля за вычетом скидки");

        // Установка даты продажи для новых продаж
        if (sale.IsnSale == Guid.Empty)
        {
            sale.SaleDate = DateTime.UtcNow;
        }
    }

    public async Task CanDeleteAndThrowAsync(
        DataContext dataContext,
        CarDealershipSale sale,
        CancellationToken cancellationToken = default)
    {
        if (sale.IsnSale == Guid.Empty)
            throw new BusinessLogicException("Невозможно удалить несуществующую продажу");
        
        if (!await dataContext.CarDealershipSales.AnyAsync(x => x.IsnSale == sale.IsnSale, cancellationToken))
            throw new BusinessLogicException($"Продажа с идентификатором {sale.IsnSale} не найдена");
    }
}