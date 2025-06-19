using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CarService;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CarService.Owners.DtoModels;

namespace Study.Lab3.Web.Features.CarService.Owners.Commands;

public sealed class UpdateOwnerCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные владельца
    /// </summary>
    [Required]
    [FromBody]
    public UpdateOwnerDto Owner { get; init; }
}
 
public sealed class UpdateOwnerCommandHandler : IRequestHandler<UpdateOwnerCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IOwnerService _ownerService;
 
    public UpdateOwnerCommandHandler(
        DataContext dataContext,
        IOwnerService ownerService)
    {
        _dataContext = dataContext;
        _ownerService = ownerService;
    }
 
    public async Task<Guid> Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
    {
        var owner = await _dataContext.Owners
                        .FirstOrDefaultAsync(x => x.IsnOwner == request.Owner.IsnOwner, cancellationToken)
                    ?? throw new BusinessLogicException($"Владелец с идентификатором \"{request.Owner.IsnOwner}\" не существует");
 
        owner.FirstName = request.Owner.FirstName;
        owner.SecondName = request.Owner.SecondName;
        owner.PhoneNumber = request.Owner.PhoneNumber;
        owner.Email = request.Owner.Email;
        owner.Address = request.Owner.Address;
 
        await _ownerService.CreateOrUpdateOwnerValidateAndThrowAsync(
            _dataContext, owner, cancellationToken);
 
        await _dataContext.SaveChangesAsync(cancellationToken);
        return owner.IsnOwner;
    }
}