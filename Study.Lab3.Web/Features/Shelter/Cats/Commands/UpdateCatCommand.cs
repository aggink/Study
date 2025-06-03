using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Shelter.Cats.DtoModels;

namespace Study.Lab3.Web.Features.Shelter.Cats.Commands;

/// <summary>
/// Обновление клиента
/// </summary>
public sealed class UpdateCatCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные клиента
    /// </summary>
    [Required]
    [FromBody]
    public UpdateCatDto Cat { get; init; }
}

public sealed class UpdateCatCommandHandler : IRequestHandler<UpdateCatCommand, Guid>
{
    private readonly DataContext _dataContext;

    public UpdateCatCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(UpdateCatCommand request, CancellationToken cancellationToken)
    {
        var cat = await _dataContext.Cats
            .FirstOrDefaultAsync(c => c.IsnCat == request.Cat.Id, cancellationToken)
            ?? throw new BusinessLogicException($"Кот с идентификатором \"{request.Cat.Id}\" не существует");

        cat.Nickname = request.Cat.Nickname;
        cat.BirthDate = request.Cat.BirthDate;
        cat.Breed = request.Cat.Breed;
        cat.IsVaccinated = request.Cat.IsVaccinated;
        cat.IsSterilized = request.Cat.IsSterilized;
        cat.Color = request.Cat.Color;
        cat.MedicalHistory = request.Cat.MedicalHistory;
        cat.PhotoUrl = request.Cat.PhotoUrl;
        cat.ArrivalDate = request.Cat.ArrivalDate;
        cat.Age = request.Cat.Age;
        cat.Weight = request.Cat.Weight;

        _dataContext.Cats.Update(cat);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return cat.IsnCat;
    }
}