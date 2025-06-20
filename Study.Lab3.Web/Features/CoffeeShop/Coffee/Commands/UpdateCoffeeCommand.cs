using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CoffeeShop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CoffeeShop.Coffee.DtoModels;

namespace Study.Lab3.Web.Features.CoffeeShop.Coffee.Commands;

/// <summary>
/// Обновление кофе
/// </summary>
public sealed class UpdateCoffeeCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные кофе
    /// </summary>
    [Required]
    [FromBody]
    public UpdateCoffeeDto Coffee { get; init; }
}

public sealed class UpdateCoffeeCommandHandler : IRequestHandler<UpdateCoffeeCommand, Guid>
{
    private readonly DataContext _context;
    private readonly ICoffeeService _coffeeService;

    public UpdateCoffeeCommandHandler(DataContext context, ICoffeeService coffeeService)
    {
        _context = context;
        _coffeeService = coffeeService;
    }

    public async Task<Guid> Handle(UpdateCoffeeCommand request, CancellationToken cancellationToken)
    {
        var coffee = await _context.Coffee
            .FirstOrDefaultAsync(x => x.IsnCoffee == request.Coffee.IsnCoffee, cancellationToken);

        if (coffee == null)
        {
            throw new InvalidOperationException("Кофе не найден.");
        }

        coffee.Name = request.Coffee.Name;
        coffee.Description = request.Coffee.Description;
        coffee.Price = request.Coffee.Price;
        coffee.Size = request.Coffee.Size;
        coffee.CaffeineContent = request.Coffee.CaffeineContent;
        coffee.IsAvailable = request.Coffee.IsAvailable;

        await _coffeeService.CreateOrUpdateCoffeeValidateAndThrowAsync(_context, coffee, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return coffee.IsnCoffee;
    }
}