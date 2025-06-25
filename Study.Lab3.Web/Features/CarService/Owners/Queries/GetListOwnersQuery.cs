using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.CarService.Owners.DtoModels;

namespace Study.Lab3.Web.Features.CarService.Owners.Queries;

public sealed class GetListOwnersQuery : IRequest<OwnerDto[]>
{
}
 
public sealed class GetListOwnersQueryHandler : IRequestHandler<GetListOwnersQuery, OwnerDto[]>
{
    private readonly DataContext _dataContext;
 
    public GetListOwnersQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
 
    public async Task<OwnerDto[]> Handle(GetListOwnersQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.Owners
            .AsNoTracking()
            .Select(x => new OwnerDto
            {
                IsnOwner = x.IsnOwner,
                FirstName = x.FirstName,
                SecondName = x.SecondName,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                Address = x.Address
            })
            .OrderBy(x => x.SecondName)
            .ThenBy(x => x.FirstName)
            .ToArrayAsync(cancellationToken);
    }
}