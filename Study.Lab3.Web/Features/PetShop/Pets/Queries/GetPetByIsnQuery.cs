using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.PetShop.Pets.DtoModels;

namespace Study.Lab3.Web.Features.PetShop.Pets.Queries;

/// <summary>
/// Получить животное по идентификатору
/// </summary>
public sealed class GetPetByIsnQuery : IRequest<PetDto>
{
    /// <summary>
    /// Идентификатор животного
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnPet { get; init; }
}

public sealed class GetPetByIsnQueryHandler : IRequestHandler<GetPetByIsnQuery, PetDto>
{
    private readonly DataContext _dataContext;

    public GetPetByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PetDto> Handle(GetPetByIsnQuery request, CancellationToken cancellationToken)
    {
        var pet = await _dataContext.Pets
                      .AsNoTracking()
                      .FirstOrDefaultAsync(x => x.IsnPet == request.IsnPet, cancellationToken)
                  ?? throw new BusinessLogicException(
                      $"Животное с идентификатором \"{request.IsnPet}\" не существует");

        return new PetDto
        {
            IsnPet = pet.IsnPet,
            Name = pet.Name,
            Species = pet.Species,
            Breed = pet.Breed,
            AgeInMonths = pet.AgeInMonths,
            Price = pet.Price,
            Description = pet.Description,
            ArrivalDate = pet.ArrivalDate,
            Status = pet.Status
        };
    }
}