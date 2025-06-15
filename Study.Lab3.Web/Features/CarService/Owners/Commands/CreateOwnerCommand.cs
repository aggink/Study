using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Study.Lab3.Logic.Interfaces.Services.CarService;
using Study.Lab3.Storage.Database;
using Study.Lab3.Storage.Models.CarService;
using Study.Lab3.Web.Features.CarService.Owners.DtoModels;

namespace Study.Lab3.Web.Features.CarService.Owners.Commands;

public sealed class CreateOwnerCommand : IRequest<Guid>
{
    /// <summary>
    /// Данные владельца
    /// </summary>
    [Required]
    [FromBody]
    public CreateOwnerDto Owner { get; init; }
}
 
public sealed class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, Guid>
{
    private readonly DataContext _dataContext;
    private readonly IOwnerService _ownerService;
 
    public CreateOwnerCommandHandler(
        DataContext dataContext,
        IOwnerService ownerService)
    {
        _dataContext = dataContext;
        _ownerService = ownerService;
    }
 
    public async Task<Guid> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
    {
        var owner = new Owner
        {
            IsnOwner = Guid.NewGuid(),
            FirstName = request.Owner.FirstName,
            SecondName = request.Owner.SecondName,
            PhoneNumber = request.Owner.PhoneNumber,
            Email = request.Owner.Email,
            Address = request.Owner.Address
        };
 
        await _ownerService.CreateOrUpdateOwnerValidateAndThrowAsync(
            _dataContext, owner, cancellationToken);
 
        await _dataContext.Owners.AddAsync(owner, cancellationToken);
        await _dataContext.SaveChangesAsync(cancellationToken);
 
        return owner.IsnOwner;
    }
}