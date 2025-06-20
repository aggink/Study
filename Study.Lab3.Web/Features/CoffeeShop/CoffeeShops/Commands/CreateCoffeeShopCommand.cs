using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.CoffeeShop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CoffeeShop.CoffeeShops.DtoModels;

namespace Study.Lab3.Web.Features.CoffeeShop.CoffeeShops.Commands;

/// <summary>
/// Создание кофейни
/// </summary>
public sealed class CreateCoffeeShopCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные кофейни
    /// </summary>
    [Required]
    [FromBody]
    public CreateCoffeeShopDto CoffeeShop { get; init; }
}

public sealed class CreateCoffeeShopCommandHandler : IRequestHandler<CreateCoffeeShopCommand, Guid>
{
    private readonly DataContext _context;
    private readonly ICoffeeShopService _coffeeShopService;

    public CreateCoffeeShopCommandHandler(DataContext context, ICoffeeShopService coffeeShopService)
    {
        _context = context;
        _coffeeShopService = coffeeShopService;
    }

    public async Task<Guid> Handle(CreateCoffeeShopCommand request, CancellationToken cancellationToken)
    {
        var coffeeShop = new Storage.Models.CoffeeShop.CoffeeShop
        {
            IsnCoffeeShop = Guid.NewGuid(),
            Name = request.CoffeeShop.Name,
            Address = request.CoffeeShop.Address,
            Phone = request.CoffeeShop.Phone,
            Email = request.CoffeeShop.Email,
            WorkingHours = request.CoffeeShop.WorkingHours,
            Rating = request.CoffeeShop.Rating,
            OpeningDate = request.CoffeeShop.OpeningDate,
            IsActive = request.CoffeeShop.IsActive
        };

        await _coffeeShopService.CreateOrUpdateCoffeeShopValidateAndThrowAsync(_context, coffeeShop, cancellationToken);

        await _context.CoffeeShops.AddAsync(coffeeShop, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return coffeeShop.IsnCoffeeShop;
    }
}