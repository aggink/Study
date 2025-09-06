using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CarDealership.Sales.DtoModels;

namespace Study.Lab3.Web.Features.CarDealership.Sales.Queries;

/// <summary>
/// Получение продажи автомобиля по идентификатору
/// </summary>
public sealed class GetCarDealershipSaleByIdQuery : IRequest<CarDealershipSaleDto>
{
    /// <summary>
    /// Идентификатор продажи
    /// </summary>
    public Guid Id { get; init; }
}

public class GetCarDealershipSaleByIdQueryHandler : IRequestHandler<GetCarDealershipSaleByIdQuery, CarDealershipSaleDto>
{
    private readonly DataContext _dataContext;

    public GetCarDealershipSaleByIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<CarDealershipSaleDto> Handle(GetCarDealershipSaleByIdQuery request, CancellationToken cancellationToken)
    {
        var sale = await _dataContext.CarDealershipSales
            .FirstOrDefaultAsync(x => x.IsnSale == request.Id, cancellationToken);

        if (sale == null)
            throw new InvalidOperationException($"Продажа с идентификатором {request.Id} не найдена");

        return new CarDealershipSaleDto
        {
            IsnSale = sale.IsnSale,
            IsnCustomer = sale.IsnCustomer,
            IsnVehicle = sale.IsnVehicle,
            SaleDate = sale.SaleDate,
            Discount = sale.Discount,
            FinalPrice = sale.FinalPrice
        };
    }
}