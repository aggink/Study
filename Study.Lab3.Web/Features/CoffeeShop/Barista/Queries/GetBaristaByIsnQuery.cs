using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CoffeeShop.Barista.DtoModels;

namespace Study.Lab3.Web.Features.CoffeeShop.Barista.Queries;

/// <summary>
/// Получение бариста по идентификатору
/// </summary>
public sealed class GetBaristaByIsnQuery : IRequest<BaristaDto>
{
    /// <summary>
    /// Идентификатор бариста
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnBarista { get; init; }
}

public sealed class GetBaristaByIsnQueryHandler : IRequestHandler<GetBaristaByIsnQuery, BaristaDto>
{
    private readonly DataContext _context;

    public GetBaristaByIsnQueryHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<BaristaDto> Handle(GetBaristaByIsnQuery request, CancellationToken cancellationToken)
    {
        var barista = await _context.Baristas
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.IsnBarista == request.IsnBarista, cancellationToken);

        if (barista == null)
        {
            throw new InvalidOperationException("Бариста не найден.");
        }

        return new BaristaDto
        {
            IsnBarista = barista.IsnBarista,
            FirstName = barista.FirstName,
            LastName = barista.LastName,
            Phone = barista.Phone,
            Email = barista.Email,
            Experience = barista.Experience,
            Specialization = barista.Specialization,
            Salary = barista.Salary,
            HireDate = barista.HireDate,
            IsActive = barista.IsActive
        };
    }
}