using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CoffeeShop;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.CoffeeShop.Barista.Commands;

/// <summary>
/// Удаление бариста
/// </summary>
public sealed class DeleteBaristaCommand : IRequest
{
    /// <summary>
    /// Идентификатор бариста
    /// </summary>
    [Required]
    [FromBody]
    public Guid IsnBarista { get; init; }
}

public sealed class DeleteBaristaCommandHandler : IRequestHandler<DeleteBaristaCommand>
{
    private readonly DataContext _context;
    private readonly IBaristaService _baristaService;

    public DeleteBaristaCommandHandler(DataContext context, IBaristaService baristaService)
    {
        _context = context;
        _baristaService = baristaService;
    }

    public async Task Handle(DeleteBaristaCommand request, CancellationToken cancellationToken)
    {
        var barista = await _context.Baristas
            .FirstOrDefaultAsync(x => x.IsnBarista == request.IsnBarista, cancellationToken);

        if (barista == null)
        {
            throw new InvalidOperationException("Бариста не найден.");
        }

        await _baristaService.CanDeleteAndThrowAsync(_context, barista, cancellationToken);

        _context.Baristas.Remove(barista);
        await _context.SaveChangesAsync(cancellationToken);
    }
}