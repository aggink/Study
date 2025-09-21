using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CarDealership;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.CarDealership.Sales.Commands;

/// <summary>
/// Удаление продажи автомобиля
/// </summary>
public sealed class DeleteCarDealershipSaleCommand : IRequest
{
    /// <summary>
    /// Идентификатор продажи
    /// </summary>
    [Required]
    public Guid IsnSale { get; init; }
}

public class DeleteCarDealershipSaleCommandHandler : IRequestHandler<DeleteCarDealershipSaleCommand>
{
    private readonly DataContext _dataContext;
    private readonly ICarDealershipSaleService _saleService;

    public DeleteCarDealershipSaleCommandHandler(
        DataContext dataContext,
        ICarDealershipSaleService saleService)
    {
        _dataContext = dataContext;
        _saleService = saleService;
    }

    public async Task Handle(DeleteCarDealershipSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _dataContext.CarDealershipSales
            .FirstOrDefaultAsync(x => x.IsnSale == request.IsnSale, cancellationToken);

        if (sale == null)
            throw new InvalidOperationException($"Продажа с идентификатором {request.IsnSale} не найдена");

        await _saleService.CanDeleteAndThrowAsync(_dataContext, sale, cancellationToken);

        _dataContext.CarDealershipSales.Remove(sale);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}