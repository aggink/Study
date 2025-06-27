using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.CarDealership;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.CarDealership;
using Study.Lab3.Web.Features.CarDealership.Sales.DtoModels;

namespace Study.Lab3.Web.Features.CarDealership.Sales.Commands;

/// <summary>
/// Создание продажи автомобиля
/// </summary>
public sealed class CreateCarDealershipSaleCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные продажи
    /// </summary>
    [Required]
    [FromBody]
    public CreateCarDealershipSaleDto Sale { get; init; }
}

public class CreateCarDealershipSaleCommandHandler : IRequestHandler<CreateCarDealershipSaleCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ICarDealershipSaleService _saleService;

    public CreateCarDealershipSaleCommandHandler(
        DataContext dataContext,
        ICarDealershipSaleService saleService)
    {
        _dataContext = dataContext;
        _saleService = saleService;
    }

    public async Task<Guid> Handle(CreateCarDealershipSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = new CarDealershipSale
        {
            IsnSale = Guid.NewGuid(),
            IsnCustomer = request.Sale.IsnCustomer,
            IsnVehicle = request.Sale.IsnVehicle,
            SaleDate = DateTime.UtcNow,
            Discount = request.Sale.Discount,
            FinalPrice = request.Sale.FinalPrice
        };

        await _saleService.CreateOrUpdateSaleValidateAndThrowAsync(_dataContext, sale, cancellationToken);

        _dataContext.CarDealershipSales.Add(sale);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return sale.IsnSale;
    }
}