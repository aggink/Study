using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.PetShop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.PetShop;
using Study.Lab3.Web.Features.PetShop.Pets.DtoModels;

namespace Study.Lab3.Web.Features.PetShop.Pets.Commands;

/// <summary>
/// Создание животного
/// </summary>
public sealed class CreatePetCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные животного
    /// </summary>
    [Required]
    [FromBody]
    public CreatePetDto Pet { get; init; }
}

public sealed class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPetService _petService;

    public CreatePetCommandHandler(
        DataContext dataContext,
        IPetService petService)
    {
        _dataContext = dataContext;
        _petService = petService;
    }

    public async Task<Guid> Handle(CreatePetCommand request, CancellationToken cancellationToken)
    {
        var pet = new Pet
        {
            IsnPet = Guid.NewGuid(),
            Name = request.Pet.Name,
            Species = request.Pet.Species,
            Breed = request.Pet.Breed,
            AgeInMonths = request.Pet.AgeInMonths,
            Price = request.Pet.Price,
            Description = request.Pet.Description,
            ArrivalDate = request.Pet.ArrivalDate,
            Status = request.Pet.Status
        };

        await _petService.CreateOrUpdatePetValidateAndThrowAsync(
            _dataContext, pet, cancellationToken);

        await _dataContext.Pets.AddAsync(pet, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return pet.IsnPet;
    }
}