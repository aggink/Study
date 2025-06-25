using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.PetShop;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.PetShop.PetToys.Commands;

public sealed class DeletePetToyCommand : IRequest
{
    [Required, FromQuery]
    public Guid IsnPetToy { get; init; }
}

public sealed class DeletePetToyCommandHandler : IRequestHandler<DeletePetToyCommand>
{
    private readonly DataContext _dataContext;
    private readonly IPetToyService _petToyService;

    public DeletePetToyCommandHandler(DataContext dataContext, IPetToyService petToyService)
    {
        _dataContext = dataContext;
        _petToyService = petToyService;
    }

    public async Task Handle(DeletePetToyCommand request, CancellationToken cancellationToken)
    {
        var petToy = await _dataContext.PetToys
                         .FirstOrDefaultAsync(x => x.IsnPetToy == request.IsnPetToy, cancellationToken)
                     ?? throw new BusinessLogicException($"Игрушка с идентификатором \"{request.IsnPetToy}\" не существует");

        await _petToyService.CanDeleteAndThrowAsync(_dataContext, petToy, cancellationToken);
        _dataContext.PetToys.Remove(petToy);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}
