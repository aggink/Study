using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Shelter.Cats.DtoModels;

namespace Study.Lab3.Web.Features.Shelter.Cats.Queries;

/// <summary>
/// Получение списка котов
/// </summary>
public sealed class GetListCatsQuery : IRequest<CatDto[]>
{
}

public sealed class GetListCatsQueryHandler : IRequestHandler<GetListCatsQuery, CatDto[]>
{
    private readonly DataContext _dataContext;

    public GetListCatsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<CatDto[]> Handle(GetListCatsQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Cats
            .AsNoTracking()
            .OrderBy(c => c.Nickname)
            .Select(c => new CatDto
            {
                IsnCat = c.IsnCat,
                Nickname = c.Nickname,
                BirthDate = c.BirthDate,
                Description = c.Description,
                Breed = c.Breed,
                IsVaccinated = c.IsVaccinated,
                IsSterilized = c.IsSterilized,
                Color = c.Color,
                MedicalHistory = c.MedicalHistory,
                PhotoUrl = c.PhotoUrl,
                ArrivalDate = c.ArrivalDate,
                IsAvailableForAdoption = c.IsAvailableForAdoption,
                Age = c.Age,
                Weight = c.Weight
            })
            .ToArrayAsync(cancellationToken);
    }
}