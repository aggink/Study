using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.PetShop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.PetShop;
using Study.Lab3.Web.Features.PetShop.PetFoods.DtoModels;

namespace Study.Lab3.Web.Features.PetShop.PetFoods.Commands;

/// <summary>
/// Создание корма
/// </summary>
public sealed class CreatePetFoodCommand : IRequest<Guid>
{
    [Required, FromBody]
    public CreatePetFoodDto PetFood { get; init; }
}

public sealed class CreatePetFoodCommandHandler : IRequestHandler<CreatePetFoodCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPetFoodService _petFoodService;

    public CreatePetFoodCommandHandler(DataContext dataContext, IPetFoodService petFoodService)
    {
        _dataContext = dataContext;
        _petFoodService = petFoodService;
    }

    public async Task<Guid> Handle(CreatePetFoodCommand request, CancellationToken cancellationToken)
    {
        var petFood = new PetFood
        {
            IsnPetFood = Guid.NewGuid(),
            Name = request.PetFood.Name,
            Brand = request.PetFood.Brand,
            Type = request.PetFood.Type,
            TargetSpecies = request.PetFood.TargetSpecies,
            WeightInGrams = request.PetFood.WeightInGrams,
            Price = request.PetFood.Price,
            Ingredients = request.PetFood.Ingredients,
            ExpirationDate = request.PetFood.ExpirationDate,
            StockQuantity = request.PetFood.StockQuantity
        };

        await _petFoodService.CreateOrUpdatePetFoodValidateAndThrowAsync(_dataContext, petFood, cancellationToken);
        await _dataContext.PetFoods.AddAsync(petFood, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
        return petFood.IsnPetFood;
    }
}