using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.PetShop.PetToys.DtoModels;

namespace Study.Lab3.Web.Features.PetShop.PetToys.Queries;

public sealed class GetPetToyByIsnQuery : IRequest<PetToyDto>
{
    [Required, FromQuery]
    public Guid IsnPetToy { get; init; }
}

public sealed class GetPetToyByIsnQueryHandler : IRequestHandler<GetPetToyByIsnQuery, PetToyDto>
{
    private readonly DataContext _dataContext;

    public GetPetToyByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PetToyDto> Handle(GetPetToyByIsnQuery request, CancellationToken cancellationToken)
    {
        var petToy = await _dataContext.PetToys
                         .AsNoTracking()
                         .FirstOrDefaultAsync(x => x.IsnPetToy == request.IsnPetToy, cancellationToken)
                     ?? throw new BusinessLogicException($"Игрушка с идентификатором \"{request.IsnPetToy}\" не существует");

        return new PetToyDto
        {
            IsnPetToy = petToy.IsnPetToy,
            Name = petToy.Name,
            Material = petToy.Material,
            Size = petToy.Size,
            TargetSpecies = petToy.TargetSpecies,
            Color = petToy.Color,
            Price = petToy.Price,
            Description = petToy.Description,
            AgeGroup = petToy.AgeGroup,
            StockQuantity = petToy.StockQuantity,
            IsSafe = petToy.IsSafe
        };
    }
}
