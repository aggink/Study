using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.PetShop;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.PetShop.PetToys.DtoModels;

namespace Study.Lab3.Web.Features.PetShop.PetToys.Commands;

public sealed class UpdatePetToyCommand : IRequest<Guid>
{
    [Required, FromBody]
    public UpdatePetToyDto PetToy { get; init; }
}

public sealed class UpdatePetToyCommandHandler : IRequestHandler<UpdatePetToyCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IPetToyService _petToyService;

    public UpdatePetToyCommandHandler(DataContext dataContext, IPetToyService petToyService)
    {
        _dataContext = dataContext;
        _petToyService = petToyService;
    }

    public async Task<Guid> Handle(UpdatePetToyCommand request, CancellationToken cancellationToken)
    {
        var petToy = await _dataContext.PetToys
                         .FirstOrDefaultAsync(x => x.IsnPetToy == request.PetToy.IsnPetToy, cancellationToken)
                     ?? throw new BusinessLogicException($"Игрушка с идентификатором \"{request.PetToy.IsnPetToy}\" не существует");

        petToy.Name = request.PetToy.Name;
        petToy.Color = request.PetToy.Color;
        petToy.Price = request.PetToy.Price;
        petToy.Description = request.PetToy.Description;
        petToy.StockQuantity = request.PetToy.StockQuantity;
        petToy.IsSafe = request.PetToy.IsSafe;

        await _petToyService.CreateOrUpdatePetToyValidateAndThrowAsync(_dataContext, petToy, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
        return petToy.IsnPetToy;
    }
}
