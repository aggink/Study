using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CoffeeShop;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.CoffeeShop.Coffee.Commands;

/// <summary>
/// Удаление кофе
/// </summary>
public sealed class DeleteCoffeeCommand : IRequest
{
    /// <summary>
    /// Идентификатор кофе
    /// </summary>
    [Required]
    [FromBody]
    public Guid IsnCoffee { get; init; }
}

public sealed class DeleteCoffeeCommandHandler : IRequestHandler<DeleteCoffeeCommand>
{
    private readonly DataContext _context;
    private readonly ICoffeeService _coffeeService;

    public DeleteCoffeeCommandHandler(DataContext context, ICoffeeService coffeeService)
    {
        _context = context;
        _coffeeService = coffeeService;
    }

    public async Task Handle(DeleteCoffeeCommand request, CancellationToken cancellationToken)
    {
        var coffee = await _context.Coffee
            .FirstOrDefaultAsync(x => x.IsnCoffee == request.IsnCoffee, cancellationToken);

        if (coffee == null)
        {
            throw new InvalidOperationException("Кофе не найден.");
        }

        await _coffeeService.CanDeleteAndThrowAsync(_context, coffee, cancellationToken);

        _context.Coffee.Remove(coffee);
        await _context.SaveChangesAsync(cancellationToken);
    }
}