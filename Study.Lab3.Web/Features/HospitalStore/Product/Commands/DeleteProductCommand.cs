using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.HospitalStore;
using Study.Lab3.Storage.Database;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.HospitalStore.Product.Commands;

/// <summary>
/// Удаление товара
/// </summary>
public sealed class DeleteProductCommand : IRequest
{
    /// <summary>
    /// Идентификатор товара
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnProduct { get; init; }
}

public sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly DataContext _dataContext;
    private readonly IProductService _productService;

    public DeleteProductCommandHandler(
        DataContext dataContext,
        IProductService productService)
    {
        _dataContext = dataContext;
        _productService = productService;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _dataContext.Products
            .FirstOrDefaultAsync(x => x.IsnProduct == request.IsnProduct, cancellationToken)
                ?? throw new BusinessLogicException($"Товар с идентификатором \"{request.IsnProduct}\" не существует");

        await _productService.CanDeleteAndThrowAsync(
            _dataContext, product, cancellationToken);

        _dataContext.Products.Remove(product);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}