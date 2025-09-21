using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CarDealership;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CarDealership.Sales.DtoModels;

namespace Study.Lab3.Web.Features.CarDealership.Sales.Commands;

/// <summary>
/// Обновление продажи автомобиля
/// </summary>
public sealed class UpdateCarDealershipSaleCommand : IRequest<Guid>
{
    /// <summary>
    /// Идентификатор продажи
    /// </summary>
    [Required]
    public Guid IsnSale { get; init; }
    
    /// <summary>
    /// Данные продажи
    /// </summary>
    [Required]
    [FromBody]
    public UpdateCarDealershipSaleDto Sale { get; init; }
}

public class UpdateCarDealershipSaleCommandHandler : IRequestHandler<UpdateCarDealershipSaleCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly ICarDealershipSaleService _saleService;

    public UpdateCarDealershipSaleCommandHandler(
        DataContext dataContext,
        ICarDealershipSaleService saleService)
    {
        _dataContext = dataContext;
        _saleService = saleService;
    }

    public async Task<Guid> Handle(UpdateCarDealershipSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _dataContext.CarDealershipSales
            .FirstOrDefaultAsync(x => x.IsnSale == request.IsnSale, cancellationToken);

        if (sale == null)
            throw new InvalidOperationException($"Продажа с идентификатором {request.IsnSale} не найдена");

        sale.IsnCustomer = request.Sale.IsnCustomer;
        sale.IsnVehicle = request.Sale.IsnVehicle;
        sale.Discount = request.Sale.Discount;
        sale.FinalPrice = request.Sale.FinalPrice;

        await _saleService.CreateOrUpdateSaleValidateAndThrowAsync(_dataContext, sale, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return sale.IsnSale;
    }
}