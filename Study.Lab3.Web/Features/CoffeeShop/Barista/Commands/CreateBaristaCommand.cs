using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.CoffeeShop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CoffeeShop.Barista.DtoModels;

namespace Study.Lab3.Web.Features.CoffeeShop.Barista.Commands;

/// <summary>
/// Создание бариста
/// </summary>
public sealed class CreateBaristaCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные бариста
    /// </summary>
    [Required]
    [FromBody]
    public CreateBaristaDto Barista { get; init; }
}

public sealed class CreateBaristaCommandHandler : IRequestHandler<CreateBaristaCommand, Guid>
{
    private readonly DataContext _context;
    private readonly IBaristaService _baristaService;

    public CreateBaristaCommandHandler(DataContext context, IBaristaService baristaService)
    {
        _context = context;
        _baristaService = baristaService;
    }

    public async Task<Guid> Handle(CreateBaristaCommand request, CancellationToken cancellationToken)
    {
        var barista = new Storage.Models.CoffeeShop.Barista
        {
            IsnBarista = Guid.NewGuid(),
            FirstName = request.Barista.FirstName,
            LastName = request.Barista.LastName,
            Phone = request.Barista.Phone,
            Email = request.Barista.Email,
            Experience = request.Barista.Experience,
            Specialization = request.Barista.Specialization,
            Salary = request.Barista.Salary,
            HireDate = request.Barista.HireDate,
            IsActive = request.Barista.IsActive
        };

        await _baristaService.CreateOrUpdateBaristaValidateAndThrowAsync(_context, barista, cancellationToken);

        await _context.Baristas.AddAsync(barista, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return barista.IsnBarista;
    }
}