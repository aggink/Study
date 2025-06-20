using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CoffeeShop.Coffee.DtoModels;

namespace Study.Lab3.Web.Features.CoffeeShop.Coffee.Queries;

/// <summary>
/// Получение кофе по идентификатору
/// </summary>
public sealed class GetCoffeeByIsnQuery : IRequest<CoffeeDto>
{
    /// <summary>
    /// Идентификатор кофе
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnCoffee { get; init; }
}

public sealed class GetCoffeeByIsnQueryHandler : IRequestHandler<GetCoffeeByIsnQuery, CoffeeDto>
{
    private readonly DataContext _context;

    public GetCoffeeByIsnQueryHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<CoffeeDto> Handle(GetCoffeeByIsnQuery request, CancellationToken cancellationToken)
    {
        var coffee = await _context.Coffee
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnCoffee == request.IsnCoffee, cancellationToken);

        if (coffee == null)
        {
            throw new InvalidOperationException("Кофе не найден.");
        }

        return new CoffeeDto
        {
            IsnCoffee = coffee.IsnCoffee,
            Name = coffee.Name,
            Description = coffee.Description,
            Price = coffee.Price,
            Size = coffee.Size,
            CaffeineContent = coffee.CaffeineContent,
            IsAvailable = coffee.IsAvailable,
            CreatedDate = coffee.CreatedDate
        };
    }
}