using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.PetShop.PetFoods.DtoModels;

namespace Study.Lab3.Web.Features.PetShop.PetFoods.Queries;

/// <summary>
/// Получить корм по идентификатору
/// </summary>
public sealed class GetPetFoodByIsnQuery : IRequest<PetFoodDto>
{
    [Required, FromQuery]
    public Guid IsnPetFood { get; init; }
}

public sealed class GetPetFoodByIsnQueryHandler : IRequestHandler<GetPetFoodByIsnQuery, PetFoodDto>
{
    private readonly DataContext _dataContext;

    public GetPetFoodByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PetFoodDto> Handle(GetPetFoodByIsnQuery request, CancellationToken cancellationToken)
    {
        var petFood = await _dataContext.PetFoods
                          .AsNoTracking()
                          .FirstOrDefaultAsync(x => x.IsnPetFood == request.IsnPetFood, cancellationToken)
                      ?? throw new BusinessLogicException($"Корм с идентификатором \"{request.IsnPetFood}\" не существует");

        return new PetFoodDto
        {
            IsnPetFood = petFood.IsnPetFood,
            Name = petFood.Name,
            Brand = petFood.Brand,
            Type = petFood.Type,
            TargetSpecies = petFood.TargetSpecies,
            WeightInGrams = petFood.WeightInGrams,
            Price = petFood.Price,
            Ingredients = petFood.Ingredients,
            ExpirationDate = petFood.ExpirationDate,
            StockQuantity = petFood.StockQuantity
        };
    }
}