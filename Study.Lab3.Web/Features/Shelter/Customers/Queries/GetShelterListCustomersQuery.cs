using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Shelter.Customers.DtoModels;

namespace Study.Lab3.Web.Features.Shelter.Customers.Queries;

/// <summary>
/// Получение списка клиентов
/// </summary>
public sealed class GetShelterListCustomersQuery : IRequest<ShelterCustomerDto[]>
{
}

public sealed class GetListCustomersQueryHandler : IRequestHandler<GetShelterListCustomersQuery, ShelterCustomerDto[]>
{
    private readonly DataContext _dataContext;

    public GetListCustomersQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<ShelterCustomerDto[]> Handle(GetShelterListCustomersQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.ShelterCustomers
            .AsNoTracking()
            .OrderBy(c => c.LastName)
            .ThenBy(c => c.Name)
            .Select(c => new ShelterCustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                LastName = c.LastName,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                Address = c.Address,
                Description = c.Description,
            })
            .ToArrayAsync(cancellationToken);
    }
}