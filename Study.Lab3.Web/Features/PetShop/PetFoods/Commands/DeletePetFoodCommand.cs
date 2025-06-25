using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.PetShop;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.PetShop.PetFoods.Commands;

/// <summary>
/// Удаление корма
/// </summary>
public sealed class DeletePetFoodCommand : IRequest
{
    [Required, FromQuery]
    public Guid IsnPetFood { get; init; }
}

public sealed class DeletePetFoodCommandHandler : IRequestHandler<DeletePetFoodCommand>
{
    private readonly DataContext _dataContext;
    private readonly IPetFoodService _petFoodService;

    public DeletePetFoodCommandHandler(DataContext dataContext, IPetFoodService petFoodService)
    {
        _dataContext = dataContext;
        _petFoodService = petFoodService;
    }

    public async Task Handle(DeletePetFoodCommand request, CancellationToken cancellationToken)
    {
        var petFood = await _dataContext.PetFoods
                          .FirstOrDefaultAsync(x => x.IsnPetFood == request.IsnPetFood, cancellationToken)
                      ?? throw new BusinessLogicException($"Корм с идентификатором \"{request.IsnPetFood}\" не существует");

        await _petFoodService.CanDeleteAndThrowAsync(_dataContext, petFood, cancellationToken);
        _dataContext.PetFoods.Remove(petFood);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}