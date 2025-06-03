using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Restaurants.Restaurants.DtoModels;

namespace Study.Lab3.Web.Features.Restaurants.Restaurants.Queries;

/// <summary>
/// Получение списка ресторанов
/// </summary>
public sealed class GetListRestaurantsQuery : IRequest<RestaurantDto[]>
{
}

public sealed class GetListRestaurantsQueryHandler : IRequestHandler<GetListRestaurantsQuery, RestaurantDto[]>
{
    private readonly DataContext _dataContext;

    public GetListRestaurantsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<RestaurantDto[]> Handle(GetListRestaurantsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Restaurants
            .AsNoTracking()
            .Select(x => new RestaurantDto
            {
                IsnRestaurant = x.IsnRestaurant,
                Name = x.Name,
                Address = x.Address,
                Phone = x.Phone,
                Email = x.Email,
                WorkingHours = x.WorkingHours,
                CreatedDate = x.CreatedDate
            })
            .OrderBy(x => x.Name)
            .ToArrayAsync(cancellationToken);
    }
}
