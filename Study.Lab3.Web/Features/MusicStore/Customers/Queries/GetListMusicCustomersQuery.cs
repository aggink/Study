using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.MusicStore.Customers.DtoModels;

namespace Study.Lab3.Web.Features.MusicStore.Customers.Queries;

/// <summary>
/// Получение списка покупателей
/// </summary>
public sealed class GetListMusicCustomersQuery : IRequest<MusicCustomerDto[]>
{
}

public sealed class GetListMusicCustomersQueryHandler : IRequestHandler<GetListMusicCustomersQuery, MusicCustomerDto[]>
{
    private readonly DataContext _dataContext;

    public GetListMusicCustomersQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<MusicCustomerDto[]> Handle(GetListMusicCustomersQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.MusicCustomers
            .AsNoTracking()
            .Select(x => new MusicCustomerDto
            {
                IsnCustomer = x.IsnCustomer,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Phone = x.Phone,
                BirthDate = x.BirthDate,
                PreferredGenre = x.PreferredGenre,
                Status = x.Status,
                RegistrationDate = x.RegistrationDate
            })
            .OrderBy(x => x.LastName)
            .ThenBy(x => x.FirstName)
            .ToArrayAsync(cancellationToken);
    }
}