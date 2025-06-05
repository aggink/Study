using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Shelter;
using Study.Lab3.Web.Features.Shelter.Cats.DtoModels;

namespace Study.Lab3.Web.Features.Shelter.Cats.Commands;

/// <summary>
/// Создание кота
/// </summary>
public class CreateCatCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные кота
    /// </summary>
    [Required]
    [FromBody]
    public CreateCatDto Customer { get; init; }
}

public sealed class CreateCatCommandHandler : IRequestHandler<CreateCatCommand, Guid>
{
    private readonly DataContext _dataContext;

    public CreateCatCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(CreateCatCommand request, CancellationToken cancellationToken)
    {
        var cat = new Cat
        {
            IsnCat = Guid.NewGuid(),
            Nickname = request.Customer.Nickname,
            BirthDate = request.Customer.BirthDate,
            Breed = request.Customer.Breed,
            IsVaccinated = request.Customer.IsVaccinated,
            IsSterilized = request.Customer.IsSterilized,
            Color = request.Customer.Color,
            MedicalHistory = request.Customer.MedicalHistory,
            PhotoUrl = request.Customer.PhotoUrl,
            ArrivalDate = request.Customer.ArrivalDate,
            Age = request.Customer.Age,
            Weight = request.Customer.Weight,
            IsAvailableForAdoption = true 
        };

        await _dataContext.Cats.AddAsync(cat, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return cat.IsnCat;
    }
}