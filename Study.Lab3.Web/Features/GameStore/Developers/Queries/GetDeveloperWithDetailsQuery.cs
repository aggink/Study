using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.GameStore.Developers.DtoModels;
using Study.Lab3.Web.Features.GameStore.Games.DtoModels;

namespace Study.Lab3.Web.Features.GameStore.Developers.Queries;

/// <summary>
/// Получение разработчика с количеством игр
/// </summary>
public sealed class GetDeveloperWithDetailsQuery : IRequest<DeveloperWithDetailsDto>
{
    /// <summary>
    /// Идентификатор разработчика
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnDeveloper { get; init; }
}

public sealed class
    GetDeveloperWithDetailsQueryHandler : IRequestHandler<GetDeveloperWithDetailsQuery, DeveloperWithDetailsDto>
{
    private readonly DataContext _dataContext;

    public GetDeveloperWithDetailsQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<DeveloperWithDetailsDto> Handle(GetDeveloperWithDetailsQuery request,
        CancellationToken cancellationToken)
    {
        return await _dataContext.Developers
                   .AsNoTracking()
                   .Where(x => x.IsnDeveloper == request.IsnDeveloper)
                   .Select(x => new DeveloperWithDetailsDto
                   {
                       IsnDeveloper = x.IsnDeveloper,
                       CompanyName = x.CompanyName,
                       Country = x.Country,
                       FoundedDate = x.FoundedDate,
                       Website = x.Website,
                       ContactEmail = x.ContactEmail,
                       IsActive = x.IsActive,
                       Description = x.Description,
                       GamesCount = x.Games.Count,
                       Games = x.Games.Select(g => new GameDto
                       {
                           IsnGame = g.IsnGame,
                           Title = g.Title,
                           Description = g.Description,
                           Price = g.Price,
                           ReleaseDate = g.ReleaseDate,
                           Genre = g.Genre,
                           AgeRating = g.AgeRating,
                           IsActive = g.IsActive
                       }).ToArray()
                   })
                   .FirstOrDefaultAsync(cancellationToken)
               ?? throw new BusinessLogicException(
                   $"Разработчик с идентификатором \"{request.IsnDeveloper}\" не существует");
    }
}