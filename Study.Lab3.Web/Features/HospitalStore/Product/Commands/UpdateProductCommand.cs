using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.HospitalStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.HospitalStore.Product.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.HospitalStore.Product.Commands;

/// <summary>
/// Редактирование товара
/// </summary>
public sealed class UpdateProductCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные товара
    /// </summary>
    [Required]
    [FromBody]
    public UpdateProductDto Product { get; init; }
}

public sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IProductService _productService;

    public UpdateProductCommandHandler(
        DataContext dataContext,
        IProductService productService)
    {
        _dataContext = dataContext;
        _productService = productService;
    }

    public async Task<Guid> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _dataContext.Products
            .FirstOrDefaultAsync(x => x.IsnProduct == request.Product.IsnProduct, cancellationToken)
                ?? throw new BusinessLogicException($"Товар с идентификатором \"{request.Product.IsnProduct}\" не найден");

        product.Name = request.Product.Name;
        product.Category = request.Product.Category;
        product.Price = request.Product.Price;

        await _productService.CreateOrUpdateProductValidateAndThrowAsync(
            _dataContext, product, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return product.IsnProduct;
    }
}