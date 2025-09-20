using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CoffeeShop.Coffee.DtoModels;

namespace Study.Lab3.Web.Features.CoffeeShop.Coffee.Queries;

/// <summary>
/// Получение списка кофе
/// </summary>
public sealed class GetListCoffeeQuery : IRequest<CoffeeDto[]>
{
    
}

public sealed class GetListCoffeeQueryHandler : IRequestHandler<GetListCoffeeQuery, CoffeeDto[]>
{
    private readonly DataContext _context;

    public GetListCoffeeQueryHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<CoffeeDto[]> Handle(GetListCoffeeQuery request, CancellationToken cancellationToken)
    {
        var coffeeList = await _context.Coffee
            .AsNoTracking()
            .Select(coffee => new CoffeeDto
            {
                IsnCoffee = coffee.IsnCoffee,
                Name = coffee.Name,
                Description = coffee.Description,
                Price = coffee.Price,
                Size = coffee.Size,
                CaffeineContent = coffee.CaffeineContent,
                IsAvailable = coffee.IsAvailable,
                CreatedDate = coffee.CreatedDate
            })
            .ToArrayAsync(cancellationToken);

        return coffeeList;
    }
}