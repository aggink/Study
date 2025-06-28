using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CoffeeShop.CoffeeShops.DtoModels;

namespace Study.Lab3.Web.Features.CoffeeShop.CoffeeShops.Queries;

/// <summary>
/// Получение кофейни по идентификатору
/// </summary>
public sealed class GetCoffeeShopByIsnQuery : IRequest<CoffeeShopDto>
{
    /// <summary>
    /// Идентификатор кофейни
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnCoffeeShop { get; init; }
}

public sealed class GetCoffeeShopByIsnQueryHandler : IRequestHandler<GetCoffeeShopByIsnQuery, CoffeeShopDto>
{
    private readonly DataContext _context;

    public GetCoffeeShopByIsnQueryHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<CoffeeShopDto> Handle(GetCoffeeShopByIsnQuery request, CancellationToken cancellationToken)
    {
        var coffeeShop = await _context.CoffeeShops
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnCoffeeShop == request.IsnCoffeeShop, cancellationToken);

        if (coffeeShop == null)
        {
            throw new InvalidOperationException("Кофейня не найдена.");
        }

        return new CoffeeShopDto
        {
            IsnCoffeeShop = coffeeShop.IsnCoffeeShop,
            Name = coffeeShop.Name,
            Address = coffeeShop.Address,
            Phone = coffeeShop.Phone,
            Email = coffeeShop.Email,
            WorkingHours = coffeeShop.WorkingHours,
            Rating = coffeeShop.Rating,
            OpeningDate = coffeeShop.OpeningDate,
            IsActive = coffeeShop.IsActive
        };
    }
}