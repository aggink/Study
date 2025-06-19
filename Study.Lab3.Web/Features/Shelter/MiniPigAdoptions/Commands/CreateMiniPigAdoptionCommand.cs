using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.Shelter;
using Study.Lab3.Web.Features.Shelter.MiniPigAdoptions.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Shelter.MiniPigAdoptions.Commands;

/// <summary>
/// Создание кота
/// </summary>
public class CreateMiniPigAdoptionCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные кота
    /// </summary>
    [Required]
    [FromBody]
    public CreateMiniPigAdoptionDto Adoption { get; init; }
}

public sealed class CreateMiniPigAdoptionCommandHandler : IRequestHandler<CreateMiniPigAdoptionCommand, Guid>
{
    private readonly DataContext _dataContext;

    public CreateMiniPigAdoptionCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(CreateMiniPigAdoptionCommand request, CancellationToken cancellationToken)
    {
        var adoption = new Adoption
        {
            IsnAdoption = Guid.NewGuid(),
            Price = request.Adoption.Price,
            IsnCustomer = request.Adoption.IsnCustomer,
            IsnMiniPig = request.Adoption.IsnMiniPig,
            AdoptionDate = request.Adoption.AdoptionDate,
            Status = "Pending" // Default status
        };

        await _dataContext.Adoptions.AddAsync(adoption, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return adoption.IsnAdoption;
    }
}