using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.TravelAgency.Customers.DtoModels;

namespace Study.Lab3.Web.Features.TravelAgency.Customers.Queries;

/// <summary>
/// Получение списка клиентов
/// </summary>
public sealed class GetListTravelCustomersQuery : IRequest<TravelCustomerDto[]>
{
    /// <summary>
    /// Фильтр по фамилии (опционально)
    /// </summary>
    [FromQuery]
    public string SurName { get; init; }

    /// <summary>
    /// Фильтр по имени (опционально)
    /// </summary>
    [FromQuery]
    public string Name { get; init; }

    /// <summary>
    /// Фильтр по email (опционально)
    /// </summary>
    [FromQuery]
    public string Email { get; init; }

    /// <summary>
    /// Фильтр по телефону (опционально)
    /// </summary>
    [FromQuery]
    public string Phone { get; init; }

    /// <summary>
    /// Показывать только VIP клиентов
    /// </summary>
    [FromQuery]
    public bool? OnlyVip { get; init; }

    /// <summary>
    /// Минимальный возраст
    /// </summary>
    [FromQuery]
    public int? MinAge { get; init; }

    /// <summary>
    /// Максимальный возраст
    /// </summary>
    [FromQuery]
    public int? MaxAge { get; init; }
}

public sealed class GetListCustomersQueryHandler : IRequestHandler<GetListTravelCustomersQuery, TravelCustomerDto[]>
{
    private readonly DataContext _dataContext;

    public GetListCustomersQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<TravelCustomerDto[]> Handle(GetListTravelCustomersQuery request, CancellationToken cancellationToken)
    {
        var query = _dataContext.TravelCustomers.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.SurName))
            query = query.Where(x => x.SurName.Contains(request.SurName));

        if (!string.IsNullOrWhiteSpace(request.Name))
            query = query.Where(x => x.Name.Contains(request.Name));

        if (!string.IsNullOrWhiteSpace(request.Email))
            query = query.Where(x => x.Email.Contains(request.Email));

        if (!string.IsNullOrWhiteSpace(request.Phone))
            query = query.Where(x => x.Phone.Contains(request.Phone));

        if (request.OnlyVip == true)
            query = query.Where(x => x.IsVip);

        if (request.MinAge.HasValue)
        {
            var maxBirthDate = DateTime.Today.AddYears(-request.MinAge.Value);
            query = query.Where(x => x.DateOfBirth <= maxBirthDate);
        }

        if (request.MaxAge.HasValue)
        {
            var minBirthDate = DateTime.Today.AddYears(-request.MaxAge.Value - 1);
            query = query.Where(x => x.DateOfBirth > minBirthDate);
        }

        return await query
            .Select(x => new TravelCustomerDto
            {
                IsnCustomer = x.IsnCustomer,
                SurName = x.SurName,
                Name = x.Name,
                PatronymicName = x.PatronymicName,
                DateOfBirth = x.DateOfBirth,
                PassportNumber = x.PassportNumber,
                Phone = x.Phone,
                Email = x.Email,
                Address = x.Address,
                RegistrationDate = x.RegistrationDate,
                IsVip = x.IsVip
            })
            .OrderBy(x => x.SurName)
            .ThenBy(x => x.Name)
            .ThenBy(x => x.PatronymicName)
            .ToArrayAsync(cancellationToken);
    }
}