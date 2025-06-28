using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.PetShop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.PetShop.Pets.DtoModels;

namespace Study.Lab3.Web.Features.PetShop.Pets.Commands;

/// <summary>
/// Обновление животного
/// </summary>
public sealed class UpdatePetCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные животного
    /// </summary>
    [Required]
    [FromBody]
    public UpdatePetDto Pet { get; init; }
}

public sealed class UpdatePetCommandHandler : IRequestHandler<UpdatePetCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPetService _petService;

    public UpdatePetCommandHandler(
        DataContext dataContext,
        IPetService petService)
    {
        _dataContext = dataContext;
        _petService = petService;
    }

    public async Task<Guid> Handle(UpdatePetCommand request, CancellationToken cancellationToken)
    {
        var pet = await _dataContext.Pets
                      .FirstOrDefaultAsync(x => x.IsnPet == request.Pet.IsnPet, cancellationToken)
                  ?? throw new BusinessLogicException(
                      $"Животное с идентификатором \"{request.Pet.IsnPet}\" не существует");

        pet.Name = request.Pet.Name;
        pet.Breed = request.Pet.Breed;
        pet.AgeInMonths = request.Pet.AgeInMonths;
        pet.Price = request.Pet.Price;
        pet.Description = request.Pet.Description;
        pet.Status = request.Pet.Status;

        await _petService.CreateOrUpdatePetValidateAndThrowAsync(
            _dataContext, pet, cancellationToken);

        await _dataContext.SaveChangesAsync(cancellationToken);
        return pet.IsnPet;
    }
}