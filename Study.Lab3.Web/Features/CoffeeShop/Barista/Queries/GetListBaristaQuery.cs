using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CoffeeShop.Barista.DtoModels;

namespace Study.Lab3.Web.Features.CoffeeShop.Barista.Queries;

/// <summary>
/// Получение списка бариста
/// </summary>
public sealed class GetListBaristaQuery : IRequest<BaristaDto[]>
{
}

public sealed class GetListBaristaQueryHandler : IRequestHandler<GetListBaristaQuery, BaristaDto[]>
{
    private readonly DataContext _context;

    public GetListBaristaQueryHandler(DataContext context)
    {
        _context = context;
    }

    public async Task<BaristaDto[]> Handle(GetListBaristaQuery request, CancellationToken cancellationToken)
    {
        var baristas = await _context.Baristas
            .AsNoTracking()
            .Select(barista => new BaristaDto
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
            })
            .ToArrayAsync(cancellationToken);

        return baristas;
    }
}