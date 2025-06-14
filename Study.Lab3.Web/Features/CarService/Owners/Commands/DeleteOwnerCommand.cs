using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Logic.Interfaces.Services.CarService;
using Study.Lab3.Storage.Database;

namespace Study.Lab3.Web.Features.CarService.Owners.Commands;

public sealed class DeleteOwnerCommand : IRequest
{
    /// <summary>
    /// Идентификатор владельца
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnOwner { get; init; }
}
 
public sealed class DeleteOwnerCommandHandler : IRequestHandler<DeleteOwnerCommand>
{
    private readonly DataContext _dataContext;
    private readonly IOwnerService _ownerService;
 
    public DeleteOwnerCommandHandler(
        DataContext dataContext,
        IOwnerService ownerService)
    {
        _dataContext = dataContext;
        _ownerService = ownerService;
    }
 
    public async Task Handle(DeleteOwnerCommand request, CancellationToken cancellationToken)
    {
        var owner = await _dataContext.Owners
                        .FirstOrDefaultAsync(x => x.IsnOwner == request.IsnOwner, cancellationToken)
                    ?? throw new BusinessLogicException($"Владелец с идентификатором \"{request.IsnOwner}\" не существует");
 
        await _ownerService.CanDeleteAndThrowAsync(
            _dataContext, owner, cancellationToken);
 
        _dataContext.Owners.Remove(owner);
        await _dataContext.SaveChangesAsync(cancellationToken);
    }
}