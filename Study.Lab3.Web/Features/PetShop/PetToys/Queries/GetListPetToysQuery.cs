using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.PetShop.PetToys.DtoModels;

namespace Study.Lab3.Web.Features.PetShop.PetToys.Queries;

public sealed class GetListPetToysQuery : IRequest<PetToyDto[]>
{
}

public sealed class GetListPetToysQueryHandler : IRequestHandler<GetListPetToysQuery, PetToyDto[]>
{
    private readonly DataContext _dataContext;

    public GetListPetToysQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PetToyDto[]> Handle(GetListPetToysQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.PetToys
            .AsNoTracking()
            .Select(x => new PetToyDto
            {
                IsnPetToy = x.IsnPetToy,
                Name = x.Name,
                Material = x.Material,
                Size = x.Size,
                TargetSpecies = x.TargetSpecies,
                Color = x.Color,
                Price = x.Price,
                Description = x.Description,
                AgeGroup = x.AgeGroup,
                StockQuantity = x.StockQuantity,
                IsSafe = x.IsSafe
            })
            .OrderBy(x => x.TargetSpecies)
            .ThenBy(x => x.AgeGroup)
            .ThenBy(x => x.Name)
            .ToArrayAsync(cancellationToken);
    }
}
