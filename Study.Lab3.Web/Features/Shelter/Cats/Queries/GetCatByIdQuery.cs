using System;
using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Shelter.Cats.DtoModels;

namespace Study.Lab3.Web.Features.Shelter.Cats.Queries;

/// <summary>
/// Получение кота по идентификатору
/// </summary>
public sealed class GetCatByIdQuery : IRequest<CatDto>
{
    /// <summary>
    /// Идентификатор кота
    /// </summary>
    [Required]
    [FromQuery]
    public Guid CatId { get; init; }
}

public sealed class GetCatByIdQueryHandler : IRequestHandler<GetCatByIdQuery, CatDto>
{
    private readonly DataContext _dataContext;

    public GetCatByIdQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<CatDto> Handle(GetCatByIdQuery request, CancellationToken cancellationToken)
    {
        var cat = await _dataContext.Cats
                      .AsNoTracking()
                      .FirstOrDefaultAsync(c => c.IsnCat == request.CatId, cancellationToken)
                  ?? throw new BusinessLogicException(
                      $"Кот с идентификатором \"{request.CatId}\" не существует");

        return new CatDto
        {
            Id = cat.IsnCat,
            Nickname = cat.Nickname,
            BirthDate = cat.BirthDate,
            Description = cat.Description,
            Breed = cat.Breed,
            IsVaccinated = cat.IsVaccinated,
            IsSterilized = cat.IsSterilized,
            Color = cat.Color,
            MedicalHistory = cat.MedicalHistory,
            PhotoUrl = cat.PhotoUrl,
            ArrivalDate = cat.ArrivalDate,
            IsAvailableForAdoption = cat.IsAvailableForAdoption,
            Age = cat.Age,
            Weight = cat.Weight
        };
    }
}