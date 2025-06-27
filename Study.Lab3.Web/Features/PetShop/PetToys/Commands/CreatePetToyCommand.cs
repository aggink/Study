using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.PetShop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.PetShop;
using Study.Lab3.Web.Features.PetShop.PetToys.DtoModels;

namespace Study.Lab3.Web.Features.PetShop.PetToys.Commands;

public sealed class CreatePetToyCommand : IRequest<Guid>
{
    [Required, FromBody]
    public CreatePetToyDto PetToy { get; init; }
}

public sealed class CreatePetToyCommandHandler : IRequestHandler<CreatePetToyCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPetToyService _petToyService;

    public CreatePetToyCommandHandler(DataContext dataContext, IPetToyService petToyService)
    {
        _dataContext = dataContext;
        _petToyService = petToyService;
    }

    public async Task<Guid> Handle(CreatePetToyCommand request, CancellationToken cancellationToken)
    {
        var petToy = new PetToy
        {
            IsnPetToy = Guid.NewGuid(),
            Name = request.PetToy.Name,
            Material = request.PetToy.Material,
            Size = request.PetToy.Size,
            TargetSpecies = request.PetToy.TargetSpecies,
            Color = request.PetToy.Color,
            Price = request.PetToy.Price,
            Description = request.PetToy.Description,
            AgeGroup = request.PetToy.AgeGroup,
            StockQuantity = request.PetToy.StockQuantity,
            IsSafe = request.PetToy.IsSafe
        };

        await _petToyService.CreateOrUpdatePetToyValidateAndThrowAsync(_dataContext, petToy, cancellationToken);
        await _dataContext.PetToys.AddAsync(petToy, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
        return petToy.IsnPetToy;
    }
}
