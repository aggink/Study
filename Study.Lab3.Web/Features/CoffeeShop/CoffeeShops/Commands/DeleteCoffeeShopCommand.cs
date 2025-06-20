using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CoffeeShop;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.CoffeeShop.CoffeeShops.Commands;

/// <summary>
/// Удаление кофейни
/// </summary>
public sealed class DeleteCoffeeShopCommand : IRequest
{
    /// <summary>
    /// Идентификатор кофейни
    /// </summary>
    [Required]
    [FromBody]
    public Guid IsnCoffeeShop { get; init; }
}

public sealed class DeleteCoffeeShopCommandHandler : IRequestHandler<DeleteCoffeeShopCommand>
{
    private readonly DataContext _context;
    private readonly ICoffeeShopService _coffeeShopService;

    public DeleteCoffeeShopCommandHandler(DataContext context, ICoffeeShopService coffeeShopService)
    {
        _context = context;
        _coffeeShopService = coffeeShopService;
    }

    public async Task Handle(DeleteCoffeeShopCommand request, CancellationToken cancellationToken)
    {
        var coffeeShop = await _context.CoffeeShops
            .FirstOrDefaultAsync(x => x.IsnCoffeeShop == request.IsnCoffeeShop, cancellationToken);

        if (coffeeShop == null)
        {
            throw new InvalidOperationException("Кофейня не найдена.");
        }

        await _coffeeShopService.CanDeleteAndThrowAsync(_context, coffeeShop, cancellationToken);

        _context.CoffeeShops.Remove(coffeeShop);
        await _context.SaveChangesAsync(cancellationToken);
    }
}