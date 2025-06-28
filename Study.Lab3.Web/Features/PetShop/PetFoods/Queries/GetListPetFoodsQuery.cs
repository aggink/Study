using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.PetShop.PetFoods.DtoModels;

namespace Study.Lab3.Web.Features.PetShop.PetFoods.Queries;

/// <summary>
/// Получение списка всех кормов
/// </summary>
public sealed class GetListPetFoodsQuery : IRequest<PetFoodDto[]>
{
}

public sealed class GetListPetFoodsQueryHandler : IRequestHandler<GetListPetFoodsQuery, PetFoodDto[]>
{
    private readonly DataContext _dataContext;

    public GetListPetFoodsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PetFoodDto[]> Handle(GetListPetFoodsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.PetFoods
            .AsNoTracking()
            .Select(x => new PetFoodDto
            {
                IsnPetFood = x.IsnPetFood,
                Name = x.Name,
                Brand = x.Brand,
                Type = x.Type,
                TargetSpecies = x.TargetSpecies,
                WeightInGrams = x.WeightInGrams,
                Price = x.Price,
                Ingredients = x.Ingredients,
                ExpirationDate = x.ExpirationDate,
                StockQuantity = x.StockQuantity
            })
            .OrderBy(x => x.TargetSpecies)
            .ThenBy(x => x.Brand)
            .ThenBy(x => x.Name)
            .ToArrayAsync(cancellationToken);
    }
}