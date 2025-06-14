using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Shelter.MiniPigAdoptions.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Study.Lab3.Web.Features.Shelter.MiniPigAdoptions.Commands;

/// <summary>
/// Обновление усыновления
/// </summary>
public sealed class UpdateMiniPigAdoptionCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные усыновления
    /// </summary>
    [Required]
    [FromBody]
    public UpdateMiniPigAdoptionDto Adoption { get; init; }
}

public sealed class UpdateMiniPigAdoptionCommandHandler : IRequestHandler<UpdateMiniPigAdoptionCommand, Guid>
{
    private readonly DataContext _dataContext;

    public UpdateMiniPigAdoptionCommandHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<Guid> Handle(UpdateMiniPigAdoptionCommand request, CancellationToken cancellationToken)
    {
        var adoption = await _dataContext.Adoptions
            .FirstOrDefaultAsync(a => a.IsnAdoption == request.Adoption.IsnAdoption, cancellationToken)
            ?? throw new BusinessLogicException($"Усыновление с идентификатором \"{request.Adoption.IsnAdoption}\" не существует");

        adoption.Price = request.Adoption.Price;
        adoption.IsnCustomer = request.Adoption.IsnCustomer;
        adoption.IsnMiniPig = request.Adoption.IsnMiniPig;
        adoption.AdoptionDate = request.Adoption.AdoptionDate;
        adoption.Status = request.Adoption.Status;

        _dataContext.Adoptions.Update(adoption);
        await _dataContext.SaveChangesAsync(cancellationToken);

        return adoption.IsnAdoption;
    }
}