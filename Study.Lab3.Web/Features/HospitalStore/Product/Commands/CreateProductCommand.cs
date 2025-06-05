using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.HospitalStore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.HospitalStore.Product.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.HospitalStore.Product.Commands;

/// <summary>
/// Создание товара
/// </summary>
public sealed class CreateProductCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные товара
    /// </summary>
    [Required]
    [FromBody]
    public CreateProductDto Product { get; init; }
}

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IProductService _productService;

    public CreateProductCommandHandler(
        DataContext dataContext,
        IProductService productService)
    {
        _dataContext = dataContext;
        _productService = productService;
    }

    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Storage.Models.HospitalStore.Product
        {
            IsnProduct = Guid.NewGuid(),
            Name = request.Product.Name,
            Category = request.Product.Category,
            Price = request.Product.Price
        };

        await _productService.CreateOrUpdateProductValidateAndThrowAsync(
            _dataContext, product, cancellationToken);

        await _dataContext.Products.AddAsync(product, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return product.IsnProduct;
    }
}
