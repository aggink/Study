using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Shelter.Adoptions.DtoModels;

namespace Study.Lab3.Web.Features.Shelter.Adoptions.Commands;

/// <summary>
/// Обновление усыновления
/// </summary>
public sealed class UpdateAdoptionCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные усыновления
    /// </summary>
    [Required]
    [FromBody]
    public UpdateAdoptionDto Adoption { get; init; }
}

public sealed class UpdateAdoptionCommandHandler : IRequestHandler<UpdateAdoptionCommand, Guid>
{
    private readonly DataContext _dataContext;

    public UpdateAdoptionCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(UpdateAdoptionCommand request, CancellationToken cancellationToken)
    {
        var adoption = await _dataContext.Adoptions
            .FirstOrDefaultAsync(a => a.IsnAdoption == request.Adoption.IsnAdoption, cancellationToken)
            ?? throw new BusinessLogicException($"Усыновление с идентификатором \"{request.Adoption.IsnAdoption}\" не существует");

        adoption.Price = request.Adoption.Price;
        adoption.CustomerIsn = request.Adoption.IsnCustomer;
        adoption.CatIsn = request.Adoption.IsnCat;
        adoption.AdoptionDate = request.Adoption.AdoptionDate;
        adoption.Status = request.Adoption.Status;

        _dataContext.Adoptions.Update(adoption);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return adoption.IsnAdoption;
    }
}