using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.PetShop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.PetShop.PetFoods.DtoModels;

namespace Study.Lab3.Web.Features.PetShop.PetFoods.Commands;

/// <summary>
/// Обновление корма
/// </summary>
public sealed class UpdatePetFoodCommand : IRequest<Guid>
{
    [Required, FromBody]
    public UpdatePetFoodDto PetFood { get; init; }
}

public sealed class UpdatePetFoodCommandHandler : IRequestHandler<UpdatePetFoodCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPetFoodService _petFoodService;

    public UpdatePetFoodCommandHandler(DataContext dataContext, IPetFoodService petFoodService)
    {
        _dataContext = dataContext;
        _petFoodService = petFoodService;
    }

    public async Task<Guid> Handle(UpdatePetFoodCommand request, CancellationToken cancellationToken)
    {
        var petFood = await _dataContext.PetFoods
                          .FirstOrDefaultAsync(x => x.IsnPetFood == request.PetFood.IsnPetFood, cancellationToken)
                      ?? throw new BusinessLogicException($"Корм с идентификатором \"{request.PetFood.IsnPetFood}\" не существует");

        petFood.Name = request.PetFood.Name;
        petFood.Price = request.PetFood.Price;
        petFood.Ingredients = request.PetFood.Ingredients;
        petFood.ExpirationDate = request.PetFood.ExpirationDate;
        petFood.StockQuantity = request.PetFood.StockQuantity;

        await _petFoodService.CreateOrUpdatePetFoodValidateAndThrowAsync(_dataContext, petFood, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
        return petFood.IsnPetFood;
    }
}