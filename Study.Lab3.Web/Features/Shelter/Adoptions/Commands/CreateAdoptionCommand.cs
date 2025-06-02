using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Shelter;
using Study.Lab3.Web.Features.Shelter.Adoptions.DtoModels;
using Study.Lab3.Web.Features.Shelter.Cats.DtoModels;

namespace Study.Lab3.Web.Features.Shelter.Adoptions.Commands;


/// <summary>
/// Создание кота
/// </summary>
public class CreateAdoptionCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные кота
    /// </summary>
    [Required]
    [FromBody]
    public CreateAdoptionDto Adoption { get; init; }
}

public sealed class CreateAdoptionCommandHandler : IRequestHandler<CreateAdoptionCommand, Guid>
{
    private readonly DataContext _dataContext;

    public CreateAdoptionCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(CreateAdoptionCommand request, CancellationToken cancellationToken)
    {
        var adoption = new Adoption
        {
            Id = Guid.NewGuid(),
            Price = request.Adoption.Price,
            CustomerId = request.Adoption.CustomerId,
            CatId = request.Adoption.CatId,
            AdoptionDate = request.Adoption.AdoptionDate,
            Status = "Pending" // Default status
        };

        await _dataContext.Adoptions.AddAsync(adoption, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return adoption.Id;
    }
}