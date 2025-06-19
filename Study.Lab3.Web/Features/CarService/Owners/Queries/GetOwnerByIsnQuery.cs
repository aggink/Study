using System.ComponentModel.DataAnnotations;
using CoreLib.Common.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CarService.Owners.DtoModels;

namespace Study.Lab3.Web.Features.CarService.Owners.Queries;

public sealed class GetOwnerByIsnQuery : IRequest<OwnerDto>
{
    /// <summary>
    /// Идентификатор владельца
    /// </summary>
    [Required]
    [FromQuery]
    public Guid IsnOwner { get; init; }
}
 
public sealed class GetOwnerByIsnQueryHandler : IRequestHandler<GetOwnerByIsnQuery, OwnerDto>
{
    private readonly DataContext _dataContext;
 
    public GetOwnerByIsnQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
 
    public async Task<OwnerDto> Handle(GetOwnerByIsnQuery request, CancellationToken cancellationToken)
    {
        var owner = await _dataContext.Owners
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.IsnOwner == request.IsnOwner, cancellationToken)
                    ?? throw new BusinessLogicException($"Владелец с идентификатором \"{request.IsnOwner}\" не существует");
 
        return new OwnerDto
        {
            IsnOwner = owner.IsnOwner,
            FirstName = owner.FirstName,
            SecondName = owner.SecondName,
            PhoneNumber = owner.PhoneNumber,
            Email = owner.Email,
            Address = owner.Address
        };
    }
}