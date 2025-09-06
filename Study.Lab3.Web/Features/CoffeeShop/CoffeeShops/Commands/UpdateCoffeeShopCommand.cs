using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CoffeeShop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CoffeeShop.CoffeeShops.DtoModels;

namespace Study.Lab3.Web.Features.CoffeeShop.CoffeeShops.Commands;

/// <summary>
/// Обновление кофейни
/// </summary>
public sealed class UpdateCoffeeShopCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные кофейни
    /// </summary>
    [Required]
    [FromBody]
    public UpdateCoffeeShopDto CoffeeShop { get; init; }
}

public sealed class UpdateCoffeeShopCommandHandler : IRequestHandler<UpdateCoffeeShopCommand, Guid>
{
    private readonly DataContext _context;
    private readonly ICoffeeShopService _coffeeShopService;

    public UpdateCoffeeShopCommandHandler(DataContext context, ICoffeeShopService coffeeShopService)
    {
        _context = context;
        _coffeeShopService = coffeeShopService;
    }

    public async Task<Guid> Handle(UpdateCoffeeShopCommand request, CancellationToken cancellationToken)
    {
        var coffeeShop = await _context.CoffeeShops
            .FirstOrDefaultAsync(x => x.IsnCoffeeShop == request.CoffeeShop.IsnCoffeeShop, cancellationToken);

        if (coffeeShop == null)
        {
            throw new InvalidOperationException("Кофейня не найдена.");
        }

        coffeeShop.Name = request.CoffeeShop.Name;
        coffeeShop.Address = request.CoffeeShop.Address;
        coffeeShop.Phone = request.CoffeeShop.Phone;
        coffeeShop.Email = request.CoffeeShop.Email;
        coffeeShop.WorkingHours = request.CoffeeShop.WorkingHours;
        coffeeShop.Rating = request.CoffeeShop.Rating;
        coffeeShop.OpeningDate = request.CoffeeShop.OpeningDate;
        coffeeShop.IsActive = request.CoffeeShop.IsActive;

        await _coffeeShopService.CreateOrUpdateCoffeeShopValidateAndThrowAsync(_context, coffeeShop, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return coffeeShop.IsnCoffeeShop;
    }
}