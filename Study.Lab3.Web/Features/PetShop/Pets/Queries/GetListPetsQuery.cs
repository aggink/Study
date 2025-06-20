using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.PetShop.Pets.DtoModels;

namespace Study.Lab3.Web.Features.PetShop.Pets.Queries;

/// <summary>
/// Получение списка всех животных
/// </summary>
public sealed class GetListPetsQuery : IRequest<PetDto[]>
{
}

public sealed class GetListPetsQueryHandler : IRequestHandler<GetListPetsQuery, PetDto[]>
{
    private readonly DataContext _dataContext;

    public GetListPetsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PetDto[]> Handle(GetListPetsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Pets
            .AsNoTracking()
            .Select(x => new PetDto
            {
                IsnPet = x.IsnPet,
                Name = x.Name,
                Species = x.Species,
                Breed = x.Breed,
                AgeInMonths = x.AgeInMonths,
                Price = x.Price,
                Description = x.Description,
                ArrivalDate = x.ArrivalDate,
                Status = x.Status
            })
            .OrderBy(x => x.Species)
            .ThenBy(x => x.Name)
            .ToArrayAsync(cancellationToken);
    }
}