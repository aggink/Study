using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CarDealership.Sales.DtoModels;

namespace Study.Lab3.Web.Features.CarDealership.Sales.Queries;

public sealed class GetCarDealershipSalesListQuery : IRequest<CarDealershipSaleDto[]>
{
}

public class GetCarDealershipSalesListQueryHandler : IRequestHandler<GetCarDealershipSalesListQuery, CarDealershipSaleDto[]>
{
    private readonly DataContext _dataContext;

    public GetCarDealershipSalesListQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<CarDealershipSaleDto[]> Handle(GetCarDealershipSalesListQuery request, CancellationToken cancellationToken)
    {
        var sales = await _dataContext.CarDealershipSales
            .Select(sale => new CarDealershipSaleDto
            {
                IsnSale = sale.IsnSale,
                IsnCustomer = sale.IsnCustomer,
                IsnVehicle = sale.IsnVehicle,
                SaleDate = sale.SaleDate,
                Discount = sale.Discount,
                FinalPrice = sale.FinalPrice
            })
            .ToArrayAsync(cancellationToken);

        return sales;
    }
}