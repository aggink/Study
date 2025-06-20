using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CoffeeShop.CoffeeShops.DtoModels;

namespace Study.Lab3.Web.Features.CoffeeShop.CoffeeShops.Queries;

/// <summary>
/// Получение списка кофеен
/// </summary>
public sealed class GetListCoffeeShopQuery : IRequest<CoffeeShopDto[]>
{
}

public sealed class GetListCoffeeShopQueryHandler : IRequestHandler<GetListCoffeeShopQuery, CoffeeShopDto[]>
{
    private readonly DataContext _context;

    public GetListCoffeeShopQueryHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<CoffeeShopDto[]> Handle(GetListCoffeeShopQuery request, CancellationToken cancellationToken)
    {
        var coffeeShops = await _context.CoffeeShops
            .AsNoTracking()
            .Select(coffeeShop => new CoffeeShopDto
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
            })
            .ToArrayAsync(cancellationToken);

        return coffeeShops;
    }
}