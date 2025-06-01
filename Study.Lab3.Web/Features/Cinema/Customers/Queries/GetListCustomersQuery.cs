using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Cinema.Customers.DtoModels;

namespace Study.Lab3.Web.Features.Cinema.Customers.Queries;

/// <summary>
/// Получение списка клиентов
/// </summary>
public sealed class GetListCustomersQuery : IRequest<CustomerDto[]>
{
}

public sealed class GetListCustomersQueryHandler : IRequestHandler<GetListCustomersQuery, CustomerDto[]>
{
    private readonly DataContext _dataContext;

    public GetListCustomersQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<CustomerDto[]> Handle(GetListCustomersQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Customers
            .AsNoTracking()
            .OrderBy(c => c.LastName)
            .ThenBy(c => c.FirstName)
            .Select(c => new CustomerDto
            {
                IsnCustomer = c.IsnCustomer,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Phone = c.Phone,
                BirthDate = c.BirthDate,
                RegistrationDate = c.RegistrationDate,
                IsActive = c.IsActive
            })
            .ToArrayAsync(cancellationToken);
    }
}