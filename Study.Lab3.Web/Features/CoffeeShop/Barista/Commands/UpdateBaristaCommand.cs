using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CoffeeShop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CoffeeShop.Barista.DtoModels;

namespace Study.Lab3.Web.Features.CoffeeShop.Barista.Commands;

/// <summary>
/// Обновление бариста
/// </summary>
public sealed class UpdateBaristaCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные бариста
    /// </summary>
    [Required]
    [FromBody]
    public UpdateBaristaDto Barista { get; init; }
}

public sealed class UpdateBaristaCommandHandler : IRequestHandler<UpdateBaristaCommand, Guid>
{
    private readonly DataContext _context;
    private readonly IBaristaService _baristaService;

    public UpdateBaristaCommandHandler(DataContext context, IBaristaService baristaService)
    {
        _context = context;
        _baristaService = baristaService;
    }

    public async Task<Guid> Handle(UpdateBaristaCommand request, CancellationToken cancellationToken)
    {
        var barista = await _context.Baristas
            .FirstOrDefaultAsync(x => x.IsnBarista == request.Barista.IsnBarista, cancellationToken);

        if (barista == null)
        {
            throw new InvalidOperationException("Бариста не найден.");
        }

        barista.FirstName = request.Barista.FirstName;
        barista.LastName = request.Barista.LastName;
        barista.Phone = request.Barista.Phone;
        barista.Email = request.Barista.Email;
        barista.Experience = request.Barista.Experience;
        barista.Specialization = request.Barista.Specialization;
        barista.Salary = request.Barista.Salary;
        barista.HireDate = request.Barista.HireDate;
        barista.IsActive = request.Barista.IsActive;

        await _baristaService.CreateOrUpdateBaristaValidateAndThrowAsync(_context, barista, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return barista.IsnBarista;
    }
}