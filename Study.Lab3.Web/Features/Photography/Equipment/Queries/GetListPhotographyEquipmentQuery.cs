using MediatR;
using Microsoft.EntityFrameworkCore;
using Study.Lab3.Storage.Database;
using Study.Lab3.Web.Features.Photography.Equipment.DtoModels;

namespace Study.Lab3.Web.Features.Photography.Equipment.Queries;

/// <summary>
/// Получение списка оборудования фотостудии
/// </summary>
public sealed class GetListPhotographyEquipmentQuery : IRequest<PhotographyEquipmentDto[]>
{
}

public sealed class GetListPhotographyEquipmentQueryHandler : IRequestHandler<GetListPhotographyEquipmentQuery, PhotographyEquipmentDto[]>
{
    private readonly DataContext _dataContext;

    public GetListPhotographyEquipmentQueryHandler(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<PhotographyEquipmentDto[]> Handle(GetListPhotographyEquipmentQuery request, CancellationToken cancellationToken)
    {
        return await _dataContext.PhotographyEquipments
            .AsNoTracking()
            .Select(x => new PhotographyEquipmentDto
            {
                IsnPhotographyEquipment = x.IsnPhotographyEquipment,
                Name = x.Name,
                Type = x.Type,
                Brand = x.Brand,
                Model = x.Model,
                SerialNumber = x.SerialNumber,
                PurchaseDate = x.PurchaseDate,
                Price = x.Price,
                Status = x.Status,
                Description = x.Description
            })
            .OrderBy(x => x.Type)
            .ThenBy(x => x.Brand)
            .ThenBy(x => x.Model)
            .ToArrayAsync(cancellationToken);
    }
}