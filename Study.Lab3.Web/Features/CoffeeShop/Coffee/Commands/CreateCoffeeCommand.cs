using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.CoffeeShop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CoffeeShop.Coffee.DtoModels;

namespace Study.Lab3.Web.Features.CoffeeShop.Coffee.Commands;

/// <summary>
/// Создание кофе
/// </summary>
public sealed class CreateCoffeeCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные кофе
    /// </summary>
    [Required]
    [FromBody]
    public CreateCoffeeDto Coffee { get; init; }
}

public sealed class CreateCoffeeCommandHandler : IRequestHandler<CreateCoffeeCommand, Guid>
{
    private readonly DataContext _context;
    private readonly ICoffeeService _coffeeService;

    public CreateCoffeeCommandHandler(DataContext context, ICoffeeService coffeeService)
    {
        _context = context;
        _coffeeService = coffeeService;
    }

    public async Task<Guid> Handle(CreateCoffeeCommand request, CancellationToken cancellationToken)
    {
        var coffee = new Storage.Models.CoffeeShop.Coffee
        {
            IsnCoffee = Guid.NewGuid(),
            Name = request.Coffee.Name,
            Description = request.Coffee.Description,
            Price = request.Coffee.Price,
            Size = request.Coffee.Size,
            CaffeineContent = request.Coffee.CaffeineContent,
            IsAvailable = request.Coffee.IsAvailable,
            CreatedDate = DateTime.UtcNow
        };

        await _coffeeService.CreateOrUpdateCoffeeValidateAndThrowAsync(_context, coffee, cancellationToken);

        await _context.Coffee.AddAsync(coffee, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return coffee.IsnCoffee;
    }
}