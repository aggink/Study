using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.PetShop;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.PetShop.Pets.Commands;

/// <summary>
/// Удаление животного
/// </summary>
public sealed class DeletePetCommand : IRequest
{
    /// <summary>
    /// Идентификатор животного
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnPet { get; init; }
}

public sealed class DeletePetCommandHandler : IRequestHandler<DeletePetCommand>
{
    private readonly DataContext _dataContext;
    private readonly IPetService _petService;

    public DeletePetCommandHandler(
        DataContext dataContext,
        IPetService petService)
    {
        _dataContext = dataContext;
        _petService = petService;
    }

    public async Task Handle(DeletePetCommand request, CancellationToken cancellationToken)
    {
        var pet = await _dataContext.Pets
                      .FirstOrDefaultAsync(x => x.IsnPet == request.IsnPet, cancellationToken)
                  ?? throw new BusinessLogicException(
                      $"Животное с идентификатором \"{request.IsnPet}\" не существует");

        await _petService.CanDeleteAndThrowAsync(
            _dataContext, pet, cancellationToken);

        _dataContext.Pets.Remove(pet);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}